using System;
using System.Collections.Generic;
using System.Linq;
using MainProject.Entities;
using MainProject.DataAccess;

namespace MainProject.Core
{
    internal class UnitManager
    {

        private readonly UnitDAL _dal = new UnitDAL();

        public bool InsertUnit(UnitModel unit, out string newUnitID)
        {
            return _dal.InsertUnit(unit, out newUnitID);
        }


        public bool UpdateUnit(UnitModel unit)
        {
            return _dal.UpdateUnit(unit);
        }

        public bool IsDuplicateUnit(string unitType, string muTitle, string puTitle, string excludeUnitID = null)
        {
            return _dal.IsDuplicateUnit(unitType, muTitle, puTitle, excludeUnitID);
        }


        public bool DeleteUnit(string unitID)
        {
            return _dal.DeleteUnit(unitID);
        }

        public List<UnitModel> GetAllUnits()
        {
            return _dal.GetAllUnits();
        }

        public List<UnitModel> SearchUnits(string keyword)
        {
            return _dal.SearchUnits(keyword);
        }

    }
}
