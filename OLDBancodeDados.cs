using FirebirdSql.Data.FirebirdClient;

namespace Orçamento
{
    public class OLDBancodeDados
    {
        private string str_conexao;
        public FbConnection conexao = new FbConnection();
        public FbCommand comando = new FbCommand();
        public FbDataReader dados;

        public OLDBancodeDados()
        {
            str_conexao = @"User=SYSDBA;Password=masterkey;Database=C:\Users\Gabriel\Desktop\Projeto orçamento C#\Orçamento\bin\Debug\net8.0-windows\ORCAMENTO.FDB;DataSource=localhost;Port=3050;";
        }

        public void conectar()
        {
            try
            {
                conexao.ConnectionString = str_conexao;
                conexao.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao conectar ao banco de dados: {ex.Message}", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void desconectar()
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }
        public void executar(string sql)
        {
            try
            {
                comando.Connection = conexao;
                comando.CommandText = sql;
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao executar comando SQL: {ex.Message}", "Erro de conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public FbDataReader Consultar(string sql)
        {
            try
            {
                comando.Connection = conexao;
                comando.CommandText = sql;
                dados = comando.ExecuteReader();
                return dados;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Erro ao consultar o banco de dados: {e.Message}", "Erro ao consultar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public bool VerificaCPF(string documento)
        {
            try
            {
                conectar();
                string sql = $"SELECT COUNT(*) FROM clientes WHERE documento = '{documento}'";
                comando.Connection = conexao;
                comando.CommandText = sql;
                int count = Convert.ToInt32(comando.ExecuteScalar());
                return count > 0;
                desconectar();
            }
            catch (Exception e)
            {
                MessageBox.Show($"Erro ao verificar Documento no Banco de Dados: {e.Message}", "Erro ao verificar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }
}
