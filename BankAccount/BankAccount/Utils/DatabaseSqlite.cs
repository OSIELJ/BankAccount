using Microsoft.Data.Sqlite;
using BankAccount.Models;

namespace BankAccount.Utils
{
    public static class DatabaseSqlite
    {
        private static readonly string _connectionString = "Data Source=bankaccount.db";

        public static void Initialize()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Accounts (
                    Number      INTEGER PRIMARY KEY,
                    Owner       TEXT NOT NULL,
                    Balance     REAL NOT NULL,
                    Type        INTEGER NOT NULL,
                    [Limit]     REAL NOT NULL DEFAULT 0,
                    Anniversary INTEGER NOT NULL DEFAULT 0
                );";
            command.ExecuteNonQuery();
        }

        public static void Save(Account account)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                INSERT OR REPLACE INTO Accounts 
                    (Number, Owner, Balance, Type, [Limit], Anniversary)
                VALUES 
                    ($number, $owner, $balance, $type, $limit, $anniversary);";

            command.Parameters.AddWithValue("$number", account.Number);
            command.Parameters.AddWithValue("$owner", account.Owner);
            command.Parameters.AddWithValue("$balance", account.Balance);
            command.Parameters.AddWithValue("$type", account.Type);
            command.Parameters.AddWithValue("$limit",
                account is CheckingAccount ca ? ca.Limit : 0);
            command.Parameters.AddWithValue("$anniversary",
                account is SavingsAccount sa ? sa.Anniversary : 0);

            command.ExecuteNonQuery();
        }

        public static void Delete(int number)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Accounts WHERE Number = $number;";
            command.Parameters.AddWithValue("$number", number);
            command.ExecuteNonQuery();
        }

        public static List<Account> LoadAll()
        {
            var accounts = new List<Account>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Accounts ORDER BY Number;";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                int number = reader.GetInt32(0);
                string owner = reader.GetString(1);
                decimal balance = (decimal)reader.GetDouble(2);
                int type = reader.GetInt32(3);
                decimal limit = (decimal)reader.GetDouble(4);
                int anniversary = reader.GetInt32(5);

                Account account = type == 1
                    ? new CheckingAccount(owner, balance, limit)
                    : new SavingsAccount(owner, balance, anniversary);

                account.SetNumber(number);
                accounts.Add(account);
            }

            return accounts;
        }
    }
}