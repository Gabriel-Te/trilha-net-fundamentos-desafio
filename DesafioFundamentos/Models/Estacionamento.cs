using System.Globalization;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public bool ValidarPlaca(string placa, int modeloPlaca)
        {
            if(placa.Length == 7 && veiculos.Contains(placa) == false)
            {
                switch(modeloPlaca)
                {
                    case 1:
                        string pattern1 = @"^[A-Z]{3}\d{1}[A-Z]{1}\d{2}$";
                        return Regex.IsMatch(placa, pattern1);
                    case 2:
                        string pattern2 = @"^[A-Z]{3}\d{4}$";
                        return Regex.IsMatch(placa, pattern2);
                    default:
                        return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            {
                while (true)
                {
                    Console.WriteLine("\nDigite o tipo da placa");
                    Console.WriteLine("\n 1- Mercosul (LLLNLNN) ou");
                    Console.Write("\n 2- Modelo antigo (AAA0000)");

                    int modeloPlaca = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Digite a Placa");
                    string placa = Console.ReadLine().ToUpper();

                    {
                        if ( ValidarPlaca(placa, modeloPlaca) )
                        {
                            veiculos.Add(placa);
                            Console.WriteLine("Veículo Adicionado com sucesso");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Placa Inválida, tente novamente");
                        }
                    }
                }

            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                // *IMPLEMENTE AQUI*
                int horas = int.Parse(Console.ReadLine());
            
                decimal valorTotal = precoInicial + (precoPorHora * horas);

                // TODO: Remover a placa digitada da lista de veículos
                // *IMPLEMENTE AQUI*
                veiculos.Remove(placa);

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
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
