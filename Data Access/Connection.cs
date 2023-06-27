using Microsoft.Data.SqlClient;

namespace WebApi.Data_Access
{
    public class Connection
    {

        public static string coneccion = "Server=tcp:cinepacho-server.database.windows.net,1433;Initial Catalog=DB_CINEPACHO;Persist Security Info=False;User ID=ADMIN_CINEPACHO;Password= cine2023PACHO;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static SqlConnection conectar = new SqlConnection(coneccion);

        public static void abrir()
        {
            if (conectar.State == System.Data.ConnectionState.Closed)
            {
                conectar.Open();
            }
        }

        public static void cerrar()
        {
            if (conectar.State == System.Data.ConnectionState.Open)
            {
                conectar.Close();
            }
        }
    }
}
