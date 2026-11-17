namespace Jogo.Model
{
    // MODEL: resultado de uma ação do personagem.
    // O Model não escreve nada na tela; ele apenas devolve os dados
    // (dano causado + mensagem) para o Controller entregar à View.
    // Objeto de retorno: transporta dados da ação até a apresentação.
    internal class ResultadoAcao
    {
        public int Dano { get; }
        public string Mensagem { get; }

        public ResultadoAcao(int dano, string mensagem)
        {
            Dano = dano;
            Mensagem = mensagem;
        }
    }
}
