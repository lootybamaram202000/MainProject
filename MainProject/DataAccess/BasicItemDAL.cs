using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Xml.Linq;
using MainProject.Core;
using MainProject.Core.Business;
using MainProject.Entities;
using MainProject.Helpers;
using static System.Collections.Specialized.BitVector32;

namespace MainProject.DataAccess
{
    internal class BasicItemDAL
    {
        private readonly string _connectionString = Config.ConnectionString;


        public bool InsertBasicItem(BasicItemModel model, out string newBIID)
        {
            newBIID = null;
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_InsertBasicItem", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BIName", model.BIName ?? "-");
                cmd.Parameters.AddWithValue("@SectionID", model.Section?.SecID ?? "-");
                cmd.Parameters.AddWithValue("@UnitID", model.Unit?.UnitID ?? "-");
                cmd.Parameters.AddWithValue("@Wastage", model.Wastage);
                cmd.Parameters.AddWithValue("@Category", model.Category ?? "-");
                cmd.Parameters.AddWithValue("@USERID", LoginInfo.Instance.UserID);
                cmd.Parameters.AddWithValue("@DATE", LoginInfo.Instance.PersianDate);
                cmd.Parameters.AddWithValue("@DATEVALUE", LoginInfo.Instance.DateValue);
                cmd.Parameters.AddWithValue("@DATEDIG", LoginInfo.Instance.DateDig);

                SqlParameter newIdParam = new SqlParameter("@NewBIID", SqlDbType.NVarChar, 50)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(newIdParam);

