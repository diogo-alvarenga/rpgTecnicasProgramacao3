namespace Jogo.Model.Personagens
{
    // MODEL: contrato dos inimigos.
    // Contrato das operações utilizadas pela batalha.
    internal interface InterfaceInimigo
    {
        int Atacar();
        int GetVida();
        void ReceberDano(int dano);
    }
}
