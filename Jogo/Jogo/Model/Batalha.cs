using Jogo.Model.Padroes;
using Jogo.Model.Personagens;

namespace Jogo.Model
{
    // MODEL: regras e estado de uma batalha.
    // Guarda o jogador (protegido pelo Proxy) e o inimigo, e calcula
    // o resultado de cada turno. Não lê teclado e não escreve na tela.
    internal class Batalha
    {
        private readonly InterfacePersonagem jogador;
        private readonly Proxy proxy;
        private readonly Inimigo inimigo = new Inimigo();

        public bool Terminou { get; private set; }
        public bool JogadorMorreu { get; private set; }

        public Batalha(InterfacePersonagem jogador)
        {
            this.jogador = jogador;
            // A batalha utiliza um intermediário para ações do jogador.
            proxy = new Proxy(jogador);
        }

        public int VidaJogador => jogador.getVida();
        public int VidaInimigo => inimigo.GetVida();

        // Pergunta ao Proxy se a opção é permitida (null = permitida).
        public string? ValidarOpcao(int opc) => proxy.Verificar(opc);

        // Turno do jogador: todas as ações passam pelo Proxy.
        public List<string> TurnoJogador(int opc)
        {
            var mensagens = new List<string>();

            if (opc == 3)
            {
                mensagens.Add(proxy.Fugir());
                Terminou = true;
                return mensagens;
            }

            ResultadoAcao resultado = opc == 1 ? proxy.Atacar() : proxy.JogarMagia();
            // Dano e mensagem chegam juntos, sem acesso ao Console.
            inimigo.ReceberDano(resultado.Dano);

            mensagens.Add(resultado.Mensagem);
            mensagens.Add(opc == 1
                ? "Você causou " + resultado.Dano + " de dano."
                : "Você causou " + resultado.Dano + " de dano mágico.");

            if (inimigo.GetVida() <= 0)
            {
                mensagens.Add("\nVocê derrotou o inimigo!");
                Terminou = true;
            }

            return mensagens;
        }

        // Turno do inimigo: ataque + dano de veneno.
        public List<string> TurnoInimigo()
        {
            var mensagens = new List<string>();

            int danoInimigo = inimigo.Atacar();
            jogador.ReceberDano(danoInimigo);
            mensagens.Add("O inimigo causou " + danoInimigo + " de dano.");

            if (jogador.GetVeneno() > 0)
            {
                int danoVeneno = jogador.GetVeneno();
                jogador.ReceberDano(danoVeneno);
                mensagens.Add("O veneno causou " + danoVeneno + " de dano.");
            }

            if (jogador.getVida() <= 0)
            {
                mensagens.Add("\nVocê morreu!");
                Terminou = true;
                JogadorMorreu = true;
            }

            return mensagens;
        }
    }
}
