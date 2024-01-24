using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FibonacciEmail.Model
{
    public class EmailModel
    {
        [Key]
        private int _id { get; set; }
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public string EmailAddress { get; set; }


    }

}
