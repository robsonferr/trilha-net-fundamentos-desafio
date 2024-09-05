using System.Text;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        int capacidadeMaxima = 10;
        public bool EstaCheio { get { return this.veiculos.Count() == capacidadeMaxima; } }

        private List<Veiculo> veiculos = new List<Veiculo>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora, int capacidadeMaxima)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
            this.capacidadeMaxima = capacidadeMaxima;
        }

        public void AdicionarVeiculo()
        {
            if (this.EstaCheio)
            {
                Console.WriteLine("Infelizmente o estacionamento já está cheio!");
            }
            else
            {
                string placa;
                do
                {
                    Console.WriteLine("Digite a placa do veículo para estacionar:");
                    placa = Console.ReadLine();
                    if (string.IsNullOrEmpty(placa))
                    {
                        Console.WriteLine("A placa informada não é válida!");
                        Console.WriteLine("Digite uma placa no formato correto ou SAIR para voltar ao menu inicial");
                    }
                    else if (placa.ToUpper().Equals("SAIR"))
                        break;

                } while (string.IsNullOrEmpty(placa));
                if (!placa.Equals("SAIR"))
                    veiculos.Add(new Veiculo(placa));
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.Placa.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horas = Convert.ToInt32(Console.ReadLine()); ;
                decimal valorTotal = this.precoInicial + (this.precoPorHora * horas);

                this.veiculos.Remove(this.veiculos.Find(v => v.Placa.ToUpper().Equals(placa)));

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                var estacionados = new StringBuilder($"Os veículos estacionados são: {Environment.NewLine}");
                foreach (var veiculo in this.veiculos)
                    estacionados.AppendLine(veiculo.Placa);
                Console.WriteLine(estacionados.ToString());
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
