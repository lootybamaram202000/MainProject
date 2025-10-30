using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainProject.Core;
using MainProject.Entities;
using MainProject.Helpers;

namespace MainProject.DataAccess
{
    public class ItemDAL
    {
        private readonly string _connectionString = Config.ConnectionString;

        public List<ItemModel> GetAllItems()
        {
            var items = new List<ItemModel>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_ReturnFullItems", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    items.Add(new ItemModel
                    {
                        ItemID = dr["ItemID"].ToString(),
                        ItemName = dr["ItemName"].ToString(),
                        Category = dr["Category"].ToString(),
                        Section = new SectionModel
                        {
                            SecID = dr["SecID"].ToString(),
                            SecTitle = dr["SecTitle"].ToString(),
                            OverHead = dr["OverHead"] != DBNull.Value ? Convert.ToDecimal(dr["OverHead"]) : 0,
                            PerCentage = Convert.ToByte(dr["PerCentage"]),
                            CountOfSell = Convert.ToInt16(dr["CountOfSell"]),
                        
                        },
                        MaterialCost = Convert.ToDecimal(dr["MaterialCost"]),
                        CostAndOH = Convert.ToDecimal(dr["CostAndOH"]),
                        PreferredPrice = Convert.ToDecimal(dr["PreferredPrice"]),
                        SellPrice = Convert.ToDecimal(dr["SellPrice"]),
                        LastUpdate = dr["LastUpdate"].ToString(),
                        isDeleted = Convert.ToBoolean(dr["isDeleted"]),
                        isActive = Convert.ToBoolean(dr["isActive"]),
                        DATEDIG = Convert.ToInt32(dr["DATEDIG"])
                    });
                }
            }
            return items;
        }

        public List<ItemModel> SearchItems(string keyword)
        {
            var result = new List<ItemModel>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_SearchItems", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SearchValue", keyword);
                con.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    result.Add(new ItemModel
                    {
                        ItemID = dr["ItemID"].ToString(),
                        ItemName = dr["ItemName"].ToString(),
                        Category = dr["Category"].ToString(),
                        Section = new SectionModel
                        {
                            SecID = dr["SecID"].ToString(),
                            SecTitle = dr["SecTitle"].ToString(),
                            OverHead = Convert.ToInt32(dr["OverHead"]),
                            PerCentage = Convert.ToByte(dr["PerCentage"]),
                            CountOfSell = Convert.ToInt16(dr["CountOfSell"]),

                        },
                        MaterialCost = Convert.ToDecimal(dr["MaterialCost"]),
                        CostAndOH = Convert.ToDecimal(dr["CostAndOH"]),
                        PreferredPrice = Convert.ToDecimal(dr["PreferredPrice"]),
                        SellPrice = Convert.ToDecimal(dr["SellPrice"]),
                        LastUpdate = dr["LastUpdate"].ToString(),
                        isDeleted = Convert.ToBoolean(dr["isDeleted"]),
                        isActive = Convert.ToBoolean(dr["isActive"]),
                        DATEDIG = Convert.ToInt32(dr["DATEDIG"])
                    });
                }
            }
            return result;
        }

        public List<ItemRecipieModel> GetItemRecipies(string itemID)
        {
            var list = new List<ItemRecipieModel>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_ReturnRecipieFullByItemID", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ItemID", itemID);
                con.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new ItemRecipieModel
                    {
                        RowIndex = Convert.ToInt32(dr["RowIndex"]),
                        ItemID = itemID,
                        BIID = dr["BIID"].ToString(),
                        BIName = dr["BIName"].ToString(),
                        Quantity = Convert.ToInt32(dr["Quantity"]),
                        Cost = Convert.ToDecimal(dr["Cost"])
                    });
                }
            }
            return list;
        }

        public bool InsertItem(ItemModel model, out string newID)
        {
            newID = null;
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_InsertItem", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ItemName", model.ItemName);
                cmd.Parameters.AddWithValue("@Category", model.Category);
                cmd.Parameters.AddWithValue("@SecID", model.Section?.SecID);
                cmd.Parameters.AddWithValue("@SellPrice", model.SellPrice);
                cmd.Parameters.AddWithValue("@USERID", LoginInfo.Instance.UserID);
                cmd.Parameters.AddWithValue("@DATE", LoginInfo.Instance.PersianDate);
                cmd.Parameters.AddWithValue("@DATEVALUE", LoginInfo.Instance.DateValue);
                cmd.Parameters.AddWithValue("@DATEDIG", LoginInfo.Instance.DateDig);

                // پارامتر خروجی برای گرفتن کد جدید آیتم
                var outParam = new SqlParameter("@NewItemID", SqlDbType.NVarChar, 50)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outParam);

                con.Open();
                cmd.ExecuteNonQuery();

                // بدون شرط سختگیرانه - مثل BasicItem
                newID = outParam.Value?.ToString();
                return true;
            }
        }


        public bool SubmitRecipie(string itemID, List<ItemRecipieModel> recipies, decimal? sellPrice = null)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_SubmitRecipie", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ItemID", itemID);
                cmd.Parameters.AddWithValue("@SellPrice", (object)sellPrice ?? DBNull.Value);

                var tvp = new DataTable();
                tvp.Columns.Add("ItemID", typeof(string));
                tvp.Columns.Add("RowIndex", typeof(int));
                tvp.Columns.Add("BIID", typeof(string));
                tvp.Columns.Add("BIName", typeof(string));
                tvp.Columns.Add("Quantity", typeof(int));
                tvp.Columns.Add("Cost", typeof(decimal));

                foreach (var r in recipies)
                    tvp.Rows.Add(itemID, r.RowIndex, r.BIID, r.BIName, r.Quantity, r.Cost);

                var param = cmd.Parameters.AddWithValue("@Recipies", tvp);
                param.SqlDbType = SqlDbType.Structured;
                param.TypeName = "dbo.Type_ItemRecipieList";

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateItem(ItemModel model, List<ItemRecipieModel> recipies, decimal? sellPrice = null)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_UpdateItem", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ItemID", model.ItemID);
                cmd.Parameters.AddWithValue("@ItemName", model.ItemName);
                cmd.Parameters.AddWithValue("@Category", model.Category);
                cmd.Parameters.AddWithValue("@SecID", model.Section?.SecID);
                cmd.Parameters.AddWithValue("@SellPrice", (object)sellPrice ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@USERID", LoginInfo.Instance.UserID);
                cmd.Parameters.AddWithValue("@DATE", LoginInfo.Instance.PersianDate);
                cmd.Parameters.AddWithValue("@DATEVALUE", LoginInfo.Instance.DateValue);
                cmd.Parameters.AddWithValue("@DATEDIG", LoginInfo.Instance.DateDig);

                var tvp = new DataTable();
                tvp.Columns.Add("ItemID", typeof(string));
                tvp.Columns.Add("RowIndex", typeof(int));
                tvp.Columns.Add("BIID", typeof(string));
                tvp.Columns.Add("BIName", typeof(string));
                tvp.Columns.Add("Quantity", typeof(int));
                tvp.Columns.Add("Cost", typeof(decimal));

                foreach (var r in recipies)
                    tvp.Rows.Add(model.ItemID, r.RowIndex, r.BIID, r.BIName, r.Quantity, r.Cost);

                var param = cmd.Parameters.AddWithValue("@Recipies", tvp);
                param.SqlDbType = SqlDbType.Structured;
                param.TypeName = "dbo.Type_ItemRecipieList";

                con.Open();
                object result = cmd.ExecuteScalar();  // ✅ مشابه با BasicItem
                return result != null;
            }
        }

        public bool DeleteItem(string itemID)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_DeleteItem", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ItemID", itemID);
                cmd.Parameters.AddWithValue("@USERID", LoginInfo.Instance.UserID);
                cmd.Parameters.AddWithValue("@DATE", LoginInfo.Instance.PersianDate);
                cmd.Parameters.AddWithValue("@DATEVALUE", LoginInfo.Instance.DateValue);
                cmd.Parameters.AddWithValue("@DATEDIG", LoginInfo.Instance.DateDig);

                con.Open();
                object result = cmd.ExecuteScalar();  // ✅ اصلاح‌شده
                return result != null;
            }
        }
    }
}
