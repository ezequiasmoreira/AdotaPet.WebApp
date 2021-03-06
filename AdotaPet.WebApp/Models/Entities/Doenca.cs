using System.ComponentModel.DataAnnotations;

namespace AdotaPet.WebApp.Models.Entities
{
    public class Doenca
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public int Codigo { get; set; }

        [Required, StringLength(200)]
        public string Descricao { get; set; }
    }
}