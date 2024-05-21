using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FptLongChauApp.Models
{
    [Table("Drug")]
    public class Drug
    {
        [Key]
        public int DrugId {set; get;}
        public string ImagePath { set; get;}
        public string Name {set; get;}
        public string Description {set; get;}
        public decimal Price {set; get;}
    }
}