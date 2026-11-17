namespace Jogo.Controller.Comandos
{
    // PADRÃO COMMAND (fica no CONTROLLER, pois transforma a ação
    // pedida pelo jogador em um objeto que pode ser executado).
    internal interface IComando
    {
        // Executa a ação e devolve a mensagem para a View mostrar.
        // Contrato independente da ação concreta.
        string Executar();
    }
}
