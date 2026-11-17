using Jogo.Model;
using Jogo.Model.Personagens;
using Jogo.View;

namespace Jogo.Controller
{
    // CONTROLLER da batalha: lê a escolha na View, pede ao Model
    // (Batalha + Proxy) para executar e manda a View mostrar o resultado.
    internal class BatalhaController
    {
        private readonly JogoView view;

        public BatalhaController(JogoView view)
        {
            this.view = view;
        }

        // Retorna true se o jogador morreu.
        public bool IniciarBatalha(InterfacePersonagem jogador)
        {
            // O controlador gerencia o diálogo; o Model mantém o estado do combate.
            Batalha batalha = new Batalha(jogador);

            while (!batalha.Terminou)
            {
                view.MostrarMenuBatalha(batalha.VidaJogador, batalha.VidaInimigo);
                int opc = view.LerInt();
                view.PularLinhas(10);

                // A validação da ação é delegada ao Model e ao Proxy.
                string? erro = batalha.ValidarOpcao(opc);
                if (erro != null)
                {
                    view.MostrarMensagem(erro);
                    continue;
                }

                view.MostrarMensagens(batalha.TurnoJogador(opc));

                if (!batalha.Terminou)
                {
                    view.MostrarTituloTurnoInimigo();
                    view.MostrarMensagens(batalha.TurnoInimigo());
                }
            }

            view.MostrarMensagem(batalha.JogadorMorreu
                ? "\nFim da batalha."
                : "\nA batalha terminou.");

            return batalha.JogadorMorreu;
        }
    }
}
