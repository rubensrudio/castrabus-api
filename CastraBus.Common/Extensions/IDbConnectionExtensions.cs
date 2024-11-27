using System.Data;

namespace CastraBus.Common.Extensions
{
    public static class IDbConnectionExtensions
    {
        public static void RefreshConnection(this IDbConnection connection)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public static IDataReader QueryDataReader(this IDbConnection connection, string query, object parameters = null, IDbTransaction transaction = null)
        {
            Console.WriteLine("QueryDataReader", connection, query, parameters, transaction);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            using (var command = connection.CreateCommand())
            {
                if (parameters != null)
                {
                    command.SetParameters(parameters);
                }
                if (transaction != null)
                {
                    command.Transaction = transaction;
                }

                command.CommandText = query;

                IDataReader reader = command.ExecuteReader();

                return reader;
            }
        }

        private static void SetParameters(this IDbCommand command, object parameters)
        {
            var typ = parameters.GetType();
            var properties = typ.GetProperties();
            if (properties != null)
            {
                foreach (var prop in properties)
                {
                    var value = prop.GetValue(parameters);
                    IDbDataParameter dbParam = command.CreateParameter();

                    dbParam.Value = value ?? DBNull.Value;
                    //todo: pode testar o tipo pra usar o tipo
                    //if (prop.PropertyType.Name = "") ....
                    command.Parameters.Add(dbParam);
                }
            }
        }
    }
}
