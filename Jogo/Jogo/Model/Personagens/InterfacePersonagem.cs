namespace Jogo.Model.Personagens
{
    // MODEL: contrato de todos os personagens jogáveis.
    // Contrato comum para personagens reais e Proxy.
    internal interface InterfacePersonagem
    {
        string getArma();
        int getVida();
        string getNome();

        ResultadoAcao Atacar();
        ResultadoAcao JogarMagia();

        string Andar(int casas);
        string Fugir();

        void SetVeneno(int dano);
        int GetVeneno();

        bool PodeAtacar();
        bool PodeUsarMagia();

        void ReceberDano(int dano);
    }
}
