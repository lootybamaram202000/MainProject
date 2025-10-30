using System;
using System.Collections.Generic;
using MainProject.Entities;
using MainProject.DataAccess;
using MainProject.Helpers;

namespace MainProject.Business
{
    public class SellerManager
    {
        private readonly SellerDAL _dal = new SellerDAL();
        

        public bool InsertSeller(SellerModel model, string userID, string date, DateTime dateValue, int dateDig, out string message)
        {
            // اعتبارسنجی‌های سبک سمت فرم/منیجر
            if (model == null)
            {
                message = "مدل فروشنده معتبر نیست.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(model.SellerName))
            {
                message = "نام فروشنده الزامی است.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(model.CompanyName))
            {
                message = "نام شرکت الزامی است.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(model.Phone))
            {
                message = "شماره تماس الزامی است.";
                return false;
            }

            // Balance نمایشی؛ اگر چیزی نیامده صفر می‌گذاریم
            message = string.Empty;
            return _dal.InsertSeller(model, userID, date, dateValue, dateDig, out message);
        }

        public bool UpdateSeller(SellerModel model, string userID, string date, DateTime dateValue, int dateDig, out string message)
        {
            if (model == null || string.IsNullOrWhiteSpace(model.SellerID))
            {
                message = "شناسه فروشنده نامعتبر است.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(model.SellerName))
            {
                message = "نام فروشنده الزامی است.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(model.CompanyName))
            {
                message = "نام شرکت الزامی است.";
                return false;
            }

            message = string.Empty;
            return _dal.UpdateSeller(model, userID, date, dateValue, dateDig, out message);
        }

        public bool DeleteSeller(string sellerID, string userID, string date, DateTime dateValue, int dateDig, out string message)
        {
            if (string.IsNullOrWhiteSpace(sellerID))
            {
                message = "شناسه فروشنده نامعتبر است.";
                return false;
            }
            return _dal.DeleteSeller(sellerID, userID, date, dateValue, dateDig, out message);
        }

        public bool GetAllSellers(out List<SellerModel> sellers, out string message)
        {
            return _dal.GetAllSellers(out sellers, out message);
        }

        public bool Search(string text, out List<SellerModel> sellers, out string message)
        {
            return _dal.Search(text ?? string.Empty, out sellers, out message);
        }
        public List<SellerModel> GetAllSellers()
        {
            List<SellerModel> sellers;
            string msg;
            _dal.GetAllSellers(out sellers, out msg);
            return sellers ?? new List<SellerModel>();
        }

        public List<SellerModel> SearchSellers(string text)
        {
            List<SellerModel> sellers;
            string msg;
            _dal.Search(text ?? string.Empty, out sellers, out msg);
            return sellers ?? new List<SellerModel>();
        }
    }
}
