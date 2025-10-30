using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainProject.DataAccess;
using MainProject.Entities;

namespace MainProject.Core.Business
{
    internal class ItemManager
    {
        private readonly ItemDAL _dal = new ItemDAL();

        public bool AddItem(ItemModel model, out string newItemID)
        {
            return _dal.InsertItem(model, out newItemID);
        }

        public bool EditItem(ItemModel model, List<ItemRecipieModel> recipies, decimal? sellPrice = null)
        {
            return _dal.UpdateItem(model, recipies, sellPrice);
        }

        public bool RemoveItem(string itemID)
        {
            return _dal.DeleteItem(itemID);
        }

        public List<ItemModel> GetAll()
        {
            return _dal.GetAllItems();
        }

        public List<ItemModel> Search(string keyword)
        {
            return _dal.SearchItems(keyword);
        }

        public List<ItemRecipieModel> GetRecipiesByItemID(string itemID)
        {
            return _dal.GetItemRecipies(itemID);
        }

        public bool SubmitRecipie(string itemID, List<ItemRecipieModel> recipies, decimal? sellPrice = null)
        {
            return _dal.SubmitRecipie(itemID, recipies, sellPrice);
        }

    }
}
