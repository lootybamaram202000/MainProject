using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainProject.DataAccess;
using MainProject.Entities;

namespace MainProject.Core.Business
{
    internal class BasicItemManager
    {
        private readonly BasicItemDAL _dal = new BasicItemDAL();

        public bool AddBasicItem(BasicItemModel model, out string newBIID)
        {
            return _dal.InsertBasicItem(model, out newBIID);
        }

        public bool EditBasicItem(BasicItemModel model)
        {
            return _dal.UpdateBasicItem(model);
        }

        public bool RemoveBasicItem(string biid)
        {
            return _dal.DeleteBasicItem(biid);
        }

        public List<BasicItemModel> GetAll()
        {
            return _dal.GetAllBasicItems();
        }

        public List<BasicItemModel> Search(string keyword)
        {
            return _dal.SearchBasicItems(keyword);
        }

        public BasicItemModel GetById(string biid)
        {
            return _dal.GetBasicItemById(biid);
        }

        public List<BasicRecipieModel> GetRecipiesByBIID(string biid)
        {
            return _dal.GetRecipiesByBIID(biid);
        }

        public bool SubmitRecipie(string biid, string biName, List<BasicRecipieModel> recipies)
        {
            return _dal.SubmitRecipie(biid, biName, recipies);
        }

    }

}
