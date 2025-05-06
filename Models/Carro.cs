// Classe que representa a entidade Carro no sistema.

using System.ComponentModel.DataAnnotations;

namespace CP_02_Locadora.Models
{
    public class Carro
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O modelo é obrigatório.")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "A marca é obrigatória.")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O ano é obrigatório.")]
        public int Ano { get; set; }

        [Required(ErrorMessage = "O valor da diária é obrigatório.")]
        public double ValorDiaria { get; set; }
    }
}
