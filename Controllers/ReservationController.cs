using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class ReservationController : Controller
{
    private readonly AppDbContext _context;

    public ReservationController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var reservations = _context.Reservations.ToList();
        return View(reservations);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Reservation reservation)
    {
        if (ModelState.IsValid)
        {
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(reservation);
    }
}
