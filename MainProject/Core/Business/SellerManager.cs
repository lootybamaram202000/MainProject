using System;
using System.Collections.Generic;
using MainProject.Entities;
using MainProject.DataAccess;
using MainProject.Helpers;

namespace MainProject.Business
{
    public class SellerManager
    {
        private readonly SellerDAL dal = new SellerDAL();

        public bool GetAllSellers(out List<SellerModel> sellers, out string message)
        {
            return dal.GetAllSellers(out sellers, out message);
        }

        public bool Search(string text, out List<SellerModel> sellers, out string message)
        {
            return dal.Search(text ?? string.Empty, out sellers, out message);
        }

        public bool InsertSellerAndAccount(SellerModel model, string userID, string date, DateTime dateValue, int dateDig, out string message)
        {
            if (model == null || model.Account == null)
            {
                message = "اطلاعات فروشنده یا حساب وارد نشده است.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(model.SellerName) || string.IsNullOrWhiteSpace(model.CompanyName))
            {
                message = "نام فروشنده یا شرکت وارد نشده است.";
                return false;
            }
            return dal.InsertSellerAndAccount(model, userID, date, dateValue, dateDig, out message);
        }

        public bool UpdateSellerAndAccount(SellerModel model, string userID, string date, DateTime dateValue, int dateDig, out string message)
        {
            if (model == null || model.Account == null || string.IsNullOrWhiteSpace(model.SellerID))
            {
                message = "اطلاعات فروشنده یا حساب ناقص.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(model.SellerName) || string.IsNullOrWhiteSpace(model.CompanyName))
            {
                message = "نام فروشنده یا شرکت وارد نشده است.";
                return false;
            }
            return dal.UpdateSellerAndAccount(model, userID, date, dateValue, dateDig, out message);
        }

        public bool DeleteSeller(string sellerID, string userID, string date, DateTime dateValue, int dateDig, out string message)
        {
            return dal.DeleteSeller(sellerID, userID, date, dateValue, dateDig, out message);
        }
    }


}
