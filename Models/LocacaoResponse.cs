// Classe que representa os dados retornados após o cálculo de uma locação.

namespace CP_02_Locadora.Models
{
    public class LocacaoResponse
    {
        public string Carro { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public double ValorDiaria { get; set; }
        public double Subtotal { get; set; }
        public string Desconto { get; set; } = string.Empty;
        public double ValorFinal { get; set; }
    }
}
