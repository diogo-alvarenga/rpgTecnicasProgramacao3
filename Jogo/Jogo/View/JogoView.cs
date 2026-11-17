namespace Jogo.View
{
    // VIEW: única parte do programa que usa o Console.
    // Mostra informações e lê o que o jogador digita,
    // mas não decide nada sobre as regras do jogo.
    // Centraliza entrada e saída; regras do jogo permanecem no Model.
    internal class JogoView
    {
        public void MostrarMenuPersonagem()
        {
            Console.WriteLine("\n======================");
            Console.WriteLine("ESCOLHA SEU PERSONAGEM");
            Console.WriteLine("======================");

            Console.WriteLine("Guerreiro - 1");
            Console.WriteLine("Mago - 2");
            Console.WriteLine("Arqueiro - 3");

            MostrarAvisoPadrao("Aqui será usado o FACTORY METHOD");
            Console.Write("Digite: ");
        }

        public void MostrarPersonagemEscolhido(string nome, int vida, string arma)
        {
            Console.WriteLine("Voce escolheu a classe: " + nome);
            Console.WriteLine("Voce tem " + vida + " de vida inicial");
            Console.WriteLine("Voce tem " + arma + " como arma");
        }

        public void MostrarTituloExploracao()
        {
            Console.WriteLine("\n======================");
            Console.WriteLine("EXPLORAÇÃO");
            Console.WriteLine("======================");
        }

        public int PerguntarCasas()
        {
            MostrarAvisoPadrao("Aqui está ativando o COMMAND!");
            Console.Write("Quantas casas deseja andar? ");
            int casas;
            do
            {
                casas = LerInt();
                if (casas <= 0) Console.Write("Digite uma quantidade maior que zero: ");
            } while (casas <= 0);
            return casas;
        }

        public void MostrarMenuBatalha(int vidaJogador, int vidaInimigo)
        {
            Console.WriteLine("\n======================");
            Console.WriteLine("BATALHA");
            Console.WriteLine("======================");

            Console.WriteLine("Sua vida: " + vidaJogador);
            Console.WriteLine("Vida do inimigo: " + vidaInimigo);

            Console.WriteLine("\nO que escolhe?");
            Console.WriteLine("1 - Atacar");
            Console.WriteLine("2 - Jogar Magia");
            Console.WriteLine("3 - Fugir");

            MostrarAvisoPadrao("Aqui será usado o PROXY");
        }

        public void MostrarTituloTurnoInimigo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n--- Turno do inimigo ---");
        }

        public void MostrarMensagens(IEnumerable<string> mensagens)
        {
            foreach (string mensagem in mensagens)
            {
                Console.WriteLine(mensagem);
            }
            Console.ResetColor();
        }

        public void MostrarMensagem(string mensagem)
        {
            Console.WriteLine(mensagem);
        }

        public void PularLinhas(int quantidade)
        {
            for (int i = 0; i < quantidade; i++)
            {
                Console.WriteLine();
            }
        }

        // Valida o formato da entrada, não as regras de cada opção.
        public int LerInt()
        {
            while (true)
            {
                string? entrada = Console.ReadLine();

                if (entrada == null)
                {
                    // Fim da entrada (ex.: Ctrl+Z / Ctrl+D): encerra o jogo.
                    Environment.Exit(0);
                }

                if (int.TryParse(entrada, out int valor))
                {
                    return valor;
                }

                Console.Write("Digite um número válido: ");
            }
        }

        private void MostrarAvisoPadrao(string texto)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(texto);
            Console.ResetColor();
        }
    }
}
