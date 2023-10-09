using CineConsole.Presentacion;
using Infrastructure;



public  class Program
{
    public static void Main(string[] args)
    {
        var context = new CineDdContext();
        var cineApp = new CineApplication(context);
        cineApp.Run();
    }
}