using Microsoft.AspNetCore.Mvc;
using VnResourceTestBE.Commons;

namespace VnResourceTestBE.Controllers;

public class TestController : ApiControllerBase
{
    [HttpPost]
    public ActionResult<Result<string>> Test()
    {
        return Ok(Result<string>.Succeed("ok"));
    }
}