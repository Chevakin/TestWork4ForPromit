using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWork4ForPromit.Domain
{
    public static class PromitDbContextFactory
    {
        private static string _connectionString;

        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    _connectionString = GetConnectionString();
                }

                return _connectionString;
            }
        }

        private static string GetConnectionString()
        {
            do
            {
                Console.WriteLine("Введите, пожалуйста, строку подключения к MS SQL Server:");

                var connectionString = Console.ReadLine();

                try
                {
                    var con = new SqlConnectionStringBuilder(connectionString);
                }
                catch (Exception)
                {
                    Console.WriteLine("Строка подключения некорректна");

                    continue;
                }

                SqlConnection myConnection = new SqlConnection(connectionString);

                try
                {
                    myConnection.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Не удалось подключиться к БД. \nСообщение: {ex.Message}\nHR:{ex.HResult}");

                    continue;
                }
                finally
                {
                    myConnection.Dispose();
                }

                return connectionString;
            } while (true);
        }

        public static PromitDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder()
                .UseSqlServer(ConnectionString)
                .Options;

            return new PromitDbContext(options);
        }
    }
}
