using Orçamento.Data;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Orçamento
{ 
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            using (var dbconnect = new DbConnect())
            {
                ApplicationConfiguration.Initialize();
                Application.Run(new Form_Menu());
            }
        }
    }
}