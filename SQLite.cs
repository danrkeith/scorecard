using Microsoft.Data.Sqlite;

namespace ScoreCardv2
{
    public static class SQLite
    {
        public static SqliteCommand Command(SqliteConnection connection, string query, params (string key, object value)[] parameters)
        {
            SqliteCommand command = connection.CreateCommand();
            command.CommandText = query;
            for (int i = 0; i < parameters.Length; i++)
            {
                command.Parameters.AddWithValue(parameters[i].key, parameters[i].value);
            }
            return command;
        }
    }
}
