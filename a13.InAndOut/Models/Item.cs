using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace a13.InAndOut.Models
{
    public class Item
    {


        [Key]  // This is my primary Key
        public int Id { get; set; }
        public string Borrower { get; set; }
        public string Lender { get; set; }


        [DisplayName("Item Name")]
        public string ItemName { get; set; }


    }
}
