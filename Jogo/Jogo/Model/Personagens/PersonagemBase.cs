namespace Jogo.Model.Personagens;

// Reúne as regras compartilhadas pelos três personagens.
// Herança concentra estado e comportamento compartilhados.
internal abstract class PersonagemBase : InterfacePersonagem
{
    private int vida;
    private int veneno;
    protected string Nome { get; }
    protected string Arma { get; }

    protected PersonagemBase(string nome, string arma, int vida)
    {
        Nome = nome;
        Arma = arma;
        this.vida = vida;
    }

    public int getVida() => vida;
    public string getNome() => Nome;
    public string getArma() => Arma;
    public void ReceberDano(int dano) => vida = Math.Max(0, vida - dano);
    public void SetVeneno(int dano) => veneno = dano;
    public int GetVeneno() => veneno;
    public bool PodeAtacar() => vida > 0;
    public virtual bool PodeUsarMagia() => false;
    public virtual ResultadoAcao JogarMagia() => new(0, $"O {Nome.ToLower()} não pode usar magia.");
    public virtual string Andar(int casas) => $"O {Nome.ToLower()} andou {casas} casas.";
    public virtual string Fugir() => $"O {Nome} fugiu.";
    // Ataque é obrigatório e específico de cada classe concreta.
    public abstract ResultadoAcao Atacar();
}
