using System.Data.SqlClient;


namespace SistemaProvas.BD
{
    public class SqlConn
    {
        public static SqlConnection Abrir()
        {
            string str = System.Configuration.ConfigurationManager.ConnectionStrings["Conexao"].ConnectionString;
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            return conn;
        }
    }
}