namespace JogoDaMemoria
{
    internal class Program
    {
        private static void Main(string[] args)
        {  
            Console.Title = "Jogo da Memória";
            Jogo jogo = new Jogo();
            jogo.Iniciar();
        }
    }
}