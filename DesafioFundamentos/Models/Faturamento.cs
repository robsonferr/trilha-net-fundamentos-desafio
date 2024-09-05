namespace DesafioFundamentos.Models
{
    public class Faturamento
    {
        public DateOnly Data { get; set; }
        public Veiculo veiculo { get; set; }
        public int Horas { get; set; }
        public decimal ValorTotal { get; set; }
    }
}