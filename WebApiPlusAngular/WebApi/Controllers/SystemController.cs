using System.CodeDom.Compiler;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SystemController : ControllerBase {

    [Route("InfiniteRecursion")]
    [HttpGet()]
    public ActionResult InfiniteRecursion() => InfiniteRecursion();

}