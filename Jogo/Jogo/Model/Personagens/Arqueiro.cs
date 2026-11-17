namespace Jogo.Model.Personagens;

// Especializa somente o ataque; demais regras vêm da base.
internal class Arqueiro : PersonagemBase
{
    public Arqueiro() : base("Arqueiro", "Arco", 70) { }
    public override ResultadoAcao Atacar() => new(18, "O arqueiro lançou uma flecha.");
}
