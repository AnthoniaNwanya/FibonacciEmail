using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace FibonacciEmail.Model

{
    public class EmailModel
    {

        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public string EmailAddress { get; set; }


    }

}
