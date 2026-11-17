namespace Jogo.Model.Personagens;

// Sobrescreve habilidades e movimentação próprias do Mago.
internal class Mago : PersonagemBase
{
    public Mago() : base("Mago", "Magia", 80) { }
    public override ResultadoAcao Atacar() => new(20, "O mago ataca com o cajado.");
    public override bool PodeUsarMagia() => getVida() > 0;
    public override ResultadoAcao JogarMagia() => new(25, "O mago lançou uma magia poderosa.");
    public override string Andar(int casas) => $"O Mago flutuou {casas} casas.";
    public override string Fugir() => "O Mago fugiu voando.";
}
