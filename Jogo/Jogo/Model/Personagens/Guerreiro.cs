namespace Jogo.Model.Personagens;

// Especializa somente o ataque; demais regras vêm da base.
internal class Guerreiro : PersonagemBase
{
    public Guerreiro() : base("Guerreiro", "Espada", 100) { }
    public override ResultadoAcao Atacar() => new(15, "O guerreiro atacou com a espada.");
}
