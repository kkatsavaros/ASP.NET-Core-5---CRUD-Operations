using Microsoft.AspNetCore.Mvc;
using a13.InAndOut.Data;
using System.Collections.Generic;
using a13.InAndOut.Models;

namespace a13.InAndOut.Controllers
{
    public class ItemController : Controller
    {

        // Dependency Injection¨Φτιάχνω το αντικείμενο _db
        private readonly AppplicationDBContext _db;

        // We need a constructor from where we will then get the database context
        public ItemController(AppplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Models.Item> objList = _db.Items;
            return View(objList);
        }

        // Θέλουμε απλά να μας πάει σε μια νέα σελίδα.  // GET Create
        public IActionResult Create()
        {            
            return View();
        }

        // Πατήθηκε το κουμπι "Create" - Για εισαγωγή στην Βάση Δεδομένων. // POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]              // Μόνο αν έχουμε κάποιο token θα εκτελέσει το post.
        public IActionResult Create(Item obj)   // Το object που θα πάρει από την φόρμα.
        {
            _db.Items.Add(obj);                 // Εισαγωγή στην βάση δεδομένων
            _db.SaveChanges();  
            return RedirectToAction("Index");   // Redirect στον Item Controller, Index action.
        }

    }
}

// 