using System;

namespace JogoDaMemoria
{
    public class Pontuacao
    {
        public int Tentativas { get; private set; }
        public int ParesEncontrados { get; private set; }
        public int TotalPares { get; }

        public Pontuacao(int totalPares)
        {
            TotalPares = totalPares;
            Tentativas = 0;
            ParesEncontrados = 0;
        }

        public void RegistrarTentativa(bool acertou)
        {
            Tentativas++;
            if (acertou)
            {
                ParesEncontrados++;
            }
        }

        public void ExibirPlacar()
        {
            Console.WriteLine("\n--- PLACAR ---");
            Console.WriteLine($"Pares Encontrados: {ParesEncontrados} / {TotalPares}");
            Console.WriteLine($"Tentativas:        {Tentativas}");
            Console.WriteLine("----------------");
        }

        public int CalcularPontosFinais()
        {
            if (Tentativas == 0) return 0;

            // Pontuação inicial baseada no total de pares (100 pontos por par)
            int pontosBase = TotalPares * 100;
            
            // Penalidade por erros/tentativas extras acima do mínimo necessário
            int tentativasExtras = Tentativas - TotalPares;
            int penalidade = tentativasExtras > 0 ? tentativasExtras * 10 : 0;

            int pontuacaoFinal = pontosBase - penalidade;

            // Retorna no mínimo 10 pontos como recompensa por concluir
            return Math.Max(pontuacaoFinal, 10);
        }
    }
}
