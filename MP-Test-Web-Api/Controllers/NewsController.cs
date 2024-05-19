using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using MPTWA_Application.Interfaces;
using MPTWA_Infrastructure.Models.Requests;

namespace MP_Test_Web_Api.Controllers;

public class NewsController : Controller
{
    private IVowelCountService _vowelCountService;

    public NewsController(IVowelCountService vowelCountService)
    {
        _vowelCountService = vowelCountService;
    }
    
    [HttpGet("news-with-counter")]
    public async Task<IActionResult> GetNewsWithCounterAsync(GetNewsWithCountRequest request)
    {
        try
        {
            var res = await _vowelCountService.GetNewsWithCounter(request);
            if (res.Results.Count > 0)
                return Ok(res);
            return NoContent();
        }
        catch (Exception e)
        {
            Response.Headers.Append("X-Error-Message",e.Message);
            return BadRequest();
        }
    }
    [HttpGet("news-with-counter-package")]
    public async Task<IActionResult> GetNewsWithCounterFromPackageAsync(GetNewsWithCountRequest request)
    {
        try
        {
            var res = await _vowelCountService.GetNewsWithCounterFromPackage(request);
            if (res.Results.Count > 0)
                return Ok(res);
            return NoContent();
        }
        catch (Exception e)
        {
            Response.Headers.Append("X-Error-Message",e.Message);
            return BadRequest();
        }
    }

    [HttpGet("last-request-from-log")]
    public async Task<IActionResult> GetLastRequestFromLog()
    {
        try
        {
            var res = await _vowelCountService.GetLastResult();
            if (res!=null)
                return Ok(res);
            return NoContent();
        }
        catch (Exception e)
        {
            Response.Headers.Append("X-Error-Message",e.Message);
            return BadRequest();
        }
    }
}