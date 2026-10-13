
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarInsurance.Models;
using CarInsurance.Controllers.Data;

public class InsureeController : Controller
{
    private readonly InsuranceContext _context;

    public InsureeController(InsuranceContext context)
    {
        _context = context;
    }

    // GET: INSUREES
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Insurees.ToListAsync());
    }

    // GET: INSUREES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var insuree = await _context.Insurees
            .FirstOrDefaultAsync(m => m.Id == id);
        if (insuree == null)
        {
            return NotFound();
        }

        return View(insuree);
    }

    // GET: INSUREES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: INSUREES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insuree insuree)
    {
        if (ModelState.IsValid)
        {
            if (!isValidCarYear(insuree))
            {
                ModelState.AddModelError("CarYear", "Invalid car year.");
                return View(insuree);
            }
            insuree = CalculateQuote(insuree);
            _context.Add(insuree);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(insuree);
    }

    // GET: INSUREES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var insuree = await _context.Insurees.FindAsync(id);
        if (insuree == null)
        {
            return NotFound();
        }
        return View(insuree);
    }

    // POST: INSUREES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insuree insuree)
    {
        if (id != insuree.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                if (!isValidCarYear(insuree))
                {
                    ModelState.AddModelError("CarYear", "Invalid car year.");
                    return View(insuree);
                }

                insuree = CalculateQuote(insuree);
                _context.Update(insuree);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsureeExists(insuree.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(insuree);
    }

    // GET: INSUREES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var insuree = await _context.Insurees
            .FirstOrDefaultAsync(m => m.Id == id);
        if (insuree == null)
        {
            return NotFound();
        }

        return View(insuree);
    }

    // POST: INSUREES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var insuree = await _context.Insurees.FindAsync(id);
        if (insuree != null)
        {
            _context.Insurees.Remove(insuree);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool InsureeExists(int? id)
    {
        return _context.Insurees.Any(e => e.Id == id);
    }

    public async Task<IActionResult> Admin()
    {
        var insurees = await _context.Insurees.ToListAsync();
        return View(insurees);
    }

    // Logic method to validate the insuree's car year
    private bool isValidCarYear(Insuree insuree)
    {
        return insuree.CarYear >= 1886 && insuree.CarYear <= DateTime.Now.Year;
    }

    // Logic method to calculate the insurance quote based on the insuree's information
    private Insuree CalculateQuote(Insuree insuree)
    {
        // Base of $50 / month
        decimal quote = 50;

        // Calculate the age of the insuree based on their date of birth
        int age = DateTime.Now.Year - insuree.DateOfBirth.Year;
        // If the birthday hasn't occurred yet this year, subtract 1 from the age
        if (insuree.DateOfBirth.Date > DateTime.Now.AddYears(-age))
        {
            age--;
        }

        // 18 or under, add $100
        if (age <= 18)
        {
            quote += 100;
        }
        // 19-25, add $50
        else if (age >= 19 && age <= 25)
        {
            quote += 50;
        }
        // 26 and older, add $25
        else
        {
            quote += 25;
        }

        // Car's year is before 2000, add $25
        if (insuree.CarYear < 2000)
        {
            quote += 25;
        }
        // Car's year is after 2015, add $25
        if (insuree.CarYear > 2015)
        {
            quote += 25;
        }

        // Car's make is a Porsche, add $25
        if (insuree.CarMake.Equals("Porsche", StringComparison.OrdinalIgnoreCase))
        {
            quote += 25;

            // Car's model is a 911 Carrera, add an additional $25
            if (insuree.CarModel.Equals("911 Carrera", StringComparison.OrdinalIgnoreCase))
            {
                quote += 25;
            }
        }

        // Speeding tickets 
        quote += insuree.SpeedingTickets * 10;

        // DUI , add 25% to the total
        if (insuree.DUI)
        {
            quote *= 1.25m;
        }

        // Full coverage, add 50% to the total
        if (insuree.CoverageType.Equals("Full", StringComparison.OrdinalIgnoreCase))
        {
            quote *= 1.5m;
        }

        insuree.Quote = quote;
        return insuree;
    }
}
