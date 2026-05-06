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
                    Number       INTEGER PRIMARY KEY,
                    Agency       TEXT NOT NULL DEFAULT '001',
                    Owner        TEXT NOT NULL,
                    Balance      REAL NOT NULL,
                    Type         INTEGER NOT NULL,
                    [Limit]      REAL NOT NULL DEFAULT 0,
                    Anniversary  INTEGER NOT NULL DEFAULT 0,
                    PasswordHash TEXT NOT NULL DEFAULT ''
                );";
            command.ExecuteNonQuery();

            TryAddColumn(connection, "Agency", "TEXT NOT NULL DEFAULT '001'");
            TryAddColumn(connection, "PasswordHash", "TEXT NOT NULL DEFAULT ''");
        }

        private static void TryAddColumn(SqliteConnection connection, string column, string definition)
        {
            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = $"ALTER TABLE Accounts ADD COLUMN {column} {definition};";
                cmd.ExecuteNonQuery();
            }
            catch { }
        }

        public static void Save(Account account)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                INSERT OR REPLACE INTO Accounts 
                    (Number, Agency, Owner, Balance, Type, [Limit], Anniversary, PasswordHash)
                VALUES 
                    ($number, $agency, $owner, $balance, $type, $limit, $anniversary, $passwordHash);";

            command.Parameters.AddWithValue("$number", account.Number);
            command.Parameters.AddWithValue("$agency", account.Agency);
            command.Parameters.AddWithValue("$owner", account.Owner);
            command.Parameters.AddWithValue("$balance", account.Balance);
            command.Parameters.AddWithValue("$type", account.Type);
            command.Parameters.AddWithValue("$limit",
                account is CheckingAccount ca ? ca.Limit : 0);
            command.Parameters.AddWithValue("$anniversary",
                account is SavingsAccount sa ? sa.Anniversary : 0);
            command.Parameters.AddWithValue("$passwordHash", account.PasswordHash);

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
            command.CommandText = "SELECT Number, Agency, Owner, Balance, Type, [Limit], Anniversary, PasswordHash FROM Accounts ORDER BY Number;";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                int number = reader.GetInt32(0);
                string agency = reader.GetString(1);
                string owner = reader.GetString(2);
                decimal balance = (decimal)reader.GetDouble(3);
                int type = reader.GetInt32(4);
                decimal limit = (decimal)reader.GetDouble(5);
                int anniversary = reader.GetInt32(6);
                string passwordHash = reader.GetString(7);

                Account account = type == 1
                    ? new CheckingAccount(owner, balance, limit, agency)
                    : new SavingsAccount(owner, balance, anniversary, agency);

                account.SetNumber(number);
                account.SetPasswordHash(passwordHash);
                accounts.Add(account);
            }

            return accounts;
        }
    }
}