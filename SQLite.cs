using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace ScoreCardv2
{
    public static class SQLite
    {
        public static SqliteCommand Command(SqliteConnection con, string query, params (string key, object? value)[] parameters)
        {
            SqliteCommand com = con.CreateCommand();
            com.CommandText = query;
            for (int i = 0; i < parameters.Length; i++)
            {
                com.Parameters.AddWithValue(parameters[i].key, parameters[i].value ?? DBNull.Value);
            }
            return com;
        }

        public static int CreateStructure(SqliteConnection con, string table, string subject, string[] elements)
        {
            // Create structure if one doesn't already exist with all elements contained

            // Find structures with subjects equal to elements, without excess subjects
            List<int> validStructures;

            // Start with all structures
            SqliteCommand com = Command(
                con,
                $@"
                    SELECT DISTINCT id
                    FROM {table}
                ");

            using (SqliteDataReader reader = com.ExecuteReader())
            {
                validStructures = new List<int>();

                while (reader.Read())
                {
                    validStructures.Add(reader.GetInt32(0));
                }
            }

            foreach (string element in elements)
            {
                // Find all team ids that have each person_id in them and are contained within the previous subset returned
                // Concept for multiple parameters in sql query that prevents sql insertion attack found here:
                //      https://stackoverflow.com/questions/2377506/pass-array-parameter-in-sqlcommand
                // To facilitate this technique, the SQLite.Command method is not used

                com = con.CreateCommand();

                // Create parameters and insert into query
                string[] parameters = new string[validStructures.Count];
                
                for (int i = 0; i < parameters.Length; i++)
                {
                    parameters[i] = $"$id{i}";
                    com.Parameters.AddWithValue(parameters[i], validStructures[i]);
                }

                com.CommandText = $@"
                    SELECT id
                    FROM {table}
                    WHERE id IN ({string.Join(", ", parameters)})
                    AND {subject} = $e
                ";

                com.Parameters.AddWithValue("$e", element);

                // Create new list of subjects, eliminating ones that did not contain current player
                using (SqliteDataReader reader = com.ExecuteReader())
                {
                    validStructures = new List<int>();

                    while (reader.Read())
                    {
                        validStructures.Add(reader.GetInt32(0));
                    }
                }

                // Remove subjects without the right amount of elements
                foreach (int teamId in validStructures.ToList())
                {
                    // Get length of subject
                    com = Command(
                        con,
                        @"
                            SELECT COUNT(*)
                            FROM teams
                            WHERE id = $id
                        ",
                        ("$id", teamId));

                    // Remove from list of subjects if it is not of correct length
                    using (SqliteDataReader reader = com.ExecuteReader())
                    {
                        reader.Read();

                        if (reader.GetInt32(0) != elements.Length)
                        {
                            validStructures.Remove(teamId);
                        }
                    }
                }
            }

            int id = validStructures.FirstOrDefault();
            
            // Create new team if none already exists
            if (id == 0)
            {
                // Start transaction to avoid insertions of other values with 1 higher than max id
                using (SqliteTransaction transaction = con.BeginTransaction())
                {
                    com = SQLite.Command(
                    con,
                    $@"
                        SELECT MAX(id)
                        FROM {table}
                    ");

                    using (SqliteDataReader reader = com.ExecuteReader())
                    {
                        reader.Read();

                        // If no other teams exist, id should be 1, otherwise 1 higher than max
                        id = reader.IsDBNull(0) ? 1 : reader.GetInt32(0) + 1;
                    }

                    // Insert each person with the correct team id into teams
                    foreach (string element in elements)
                    {
                        com = Command(
                            con,
                            $@"
                                INSERT INTO {table} (id, {subject})
                                VALUES ($id, $e)
                            ",
                            ("$id", id),
                            ("$e", element));

                        com.ExecuteNonQuery();
                    }

                    // Commit transaction
                    transaction.Commit();
                }
            }

            return id;
        }
    }
}
