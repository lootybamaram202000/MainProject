using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainProject.Entities;

namespace MainProject.DataAccess
{
    public class FactorDAL
    {
        private readonly string _connectionString = Config.ConnectionString;

        public string InsertFactor(FactorModel factor, DataTable subFactors)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_SubmitPurchaseFactor", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SellerID", factor.SellerID);
                cmd.Parameters.AddWithValue("@FHSellerID", factor.FHSellerID ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@TypeOfPayment", factor.TypeOfPayment);
                cmd.Parameters.AddWithValue("@PaymentStatuse", factor.PaymentStatuse);
                cmd.Parameters.AddWithValue("@AccountOfPayment", factor.AccountOfPayment);
                cmd.Parameters.AddWithValue("@DateOfPayment", factor.DateOfPayment ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@TotalPayment", factor.TotalPayment);
                cmd.Parameters.AddWithValue("@TotalDiscount", factor.TotalDiscount);
                cmd.Parameters.AddWithValue("@VAT", factor.VAT);
                cmd.Parameters.AddWithValue("@Shipping", factor.Shipping);
                cmd.Parameters.AddWithValue("@FinalTotalPaid", factor.FinalTotalPaid);
                cmd.Parameters.AddWithValue("@Describtion", factor.Describtion ?? "");
                cmd.Parameters.AddWithValue("@Picture", factor.Picture ?? new byte[0]);

                cmd.Parameters.AddWithValue("@UserID", factor.UserID);
                cmd.Parameters.AddWithValue("@DATE", factor.DATE);
                cmd.Parameters.AddWithValue("@DATEVALUE", factor.DATEVALUE);
                cmd.Parameters.AddWithValue("@DATEDIG", factor.DATEDIG);

                SqlParameter tvpParam = cmd.Parameters.AddWithValue("@SubFactors", subFactors);
                tvpParam.SqlDbType = SqlDbType.Structured;
                tvpParam.TypeName = "SubFactorTVP";

                SqlParameter resultParam = new SqlParameter("@Result", SqlDbType.NVarChar, -1)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(resultParam);

                con.Open();
                cmd.ExecuteNonQuery();

                return resultParam.Value.ToString();
            }
        }
    }
}
