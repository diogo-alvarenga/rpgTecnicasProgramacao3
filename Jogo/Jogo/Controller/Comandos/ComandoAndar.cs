using Jogo.Model.Personagens;

namespace Jogo.Controller.Comandos
{
    // Concrete Command: guarda o receptor (personagem do Model)
    // e os parâmetros da ação.
    internal class ComandoAndar : IComando
    {
        // Receiver e parâmetros ficam associados ao comando.
        private readonly InterfacePersonagem personagem;
        private readonly int casas;

        public ComandoAndar(InterfacePersonagem personagem, int casas)
        {
            this.personagem = personagem;
            this.casas = casas;
        }

        // O comando delega a execução ao personagem.
        public string Executar() => personagem.Andar(casas);
    }
}
