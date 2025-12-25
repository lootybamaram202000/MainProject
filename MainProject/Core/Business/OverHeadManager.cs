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
    internal class OverHeadManager
    {
        private readonly OverHeadDAL _dal = new OverHeadDAL();

        public void CalculateOverHeadSummary(int financialYear, out decimal fixedTotal, out decimal variableTotal)
        {
            _dal.CalculateOverHeadSummary(financialYear, out fixedTotal, out variableTotal);
        }

        // نسخه کامل با تمام فیلترها (مرتب و سازگار با DAL)
        public void CalculateOverHeadSummary(
            int? year,
            string ohType,
            int? month,
            string category,
            string title,
            out decimal fixedTotal,
            out decimal variableTotal)
        {
            _dal.CalculateOverHeadSummary(year, ohType, month, category, title, out fixedTotal, out variableTotal);
        }

        public bool SubmitSectionOverHeads(List<SectionModel> sections, out string errorMessage)
        {
            return _dal.SubmitSectionOverHeads(sections, out errorMessage);
        }


        public string InsertOverHead(OverHeadModel model, string userName)
        {
            return _dal.InsertOverHead(model, userName);
        }

        public bool UpdateOverHead(OverHeadModel model)
        {
            return _dal.UpdateOverHead(model);
        }

        public bool DeleteOverHead(string ohid)
        {
            return _dal.DeleteOverHead(ohid);
        }

        public List<OverHeadModel> GetOverHeadsByYear(int year)
        {
            return _dal.GetOverHeadsByYear(year);
        }

        public List<OverHeadModel> GetOverHeadsByFilter(string ohType, int? year, int? month, string category)
        {
            return _dal.GetOverHeadsByFilter(ohType, year, month, category);
        }

        public bool SubmitSectionDraft(DataTable sectionInputs, out string errorMessage)
        {
            return _dal.SubmitOHSectionInputDraft(sectionInputs, out errorMessage);
        }

        public bool SubmitSubSectionDraft(DataTable subSectionInputs, out string errorMessage)
        {
            return _dal.SubmitOHSubSectionInputDraft(subSectionInputs, out errorMessage);
        }

        public DataTable CalculateAllocation(out string errorMessage)
        {
            return _dal.CalcOverheadAllocation(out errorMessage);
        }

        public DataTable GetOHPerItemBySSID(string ssid, out string errorMessage)
        {
            return _dal.GetOHPerItemBySSID(ssid, out errorMessage);
        }
    }
}
