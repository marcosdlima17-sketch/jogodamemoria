
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
}

