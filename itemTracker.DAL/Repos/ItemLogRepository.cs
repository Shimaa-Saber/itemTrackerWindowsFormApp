using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taskForTrackItem.Models.Models;

namespace itemTracker.DAL.Repos
{
    public class ItemLogRepository
    {
        public void AddLog(ItemLog log)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO ItemLogs 
                                (ItemID, FieldChanged, OldValue, NewValue, ModifiedBy, ModifiedAt)
                                 VALUES 
                                (@ItemID, @FieldChanged, @OldValue, @NewValue, @ModifiedBy, @ModifiedAt)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ItemID", log.ItemID);
                    cmd.Parameters.AddWithValue("@FieldChanged", log.FieldChanged);
                    cmd.Parameters.AddWithValue("@OldValue", (object)log.OldValue ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NewValue", (object)log.NewValue ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ModifiedBy", log.ModifiedBy);
                    cmd.Parameters.AddWithValue("@ModifiedAt", log.ModifiedAt);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ItemLog> GetLogs()
        {
            var logs = new List<ItemLog>();

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT LogID, ItemID,FieldChanged,OldValue,NewValue ,ModifiedBy,ModifiedAt FROM ItemLogs ORDER BY ModifiedAt DESC";
                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        logs.Add(new ItemLog
                        {
                            LogID = (int)reader["LogID"],
                            ItemID = (int)reader["ItemID"],
                            FieldChanged = reader["FieldChanged"].ToString(),
                            OldValue = reader["OldValue"].ToString(),
                            NewValue = reader["NewValue"].ToString(),
                            ModifiedBy = (int)reader["ModifiedBy"],
                            ModifiedAt = Convert.ToDateTime(reader["ModifiedAt"])
                        });
                    }
                }
            }

            return logs;
        }

        public List<ItemLog> GetAllLogsWithDetails()
        {
            var logs = new List<ItemLog>();

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var query = @"
            SELECT l.LogID, l.ItemID, l.ActionType, l.ActionDate,
                   u.Username AS UserName, i.ItemName AS ItemName
            FROM ItemLogs l
            JOIN Users u ON l.UserID = u.UserID
            JOIN Items i ON l.ItemID = i.ItemID
            ORDER BY l.ActionDate DESC";

                var cmd = new SqlCommand(query, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    logs.Add(new ItemLog
                    {
                        LogID = (int)reader["LogID"],
                        ItemID = (int)reader["ItemID"],
                        ItemName = reader["ItemName"].ToString(),
                        ActionType = reader["ActionType"].ToString(),
                        ActionDate = (DateTime)reader["ActionDate"],
                        UserName = reader["UserName"].ToString()
                    });
                }
            }

            return logs;
        }

    }
}
