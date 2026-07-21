using System;
using System.Linq;

namespace JogoDaMemoria
{
    public class Tabuleiro
    {
        // Estrutura interna para representar a Carta diretamente no Tabuleiro
        public class Carta
        {
            public char Valor { get; set; }
            public bool Revelada { get; set; }

            public Carta(char valor)
            {
                Valor = valor;
                Revelada = false;
            }
        }

        public int Linhas { get; }
        public int Colunas { get; }
        private readonly Carta[,] grid;

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            grid = new Carta[linhas, colunas];

            InicializarEEmbaralhar();
        }

        public Carta ObterCarta(int linha, int coluna)
        {
            return grid[linha, coluna];
        }

        private void InicializarEEmbaralhar()
        {
            char simbolo = 'A';
            int contadorPar = 0;

            // Preenche o tabuleiro com pares de caracteres
            for (int i = 0; i < Linhas; i++)
            {
                for (int j = 0; j < Colunas; j++)
                {
                    grid[i, j] = new Carta(simbolo);
                    contadorPar++;

                    if (contadorPar == 2)
                    {
                        simbolo++;
                        contadorPar = 0;
                    }
                }
            }

            // Embaralhamento (Algoritmo Fisher-Yates)
            Random rand = new Random();
            for (int i = Linhas - 1; i >= 0; i--)
            {
                for (int j = Colunas - 1; j >= 0; j--)
                {
                    int randL = rand.Next(Linhas);
                    int randC = rand.Next(Colunas);

                    // Troca os valores entre as posições do grid
                    char temp = grid[i, j].Valor;
                    grid[i, j].Valor = grid[randL, randC].Valor;
                    grid[randL, randC].Valor = temp;
                }
            }
        }

        public void Exibir(bool revelarTudo = false)
        {
            Console.Write("\n   ");
            for (int j = 0; j < Colunas; j++)
            {
                Console.Write($" {j + 1}  ");
            }
            Console.WriteLine();

            Console.WriteLine("  +" + string.Concat(Enumerable.Repeat("---+", Colunas)));

            for (int i = 0; i < Linhas; i++)
            {
                Console.Write($"{i + 1} |");
                for (int j = 0; j < Colunas; j++)
                {
                    string item = (grid[i, j].Revelada || revelarTudo) 
                        ? grid[i, j].Valor.ToString() 
                        : "?";
                    Console.Write($" {item} |");
                }
                Console.WriteLine();
                Console.WriteLine("  +" + string.Concat(Enumerable.Repeat("---+", Colunas)));
            }
        }

        public bool ValidarCoordenada(int l, int c)
        {
            if (l < 0 || l >= Linhas || c < 0 || c >= Colunas)
                return false;

            return !grid[l, c].Revelada;
        }

        public bool JogoCompleto()
        {
            foreach (var carta in grid)
            {
                if (!carta.Revelada) return false;
            }
            return true;
        }
    }
}

