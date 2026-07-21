using System;
using System.Threading;

namespace JogoDaMemoria
{
    public static class Util
    {
        public static void LimparTela()
        {
            Console.Clear();
        }

        public static void PausarSegundos(int segundos)
        {
            Thread.Sleep(segundos * 1000);
        }

        public static (int linha, int coluna) LerCoordenada(Tabuleiro tabuleiro, string mensagem)
        {
            while (true)
            {
                Console.Write($"{mensagem} (Linha Coluna): ");
                string? entrada = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(entrada))
                {
                    string[] partes = entrada.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    
                    if (partes.Length == 2 &&
                        int.TryParse(partes[0], out int linha) &&
                        int.TryParse(partes[1], out int coluna))
                    {
                        // Ajusta índice de 1-based para 0-based
                        linha--;
                        coluna--;

                        if (tabuleiro.ValidarCoordenada(linha, coluna))
                        {
                            return (linha, coluna);
                        }
                    }
                }

                Console.WriteLine("⚠️ Jogada inválida! Escolha uma posição válida e ainda fechada.");
            }
        }
    }
}