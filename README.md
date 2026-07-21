# Jogo da memória
Projeto desenvolvido em C utilizando Git e Github
## Integrantes
Marcos David (Desenvolveu Jogo.cs e Tabuleiro.cs)
Marlon Ronie (Desenvolveu Program.cs e util.cs)
Ana keyciane (Desenvolveu Pontuacao.cs e Read.me)
## Linguagem
- C#
## Como Jogar
Em cada rodada digite as coodernadas(linha e coluna) de duas cartas
Se forem iguais, elas permanecem abertas e o jogador pontua. Se for diferente as cartas se fecham
O jogo termina quando todos os pares forem encontrados!
# Planejamento da Arquitetura e Módulos
util: Funções auxiliaresportáveis para limpar a tela e pausar execução
tabuleiro: Gerenciamentoda matriz
pontuacao: Módulo responsável por registrar tentaivas e aceros do jogador
jogo: Loop principal e lógica de interação do usuario
main: Ponto de entrada que inicializa e orquestra o jogo
