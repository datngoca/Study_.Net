using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Models;

namespace MyWebApiApp.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class HangHoaController : ControllerBase
{

    public static List<HangHoa> HangHoaList = new List<HangHoa>();
    // GET
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(HangHoaList);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        try
        {
            var hanghoa = HangHoaList.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
            if (hanghoa == null)
            {
                return NotFound();
            }
            return Ok(hanghoa);
        }
        catch
        {
            return BadRequest();
        }
        
    }
    
    [HttpPost]
    public IActionResult Create(HangHoaVM hangHoaVM)
    {
        var newHangHoa = new HangHoa
        {
            MaHangHoa = Guid.NewGuid(),
            TenHangHoa = hangHoaVM.TenHangHoa,
            DonGia = hangHoaVM.DonGia
        };
        HangHoaList.Add(newHangHoa);
        return Ok(new {Success= true, RouteData= newHangHoa});
    }
}