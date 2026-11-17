using Jogo.Controller.Comandos;
using Jogo.Model;
using Jogo.Model.Padroes;
using Jogo.Model.Personagens;
using Jogo.View;

namespace Jogo.Controller
{
    // CONTROLLER principal: controla o fluxo do jogo
    // (escolher personagem -> explorar -> batalhar).
    // Faz a ponte entre a View (tela) e o Model (dados e regras).
    internal class JogoController
    {
        // Coordena as dependências sem assumir cálculos de batalha.
        private readonly JogoView view;
        private readonly Fase fase = new Fase();
        private readonly BatalhaController batalhaController;
        private readonly ExecutorComando executor = new ExecutorComando();

        public JogoController(JogoView view)
        {
            this.view = view;
            batalhaController = new BatalhaController(view);
        }

        public void Iniciar()
        {
            while (true)
            {
                InterfacePersonagem jogador = EscolherPersonagem();
                Explorar(jogador);
                // Ao sair de Explorar o personagem morreu: volta à escolha.
            }
        }

        private InterfacePersonagem EscolherPersonagem()
        {
            while (true)
            {
                view.MostrarMenuPersonagem();
                int opc = view.LerInt();

                // FACTORY METHOD: o Controller pede ao Model para criar o personagem.
                // A fábrica devolve o contrato, sem expor o tipo concreto ao fluxo.
                InterfacePersonagem? jogador = Factory.EscolherPersonagem(opc);

                if (jogador == null)
                {
                    view.MostrarMensagem("Personagem inválido.");
                    continue;
                }

                view.MostrarPersonagemEscolhido(jogador.getNome(), jogador.getVida(), jogador.getArma());
                return jogador;
            }
        }

        private void Explorar(InterfacePersonagem jogador)
        {
            while (jogador.getVida() > 0)
            {
                view.MostrarTituloExploracao();
                int casas = view.PerguntarCasas();

                // COMMAND: a ação de andar vira um objeto executado pelo Invoker.
                // A solicitação de movimento é encapsulada antes da execução.
                string mensagem = executor.Executar(new ComandoAndar(jogador, casas));
                view.MostrarMensagem(mensagem);

                if (fase.EncontrouInimigo())
                {
                    bool morreu = batalhaController.IniciarBatalha(jogador);
                    if (morreu)
                    {
                        return;
                    }
                }
                else
                {
                    view.MostrarMensagem("Você não encontrou nenhum inimigo.");
                }
            }
        }
    }
}
