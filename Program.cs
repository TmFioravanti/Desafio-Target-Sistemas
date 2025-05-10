using System;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Data;
using System.Diagnostics.Metrics;
using TesteTargetSistemas;

namespace TesteTargetSistemas
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Questão 1: Observe o trecho de código abaixo: int INDICE = 13, SOMA = 0, K = 0; Enquanto K < INDICE faça { K = K + 1; SOMA = SOMA + K; } Imprimir(SOMA); Ao final do processamento, qual será o valor da variável SOMA? ");
            int INDICE = 13, SOMA = 0, K = 0;

            while (K < INDICE)
            {
                K = K + 1;
                SOMA = SOMA + K;
            }

            Console.WriteLine("A resposta é: " + SOMA);

            Console.WriteLine();
            Console.WriteLine(new string('-', 150));
            Console.WriteLine();


            Console.WriteLine("Questão 2: Dado a sequência de Fibonacci, onde se inicia por 0 e 1 e o próximo valor sempre será a soma dos 2 valores anteriores (exemplo: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34...), escreva um programa na linguagem que desejar onde, informado um número, ele calcule a sequência de Fibonacci e retorne uma mensagem avisando se o número informado pertence ou não a sequência. IMPORTANTE: Esse número pode ser informado através de qualquer entrada de sua preferência ou pode ser previamente definido no código; ");

            static bool ENumeroFibonacci(int numero)
            {
                int a = 0, b = 1;
                if (numero == 0 || numero == 1) return true;

                while (b < numero)
                {
                    int temp = b;
                    b = a + b;
                    a = temp;
                }

                return b == numero;
            }


            Console.Write("Informe um número: ");
            int num = int.Parse(Console.ReadLine());

            if (ENumeroFibonacci(num))
                Console.WriteLine($"{num} pertence à sequência de Fibonacci.");
            else
                Console.WriteLine($"{num} não pertence à sequência de Fibonacci.");

            Console.WriteLine();
            Console.WriteLine(new string('-', 150));
            Console.WriteLine();

            Console.WriteLine("Questão 3:Dado um vetor que guarda o valor de faturamento diário de uma distribuidora, faça um programa, na linguagem que desejar, que calcule e retorne: " +
                "• O menor valor de faturamento ocorrido em um dia do mês; " +
                "• O maior valor de faturamento ocorrido em um dia do mês; " +
                "• Número de dias no mês em que o valor de faturamento diário foi superior à média mensal. " +
                "IMPORTANTE: " +
                "a) Usar o json ou xml disponível como fonte dos dados do faturamento mensal; " +
                "b) Podem existir dias sem faturamento, como nos finais de semana e feriados. Estes dias devem ser ignorados no cálculo da média;");

            string caminhoArquivo = "dados.json";

            string json = File.ReadAllText(caminhoArquivo);
            List<FaturamentoDiario> dados = JsonSerializer.Deserialize<List<FaturamentoDiario>>(json);

            var diasComFaturamento = dados.Where(d => d.valor > 0).ToList();

            double menor = diasComFaturamento.Min(d => d.valor);
            double maior = diasComFaturamento.Max(d => d.valor);
            double media = diasComFaturamento.Average(d => d.valor);
            int diasAcimaDaMedia = diasComFaturamento.Count(d => d.valor > media);

            // Aqui estão os três Console.WriteLine na classe principal Program:
            Console.WriteLine($"Menor faturamento: R$ {menor:F2}");
            Console.WriteLine($"Maior faturamento: R$ {maior:F2}");
            Console.WriteLine($"Número de dias com faturamento acima da média: {diasAcimaDaMedia}");

            Console.WriteLine();
            Console.WriteLine(new string('-', 150));
            Console.WriteLine();

            Console.WriteLine("Questão 4: Dado o valor de faturamento mensal de uma distribuidora, detalhado por estado: • SP – R$67.836,43 • RJ – R$36.678,66 • MG – R$29.229,88 • ES – R$27.165,48 • Outros – R$19.849,53 Escreva um programa na linguagem que desejar onde calcule o percentual de representação que cada estado teve dentro do valor total mensal da distribuidora.");

            var faturamentoEstados = new Dictionary<string, double>
            {
            { "SP", 67836.43 },
            { "RJ", 36678.66 },
            { "MG", 29229.88 },
            { "ES", 27165.48 },
            { "Outros", 19849.53 }
            };
            double faturamentoTotal = 0;
            foreach (var valor in faturamentoEstados.Values)
            {
                faturamentoTotal += valor;
            }

            Console.WriteLine("Percentual de representação por estado:");
            foreach (var estado in faturamentoEstados)
            {
                double percentual = (estado.Value / faturamentoTotal) * 100;
                Console.WriteLine($"{estado.Key}: {percentual:F2}%");
            }

            Console.WriteLine();
            Console.WriteLine(new string('-', 150));
            Console.WriteLine();

            Console.WriteLine("Questão 5: Escreva um programa que inverta os caracteres de um string. IMPORTANTE: a) Essa string pode ser informada através de qualquer entrada de sua preferência ou pode ser previamente definida no código; b) Evite usar funções prontas, como, por exemplo, reverse; ");

            static string InverterString(string texto)
            {
                int inicio = 0;
                int fim = texto.Length - 1;
                char[] resultado = new char[texto.Length];

                while (inicio <= fim)
                {
                    resultado[inicio] = texto[fim];
                    resultado[fim] = texto[inicio];

                    inicio++;
                    fim--;
                }

                return new string(resultado);
            }

            Console.Write("Informe uma string: ");
            string texto = Console.ReadLine();

            string resultado = InverterString(texto);
            Console.WriteLine($"String invertida: {resultado}");
        }
    }
}