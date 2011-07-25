using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Liquibase.Runner.MSBuild.Test
{
    public class TestHelper
    {
        public static void ClearDb()
        {
            var sql = @"drop TABLE IF EXISTS databasechangelog;
                        drop TABLE IF EXISTS databasechangeloglock;
                        drop TABLE IF EXISTS animal;";

            ExecuteCommand(sql);
        }

        public static void ExecuteCommand(string sqlCommand)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                var cm = new MySqlCommand(sqlCommand, connection);

                cm.ExecuteNonQuery();

                connection.Close();
            };
        }
    }
}
