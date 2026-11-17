using Jogo.Model.Personagens;

namespace Jogo.Model.Padroes
{
    // PADRÃO FACTORY METHOD (fica no MODEL, pois cria objetos do Model).
    // Creator: define o método de fábrica que as subclasses implementam.
    internal abstract class Factory
    {
        // Factory Method: subclasses decidem qual produto concreto instanciar.
        public abstract InterfacePersonagem CriarPersonagem();

        public static InterfacePersonagem? EscolherPersonagem(int opc)
        {
            // A escolha da fábrica fica concentrada neste ponto.
            Factory? fabrica = opc switch
            {
                1 => new FactoryGuerreiro(),
                2 => new FactoryMago(),
                3 => new FactoryArqueiro(),
                _ => null
            };
            return fabrica?.CriarPersonagem();
        }
    }

    // Concrete Creators
    internal class FactoryGuerreiro : Factory
    {
        public override InterfacePersonagem CriarPersonagem() => new Guerreiro();
    }

    internal class FactoryMago : Factory
    {
        public override InterfacePersonagem CriarPersonagem() => new Mago();
    }

    internal class FactoryArqueiro : Factory
    {
        public override InterfacePersonagem CriarPersonagem() => new Arqueiro();
    }
}
