using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace MvcCoreTutorial.Models.Domain
{
    public class Person
    {
        public int Id { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string? Name { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [EmailAddress]
        public string? Email { get; set; }
       
    }
}
