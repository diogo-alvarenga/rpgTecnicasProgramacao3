namespace Jogo.Model.Personagens
{
    // MODEL: inimigo encontrado durante a exploração.
    // Implementação concreta das regras básicas do adversário.
    internal class Inimigo : InterfaceInimigo
    {
        private int vida = 50;

        public int Atacar()
        {
            return 4;
        }

        public int GetVida()
        {
            return vida;
        }

        public void ReceberDano(int dano)
        {
            vida -= dano;

            if (vida < 0)
            {
                vida = 0;
            }
        }
    }
}
