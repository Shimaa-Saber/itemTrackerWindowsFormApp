using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taskForTrackItem.Models.Models;

namespace itemTracker.DAL.Repos
{
    public class ItemRepository
    {
        public void AddItem(Item item)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO Items 
                                (ItemName, ImagePath, Size, Type, Description, UnitID, CreatedBy) 
                                 VALUES 
                                (@ItemName, @ImagePath, @Size, @Type, @Description, @UnitID, @CreatedBy)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ItemName", item.ItemName);
                    cmd.Parameters.AddWithValue("@ImagePath", item.ImagePath ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Size", item.Size ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Type", item.Type ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Description", item.Description ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@UnitID", item.UnitID);
                    cmd.Parameters.AddWithValue("@CreatedBy", item.CreatedBy);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateItem(Item item)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE Items SET 
                                    ItemName = @ItemName,
                                    ImagePath = @ImagePath,
                                    Size = @Size,
                                    Type = @Type,
                                    Description = @Description,
                                    UnitID = @UnitID
                                 WHERE ItemID = @ItemID";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ItemName", item.ItemName);
                    cmd.Parameters.AddWithValue("@ImagePath", item.ImagePath ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Size", item.Size ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Type", item.Type ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Description", item.Description ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@UnitID", item.UnitID);
                    cmd.Parameters.AddWithValue("@ItemID", item.ItemID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Item GetItemById(int id)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Items WHERE ItemID = @ItemID";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ItemID", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Item
                            {
                                ItemID = (int)reader["ItemID"],
                                ItemName = reader["ItemName"].ToString(),
                                ImagePath = reader["ImagePath"].ToString(),
                                Size = reader["Size"].ToString(),
                                Type = reader["Type"].ToString(),
                                Description = reader["Description"].ToString(),
                                UnitID = Convert.ToInt32(reader["UnitID"]),
                                CreatedBy = Convert.ToInt32(reader["CreatedBy"]),
                                CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<Item> GetAllItems()
        {
            var items = new List<Item>();

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Items";
                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(new Item
                        {
                            ItemID = (int)reader["ItemID"],
                            ItemName = reader["ItemName"].ToString(),
                            ImagePath = reader["ImagePath"].ToString(),
                            Size = reader["Size"].ToString(),
                            Type = reader["Type"].ToString(),
                            Description = reader["Description"].ToString(),
                            UnitID = Convert.ToInt32(reader["UnitID"]),
                            CreatedBy = Convert.ToInt32(reader["CreatedBy"]),
                            CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                        });
                    }
                }
            }

            return items;
        }
    }
}