                con.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && newIdParam.Value != DBNull.Value)
                {
                    newBIID = newIdParam.Value.ToString();
                    return true;
                }
                return false;
            }
        }

        public bool UpdateBasicItem(BasicItemModel model)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_UpdateBasicItem", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BIID", model.BIID ?? "-");
                cmd.Parameters.AddWithValue("@BIName", model.BIName ?? "-");
                cmd.Parameters.AddWithValue("@SectionID", model.Section?.SecID ?? "-");
                cmd.Parameters.AddWithValue("@UnitID", model.Unit?.UnitID ?? "-");
                cmd.Parameters.AddWithValue("@Wastage", model.Wastage);
                cmd.Parameters.AddWithValue("@Category", model.Category ?? "-");
                cmd.Parameters.AddWithValue("@USERID", LoginInfo.Instance.UserID);
                cmd.Parameters.AddWithValue("@DATE", LoginInfo.Instance.PersianDate);
                cmd.Parameters.AddWithValue("@DATEVALUE", LoginInfo.Instance.DateValue);
                cmd.Parameters.AddWithValue("@DATEDIG", LoginInfo.Instance.DateDig);

                DataTable dt = new DataTable();
                dt.Columns.Add("BIID", typeof(string));
                dt.Columns.Add("RowIndex", typeof(int));
                dt.Columns.Add("PID", typeof(string));
                dt.Columns.Add("PName", typeof(string));
                dt.Columns.Add("Quantity", typeof(int));
                dt.Columns.Add("Cost", typeof(decimal));

                foreach (var r in model.Recipies)
                {
                    dt.Rows.Add(model.BIID, r.RowIndex, r.PID, r.PName, r.Quantity, r.Cost);
                }

                SqlParameter tvpParam = cmd.Parameters.AddWithValue("@Recipies", dt);
                tvpParam.SqlDbType = SqlDbType.Structured;
                tvpParam.TypeName = "dbo.Type_BasicRecipieList";

                con.Open();
                object result = cmd.ExecuteScalar();
                return result != null;
            }
        }

        public bool DeleteBasicItem(string biid)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_DeleteBasicItem", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BIID", biid);
                cmd.Parameters.AddWithValue("@USERID", LoginInfo.Instance.UserID);
                cmd.Parameters.AddWithValue("@DATE", LoginInfo.Instance.PersianDate);
                cmd.Parameters.AddWithValue("@DATEVALUE", LoginInfo.Instance.DateValue);
                cmd.Parameters.AddWithValue("@DATEDIG", LoginInfo.Instance.DateDig);

                con.Open();
                object result = cmd.ExecuteScalar();
                return result != null;
            }
        }


        public List<BasicItemModel> GetAllBasicItems()
        {
            var list = new List<BasicItemModel>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_ReturnFullBasicItems", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(ReadBasicItemFromReader(reader));
                    }
                }
            }
            return list;
        }

        public BasicItemModel GetBasicItemById(string biid)
        {
            BasicItemModel model = null;

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetFullBasicItemByBIID", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BIID", biid);

                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        model = ReadBasicItemFromReader(reader);
                    }
                }
            }

            return model;
        }

        public List<BasicItemModel> SearchBasicItems(string keyword)
        {
            var list = new List<BasicItemModel>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_SearchBasicItems", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SearchValue", keyword);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(ReadBasicItemFromReader(reader));
                }
            }
            return list;
        }

        private BasicItemModel ReadBasicItemFromReader(SqlDataReader reader)
        {
            return new BasicItemModel
            {
                BIID = reader["BIID"].ToString(),
                BIName = reader["BIName"].ToString(),
                Category = reader["Category"].ToString(),

                PricePerUnit = reader["PricePerUnit"] != DBNull.Value ? Convert.ToDecimal(reader["PricePerUnit"]) : 0,
                ProductPrice = reader["ProductPrice"] != DBNull.Value ? Convert.ToDecimal(reader["ProductPrice"]) : 0,
                Wastage = reader["Wastage"] != DBNull.Value ? Convert.ToInt32(reader["Wastage"]) : 0,
                isActive = reader["isActive"] != DBNull.Value && Convert.ToBoolean(reader["isActive"]),

                Unit = new UnitModel
                {
                    UnitID = reader["UnitID"].ToString(),
                    MeasurmentUnitTitle = reader["MeasurmentUnitTitle"].ToString(),
                    PunitTitle = reader["PunitTitle"].ToString(),
                    MesurmentUnitQuantity = reader["MesurmentUnitQuantity"] != DBNull.Value
                        ? Convert.ToInt32(reader["MesurmentUnitQuantity"])
                        : 1
                },
                Section = new SectionModel
                {
                    SecID = reader["SectionID"].ToString(),
                    SecTitle = reader["SecTitle"].ToString(),
                    OverHead = reader["OverHead"] != DBNull.Value ? Convert.ToDecimal(reader["OverHead"]) : 0,
                    PerCentage = reader["PerCentage"] != DBNull.Value ? Convert.ToByte(reader["PerCentage"]) : (byte)0,
                    CountOfSell = reader["CountOfSell"] != DBNull.Value ? Convert.ToInt16(reader["CountOfSell"]) : (short)0
                }
            };
        }
        public List<BasicRecipieModel> GetRecipiesByBIID(string biid)
        {
            var recipies = new List<BasicRecipieModel>();
            var allProducts = new ProductManager().GetAllProducts();

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_ReturnRecipieFullByBIID", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BIID", biid);

                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string pid = reader["PID"]?.ToString();
                        ProductModel product = allProducts.FirstOrDefault(p => p.ProductID == pid);

                        recipies.Add(new BasicRecipieModel
                        {
                            RowIndex = reader["RowIndex"] != DBNull.Value ? Convert.ToInt32(reader["RowIndex"]) : 0,
                            Quantity = reader["Quantity"] != DBNull.Value ? Convert.ToInt32(reader["Quantity"]) : 0,
                            Cost = reader["Cost"] != DBNull.Value ? Convert.ToDecimal(reader["Cost"]) : 0,
                            Product = product,
                            PID = pid,
                            PName = reader["PName"]?.ToString(),
                            BIID = biid
                        });
                    }
                }
            }

            return recipies;
        }

        public bool SubmitRecipie(string biid, string biName, List<BasicRecipieModel> recipies)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("BIID", typeof(string));
            dt.Columns.Add("RowIndex", typeof(int));
            dt.Columns.Add("PID", typeof(string));
            dt.Columns.Add("PName", typeof(string));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("Cost", typeof(decimal));

            int i = 1;

            foreach (var r in recipies)
            {
                if (r.Product != null) // فقط سطرهایی که کالا دارند ثبت شوند
                {
                    dt.Rows.Add(biid, r.RowIndex, r.Product.ProductID, r.Product.ProductName, r.Quantity, r.Cost);
                    i++;
                }
            }

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_SubmitBasicRecipie", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BIID", biid);

                SqlParameter tvpParam = cmd.Parameters.AddWithValue("@Recipies", dt);
                tvpParam.SqlDbType = SqlDbType.Structured;
                tvpParam.TypeName = "dbo.Type_BasicRecipieList";

                con.Open();
                object result = cmd.ExecuteScalar();
                return result != null;
            }
        }
    }
}
