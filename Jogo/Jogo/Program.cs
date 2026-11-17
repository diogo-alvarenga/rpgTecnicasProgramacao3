using Jogo.Controller;
using Jogo.View;

class Program
{
    public static void Main(string[] args)
    {
        // Monta o MVC: a View é entregue ao Controller,
        // e o Controller usa os objetos do Model.
        // Composição inicial: a interface é criada fora do controlador.
        JogoView view = new JogoView();
        // Injeção da mesma View no controlador principal.
        JogoController controller = new JogoController(view);
        controller.Iniciar();
    }
}
