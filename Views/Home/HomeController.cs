using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Reserve()
    {
        ViewBag.Tables = await _context.Tables.Where(t => !t.IsReserved).ToListAsync();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Reserve(Reservation reservation)
    {
        var table = await _context.Tables.FindAsync(reservation.TableId);
        if (table != null && !table.IsReserved)
        {
            table.IsReserved = true;
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Index");
    }
}