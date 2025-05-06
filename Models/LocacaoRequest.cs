// Classe que representa os dados de entrada para cálculo de locação.

namespace CP_02_Locadora.Models
{
    public class LocacaoRequest
    {
        public int CarroId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
