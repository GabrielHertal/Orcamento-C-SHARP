using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orçamento.Data
{
    public class Config
    {
        public string ConnectionString { get; set; }
    }
    public class DbConnect
    {
        private NpgsqlConnection connection;
        private string connectionString;

        public DbConnect(string appsettings)
        {
            LoadConnectionString(appsettings);
            connection = new NpgsqlConnection(connectionString);
        }
        private void LoadConnectionString(string appsettings)
        {
            try
            {
                string json = File.ReadAllText(appsettings);
                Config config = JsonConvert.DeserializeObject<Config>(json);
                connectionString = config.ConnectionString;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Erro ao carregar a string de conexão: {ex.Message}");
            }
        }
    }
}
