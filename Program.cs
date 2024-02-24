using Orçamento.Data;

namespace Orçamento
{ 

    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            using (var dbconnect = new DbConnect())
            ApplicationConfiguration.Initialize();
            Application.Run(new Form_Menu());
        }
    }
}