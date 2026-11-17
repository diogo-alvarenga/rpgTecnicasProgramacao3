namespace Jogo.Controller.Comandos
{
    // Invoker: solicita a execução sem conhecer os detalhes da movimentação.
    internal class ExecutorComando
    {
        // Invoker: conhece apenas IComando, não ComandoAndar.
        public string Executar(IComando comando) => comando.Executar();
    }
}
