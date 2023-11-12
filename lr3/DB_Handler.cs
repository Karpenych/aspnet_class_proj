using Microsoft.AspNetCore.Http;
using NuGet.Protocol.Plugins;
using System.Data.SqlClient;


namespace lr3
{
    public static class DB_Handler
    {
        public static List<string> ReadTableData(string connectionString, string queryString)
        {
            var answ = new List<string>();

            using SqlConnection connection = new(connectionString);
            SqlCommand command = new(queryString, connection);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string datastr = "";

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    datastr += reader[i] + ",";
                }

                answ.Add(datastr.TrimEnd(','));
            }

            return answ;
        }
    }
}
