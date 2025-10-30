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
    internal class ProductDAL
    {
        private readonly string _connectionString = Config.ConnectionString;

        public bool InsertProduct(ProductModel product, string userID, string persianDate, DateTime dateValue, int dateDig, out string newProductID)
        {
            newProductID = null;

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_InsertProduct", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Pname", product.ProductName ?? "-");
                cmd.Parameters.AddWithValue("@UnitID", product.Unit?.UnitID ?? "-");
                cmd.Parameters.AddWithValue("@PurchasePriceUnit", Convert.ToDecimal(product.PurchasePriceUnit ?? 0));
                cmd.Parameters.AddWithValue("@Wastage", Convert.ToInt32(product.Wastage ?? 0));
                cmd.Parameters.AddWithValue("@SecID", product.Section?.SecID ?? "-");
                cmd.Parameters.AddWithValue("@LastUpdate", product.LastUpdate ?? persianDate);
                cmd.Parameters.AddWithValue("@CriticalInventory", Convert.ToInt32(product.CriticalInventory ?? 0));
                cmd.Parameters.AddWithValue("@SellerID", product.Seller?.SellerID ?? "-");
                cmd.Parameters.AddWithValue("@Type", product.Type ?? "-");
                cmd.Parameters.AddWithValue("@Category", product.Category ?? "-");
                cmd.Parameters.AddWithValue("@isActive", product.IsActive);
                cmd.Parameters.AddWithValue("@IsDirectUse", product.IsDirectUse);
                cmd.Parameters.AddWithValue("@DATEDIG", dateDig);
                cmd.Parameters.AddWithValue("@DATEVALUE", dateValue);
                cmd.Parameters.AddWithValue("@UserID", userID ?? "-");

                SqlParameter newIdParam = new SqlParameter("@NewProductID", SqlDbType.NVarChar, 50)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(newIdParam);

                con.Open();
                cmd.ExecuteScalar();

                if (newIdParam.Value != null)
                {
                    newProductID = newIdParam.Value.ToString();
                    return true;
                }

                return false;
            }
        }

        public bool UpdateProduct(ProductModel product)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_UpdateProduct", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PID", product.ProductID ?? "-");
                cmd.Parameters.AddWithValue("@Pname", product.ProductName ?? "-");
                cmd.Parameters.AddWithValue("@UnitID", product.Unit?.UnitID ?? "-");
                cmd.Parameters.AddWithValue("@PurchasePriceUnit", product.PurchasePriceUnit ?? 0);
                cmd.Parameters.AddWithValue("@Wastage", product.Wastage ?? 0);
                cmd.Parameters.AddWithValue("@SecID", product.Section?.SecID ?? "-");
                cmd.Parameters.AddWithValue("@LastUpdate", product.LastUpdate ?? LoginInfo.Instance.PersianDate);
                cmd.Parameters.AddWithValue("@CriticalInventory", product.CriticalInventory ?? 0);
                cmd.Parameters.AddWithValue("@SellerID", product.Seller?.SellerID ?? "-");
                cmd.Parameters.AddWithValue("@Type", product.Type ?? "-");
                cmd.Parameters.AddWithValue("@Category", product.Category ?? "-");
                cmd.Parameters.AddWithValue("@isActive", product.IsActive);
                cmd.Parameters.AddWithValue("@IsDirectUse", product.IsDirectUse);
                cmd.Parameters.AddWithValue("@DATEDIG", LoginInfo.Instance.DateDig);
                cmd.Parameters.AddWithValue("@DATEVALUE", LoginInfo.Instance.DateValue);
                cmd.Parameters.AddWithValue("@UserID", LoginInfo.Instance.UserID ?? "-");

                con.Open();
                object result = cmd.ExecuteScalar();
                return result != null;
            }
        }

        public bool DeleteProduct(string productId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_DeleteProduct", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PID", productId);
                cmd.Parameters.AddWithValue("@DeletedBy", LoginInfo.Instance.UserID ?? "-");
                cmd.Parameters.AddWithValue("@DATE", LoginInfo.Instance.PersianDate ?? "-");
                cmd.Parameters.AddWithValue("@DATEVALUE", LoginInfo.Instance.DateValue);
                cmd.Parameters.AddWithValue("@DATEDIG", LoginInfo.Instance.DateDig);

                con.Open();
                object result = cmd.ExecuteScalar();
                return result != null;
            }
        }

        public List<ProductModel> GetAllProducts()
        {
            var list = new List<ProductModel>();

            using (SqlConnection conn = new SqlConnection(Config.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("sp_ReturnAllProducts", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ProductModel
                        {
                            ProductID = reader["PID"]?.ToString() ?? "",
                            ProductName = reader["Pname"]?.ToString() ?? "",
                            Unit = new UnitModel
                            {
                                UnitID = reader["UnitID"]?.ToString() ?? "",
                                MeasurmentUnitTitle = reader["MeasurmentUnitTitle"]?.ToString() ?? "",
                                PunitTitle = reader["PunitTitle"]?.ToString() ?? ""
                            },
                            Seller = new SellerModel
                            {
                                SellerID = reader["SellerID"]?.ToString() ?? "",
                                SellerName = reader["SellerName"]?.ToString() ?? ""
                            },
                            Section = new SectionModel
                            {
                                SecID = reader["SecID"]?.ToString() ?? "",
                                SecTitle = reader["SecTitle"]?.ToString() ?? ""
                            },
                            PurchasePriceUnit = reader["PurchasePriceUnit"] != DBNull.Value ? Convert.ToDecimal(reader["PurchasePriceUnit"]) : 0,
                            PricePerUnit = reader["PricePerUnit"] != DBNull.Value ? Convert.ToDecimal(reader["PricePerUnit"]) : 0,
                            Wastage = reader["Wastage"] != DBNull.Value ? Convert.ToInt32(reader["Wastage"]) : 0,
                            Category = reader["Category"]?.ToString() ?? "",
                            Type = reader["Type"]?.ToString() ?? "",
                            CriticalInventory = reader["CriticalInventory"] != DBNull.Value ? Convert.ToInt32(reader["CriticalInventory"]) : 0,
                            IsDeleted = reader["isDeleted"] != DBNull.Value && Convert.ToBoolean(reader["isDeleted"]),
                            IsActive = reader["isActive"] != DBNull.Value && Convert.ToBoolean(reader["isActive"]),
                            IsDirectUse = reader["IsDirectUse"] != DBNull.Value && Convert.ToBoolean(reader["IsDirectUse"]),
                            LastUpdate = reader["LastUpdate"]?.ToString() ?? "",
                            DateDig = reader["DATEDIG"] != DBNull.Value ? Convert.ToInt32(reader["DATEDIG"]) : 0
                        });
                    }
                }
            }

            return list;
        }

        public List<ProductModel> SearchProducts(string keyword)
        {
            var list = new List<ProductModel>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_SearchProducts", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Keyword", keyword);
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ProductModel
                        {
                            ProductID = reader["PID"]?.ToString() ?? "",
                            ProductName = reader["Pname"]?.ToString() ?? "",
                            Unit = new UnitModel
                            {
                                UnitID = reader["UnitID"]?.ToString() ?? "",
                                MeasurmentUnitTitle = reader["MeasurmentUnitTitle"]?.ToString() ?? "",
                                PunitTitle = reader["PunitTitle"]?.ToString() ?? ""
                            },
                            Seller = new SellerModel
                            {
                                SellerID = reader["SellerID"]?.ToString() ?? "",
                                SellerName = reader["SellerName"]?.ToString() ?? ""
                            },
                            Section = new SectionModel
                            {
                                SecID = reader["SecID"]?.ToString() ?? "",
                                SecTitle = reader["SecTitle"]?.ToString() ?? ""
                            },
                            PurchasePriceUnit = reader["PurchasePriceUnit"] != DBNull.Value ? Convert.ToDecimal(reader["PurchasePriceUnit"]) : 0,
                            PricePerUnit = reader["PricePerUnit"] != DBNull.Value ? Convert.ToDecimal(reader["PricePerUnit"]) : 0,
                            Wastage = reader["Wastage"] != DBNull.Value ? Convert.ToInt32(reader["Wastage"]) : 0,
                            Category = reader["Category"]?.ToString() ?? "",
                            Type = reader["Type"]?.ToString() ?? "",
                            CriticalInventory = reader["CriticalInventory"] != DBNull.Value ? Convert.ToInt32(reader["CriticalInventory"]) : 0,
                            IsDeleted = reader["isDeleted"] != DBNull.Value && Convert.ToBoolean(reader["isDeleted"]),
                            IsActive = reader["isActive"] != DBNull.Value && Convert.ToBoolean(reader["isActive"]),
                            IsDirectUse = reader["IsDirectUse"] != DBNull.Value && Convert.ToBoolean(reader["IsDirectUse"]),
                            LastUpdate = reader["LastUpdate"]?.ToString() ?? "",
                            DateDig = reader["DATEDIG"] != DBNull.Value ? Convert.ToInt32(reader["DATEDIG"]) : 0
                        });
                    }
                }
            }

            return list;
        }
    }
}

