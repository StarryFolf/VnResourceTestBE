using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using VnResourceTestBE.DbContext;
using VnResourceTestBE.Models;
using VnResourceTestBE.Policies;
using VnResourceTestBE.Repositories.Implementations;
using VnResourceTestBE.Repositories.Interfaces;
using VnResourceTestBE.Services.Implementations;
using VnResourceTestBE.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var connectionString = builder.Configuration.GetConnectionString("SqlServer");

// Add services to the container.
builder.Services.AddDbContext<VnrInternShipContext>(builder => { builder.UseSqlServer(connectionString); },
    ServiceLifetime.Transient);

builder.Services.AddControllers(opt =>
{
    opt.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<IBaseRepository<MonHoc>, SubjectRepository>();
builder.Services.AddTransient<IBaseRepository<KhoaHoc>, CourseRepository>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddTransient<ICourseService, CourseService>();
builder.Services.AddTransient<ISubjectService, SubjectService>();
// builder.Services.AddTransient<>();

builder.Services.AddCors(options =>
    options.AddPolicy("Development", conf =>
    {
        conf.SetIsOriginAllowed(_ => true);
        conf.AllowAnyHeader();
        conf.AllowAnyMethod();
        conf.AllowCredentials();
        conf.WithExposedHeaders("Set-Cookie", "WWW-Authenticate");
    }));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("Development");
}

app.MapControllers();

app.Run();