using Microsoft.Data.SqlClient;
using System.Data;

namespace WebApi.Data_Access
{
    public class Connection
    {
        private static Connection instance;
        private static readonly object lockObject = new object();
        private readonly string connectionString;
        private SqlConnection connection;

        private Connection()
        {
            connectionString = "Server=tcp:cinepacho-server.database.windows.net,1433;Initial Catalog=DB_CINEPACHO;Persist Security Info=False;User ID=ADMIN_CINEPACHO;Password= cine2023PACHO;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            connection = new SqlConnection(connectionString);
        }

        public static Connection Instance
        {
            get
            {
                // Utilizar bloqueo para asegurar la creación de una única instancia en entornos multi-hilo
                lock (lockObject)
                {
                    // Crear la instancia solo si no existe
                    if (instance == null)
                    {
                        instance = new Connection();
                    }
                }

                return instance;
            }
        }
        public SqlConnection Conectar
        {
            get { return connection; }
        }

        public void Open()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void Close()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        // Otros métodos relacionados con la conexión a la base de datos
    }
}

