using System;

<<<<<<< HEAD
using System;

class SistemaPontuacao
{
// Pontuação máxima permitida no jogo.
private const int PONTUACAO_MAXIMA = 10;

// Variável responsável por armazenar a pontuação atual.
private int pontuacao = 0;

// Exibe a pontuação atual na tela.
public void MostrarPontuacao()
{
Console.WriteLine($"Pontuação: {pontuacao:D2}");
}

// Adiciona um ponto ao jogador.
// O sistema impede que a pontuação ultrapasse 10.
public void AdicionarPonto()
{
if (pontuacao < PONTUACAO_MAXIMA)
{
pontuacao++;
}
}

// Remove um ponto do jogador.
// Impede que a pontuação fique negativa.
public void RemoverPonto()
{
if (pontuacao > 0)
{
pontuacao--;
}
}

// Retorna a pontuação atual.
public int ObterPontuacao()
{
return pontuacao;
}
=======
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
>>>>>>> f6185b0c3edf81d9a3816dfd755db8f7f76f143f
}
