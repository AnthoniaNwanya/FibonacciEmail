using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace FibonacciEmail.Model

{
    public class EmailModel
    {

        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }

        [Required]
        public int Number1 { get; set; }

        [Required]
        public int Number2 { get; set; }

        [Required]
        public string EmailAddress { get; set; }


    }

}
