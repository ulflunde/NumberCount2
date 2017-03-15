using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NumberCount2.Model;
using NumberCount2.Models;

namespace NumberCount2.Controllers
{
    public class NumberSeriesController : Controller
    {
        private readonly NumberCount2Context _context;

        public NumberSeriesController(NumberCount2Context context)
        {
            _context = context;    
        }

        // GET: NumberSeries
        public async Task<IActionResult> Index()
        {
            return View(await _context.NumberSeries.ToListAsync());
        }

        // GET: NumberSeries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var numberSeries = await _context.NumberSeries
                .SingleOrDefaultAsync(m => m.ID == id);
            if (numberSeries == null)
            {
                return NotFound();
            }

            return View(numberSeries);
        }

        // GET: NumberSeries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NumberSeries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID")] NumberSeries numberSeries)
        {
            if (ModelState.IsValid)
            {
                _context.Add(numberSeries);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(numberSeries);
        }

        // GET: NumberSeries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var numberSeries = await _context.NumberSeries.SingleOrDefaultAsync(m => m.ID == id);
            if (numberSeries == null)
            {
                return NotFound();
            }
            return View(numberSeries);
        }

        // POST: NumberSeries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID")] NumberSeries numberSeries)
        {
            if (id != numberSeries.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(numberSeries);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NumberSeriesExists(numberSeries.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(numberSeries);
        }

        // GET: NumberSeries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var numberSeries = await _context.NumberSeries
                .SingleOrDefaultAsync(m => m.ID == id);
            if (numberSeries == null)
            {
                return NotFound();
            }

            return View(numberSeries);
        }

        // POST: NumberSeries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var numberSeries = await _context.NumberSeries.SingleOrDefaultAsync(m => m.ID == id);
            _context.NumberSeries.Remove(numberSeries);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool NumberSeriesExists(int id)
        {
            return _context.NumberSeries.Any(e => e.ID == id);
        }
    }
}
