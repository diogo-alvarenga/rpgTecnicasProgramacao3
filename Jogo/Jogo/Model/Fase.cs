namespace Jogo.Model
{
    // MODEL: regras da fase de exploração.
    internal class Fase
    {
        private readonly Random rn = new Random();

        // Sorteia de 1 a 10; acima de 5 aparece um inimigo.
        // Regra de encontro isolada do fluxo de exploração.
        public bool EncontrouInimigo()
        {
            return rn.Next(1, 11) > 5;
        }
    }
}
