using Jogo.Model.Personagens;

namespace Jogo.Model.Padroes
{
    // PADRÃO PROXY (fica no MODEL, pois protege o acesso ao personagem).
    // Protection Proxy: implementa a mesma interface do personagem real
    // e só deixa a ação acontecer se ela for permitida.
    // Ele não escreve na tela: devolve a mensagem de erro para quem chamou.
    internal class Proxy : InterfacePersonagem
    {
        // Mesmo contrato do objeto real; referência mantida para delegação.
        private readonly InterfacePersonagem personagem;

        public Proxy(InterfacePersonagem personagem)
        {
            this.personagem = personagem;
        }

        // Retorna null se a ação for permitida, ou a mensagem do motivo.
        // Proteção de acesso: valida a ação antes de encaminhá-la.
        public string? Verificar(int opc)
        {
            if (personagem.getVida() <= 0)
            {
                return "O personagem está morto.";
            }
            if (opc < 1 || opc > 3)
            {
                return "Opção inválida.";
            }
            if (opc == 1 && !personagem.PodeAtacar())
            {
                return "O personagem não pode atacar agora.";
            }
            if (opc == 2 && !personagem.PodeUsarMagia())
            {
                return "Esse personagem não pode usar magia.";
            }
            return null;
        }

        // A ação autorizada é delegada; o Proxy não calcula dano.
        public ResultadoAcao Atacar()
        {
            string? erro = Verificar(1);
            return erro == null ? personagem.Atacar() : new ResultadoAcao(0, erro);
        }

        public ResultadoAcao JogarMagia()
        {
            string? erro = Verificar(2);
            return erro == null ? personagem.JogarMagia() : new ResultadoAcao(0, erro);
        }

        public string Fugir()
        {
            string? erro = Verificar(3);
            return erro ?? personagem.Fugir();
        }

        public string Andar(int casas) => personagem.Andar(casas);
        public void ReceberDano(int dano) => personagem.ReceberDano(dano);
        public void SetVeneno(int dano) => personagem.SetVeneno(dano);
        public int GetVeneno() => personagem.GetVeneno();
        public int getVida() => personagem.getVida();
        public string getNome() => personagem.getNome();
        public string getArma() => personagem.getArma();
        public bool PodeAtacar() => personagem.PodeAtacar();
        public bool PodeUsarMagia() => personagem.PodeUsarMagia();
    }
}
