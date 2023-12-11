using System.ComponentModel.DataAnnotations;

namespace webApi_Nupat_1.Model
{
    public class Food
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100,ErrorMessage ="Indjdhkdhd",MinimumLength =1)]
        public string Name { get; set; }
        [Required]
        [Range(100.0,120_000.0)]
        public double Price { get; set; }
    }
}
