using System;

namespace JogoDaMemoria
{
    public class Jogo
    {
        public void Iniciar()
        {
            int dimensao = 4; // Tabuleiro 4x4 (8 pares)
            int totalPares = (dimensao * dimensao) / 2;

            Tabuleiro tabuleiro = new Tabuleiro(dimensao, dimensao);
            Pontuacao placar = new Pontuacao(totalPares);

            while (!tabuleiro.JogoCompleto())
            {
                DesenharCabecalho(tabuleiro, placar);

                // Primeira Escolha
                var (l1, c1) = Util.LerCoordenada(tabuleiro, "\n👉 Primeira carta");
                tabuleiro.ObterCarta(l1, c1).Revelada = true;

                DesenharCabecalho(tabuleiro, placar);

                // Segunda Escolha
                var (l2, c2) = Util.LerCoordenada(tabuleiro, "\n👉 Segunda carta");
                tabuleiro.ObterCarta(l2, c2).Revelada = true;

                DesenharCabecalho(tabuleiro, placar);

                // Verificação de Par
                Tabuleiro.Carta carta1 = tabuleiro.ObterCarta(l1, c1);
                Tabuleiro.Carta carta2 = tabuleiro.ObterCarta(l2, c2);

                if (carta1.Valor == carta2.Valor)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\n✨ PAR ENCONTRADO! Excelente!");
                    placar.RegistrarTentativa(acertou: true);
                    Util.PausarSegundos(1);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n❌ Que pena! As cartas não coincidem.");
                    placar.RegistrarTentativa(acertou: false);
                    Util.PausarSegundos(2);

                    // Esconde as cartas novamente
                    carta1.Revelada = false;
                    carta2.Revelada = false;
                }
            }

            // Tela de Vitória
            Util.LimparTela();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("🎉 PARABÉNS! VOCÊ VENCEU O JOGO! 🎉");
            tabuleiro.Exibir(revelarTudo: true);
            Console.WriteLine($"\nPontuação Final: {placar.CalcularPontosFinais()} pontos em {placar.Tentativas} tentativas.\n");
        }

        private void DesenharCabecalho(Tabuleiro tabuleiro, Pontuacao placar)
        {
            Util.LimparTela();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("===============================");
            Console.WriteLine("     JOGO DA MEMÓRIA (C#)      ");
            Console.WriteLine("===============================");
            placar.ExibirPlacar();
            tabuleiro.Exibir();
        }
    }
}
