using Microsoft.AspNetCore.Mvc;
using a13.InAndOut.Data;
using System.Collections.Generic;
using a13.InAndOut.Models;

namespace a13.InAndOut.Controllers
{
    public class ExpenseController : Controller
    {

        // Dependency Injection¨Φτιάχνω το αντικείμενο _db.
        private readonly AppplicationDBContext _db;

        // We need a constructor from where we will then get the database context.
        public ExpenseController(AppplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Expense> objList = _db.Expenses;
            return View(objList);
        }

        //-------------------------------------------------------------------------------------------------
        // Θέλουμε απλά να μας πάει σε μια νέα σελίδα.  // GET Create.
        public IActionResult Create()
        {
            return View();
        }
        //-------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------
        // Πατήθηκε το κουμπι "Create" - Για εισαγωγή στην Βάση Δεδομένων. // POST Create.
        [HttpPost]
        [ValidateAntiForgeryToken]                 // Μόνο αν έχουμε κάποιο token θα εκτελέσει το post.
        public IActionResult Create(Expense obj)   // Το object που θα πάρει από την φόρμα.
        {

            if (ModelState.IsValid)                // Check if the object is valid
            {
                _db.Expenses.Add(obj);                 // Εισαγωγή στην βάση δεδομένων.
                _db.SaveChanges();
                return RedirectToAction("Index");      // Redirect στον Item Controller, Index action.
            }

            return View(obj);
        }
        //-------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------
        // GET Delete - Θα πάει στο View για τα σβήσουμε την εγγραφή.
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Expenses.Find(id);      // Πάρε το Οbject από την βάση δεδομένων.

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);                     // Πήγαινε στο View και βάλε και πάρε και το id.

        }


        // POST DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]                 // Μόνο αν έχουμε κάποιο token θα εκτελέσει το post.
        public IActionResult DeletePost(int? id)   
        {

            var obj=_db.Expenses.Find(id);         // Βρες το id.


            if (obj == null)                       // Αν το id υπάρχει ή όχι.
            {
                return NotFound();
            }

            
            _db.Expenses.Remove(obj);              // Διαγραφή από την βάση δεδομένων.
            _db.SaveChanges();


            return RedirectToAction("Index");      // Redirect στον Item Controller, Index action.           

        }

        //-------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------

        // GET Update
        public IActionResult Update(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Expenses.Find(id);      // Πάρε το Οbject από την βάση δεδομένων.

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);                     // Πήγαινε στο View και βάλε και πάρε και το id.

        }


        // POST UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]                 // Μόνο αν έχουμε κάποιο token θα εκτελέσει το post.
        public IActionResult Update(Expense obj)
        {

            if (ModelState.IsValid)                // Check if the object is valid
            {
                _db.Expenses.Update(obj);           // Διαγραφή από την βάση δεδομένων.
                _db.SaveChanges();
            }

            return RedirectToAction("Index");      // Redirect στον Item Controller, Index action.           

        }
        //-------------------------------------------------------------------------------------------------


    }
}
