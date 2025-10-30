using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainProject.DataAccess;
using MainProject.Entities;

namespace MainProject.Core.Business
{
    public class FactorManager
    {
        private readonly FactorDAL _factorDAL = new FactorDAL();

        public string SubmitFactor(FactorModel factor, List<SubFactorModel> subFactorList)
        {
            // تبدیل لیست به DataTable برای ارسال به TVP
            DataTable subFactorTable = new DataTable();
            subFactorTable.Columns.Add("PID", typeof(string));
            subFactorTable.Columns.Add("Quantity", typeof(int));
            subFactorTable.Columns.Add("PricePerUnit", typeof(decimal));
            subFactorTable.Columns.Add("DATE", typeof(string));
            subFactorTable.Columns.Add("DATEVALUE", typeof(DateTime));
            subFactorTable.Columns.Add("DATEDIG", typeof(int));

            foreach (var item in subFactorList)
            {
                subFactorTable.Rows.Add(
                    item.PID,
                    item.Quantity,
                    item.PricePerUnit,
                    item.DATE,
                    item.DATEVALUE,
                    item.DATEDIG
                );
            }

            return _factorDAL.InsertFactor(factor, subFactorTable);
        }
    }
}
