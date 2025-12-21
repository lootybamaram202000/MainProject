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

        // Backward-compatible methods
        public bool InsertUnit(UnitModel unit, out string newUnitID)
        {
            return InsertUnit(unit, out newUnitID, out _);
        }

        public bool UpdateUnit(UnitModel unit)
        {
            return UpdateUnit(unit, out _);
        }

        public bool DeleteUnit(string unitID)
        {
            return DeleteUnit(unitID, out _);
        }

        public List<UnitModel> GetAllUnits()
        {
            return _dal.GetAllUnits(out _);
        }

        public List<UnitModel> SearchUnits(string keyword)
        {
            return _dal.SearchUnits(keyword, out _);
        }

        // New methods with validation and error propagation
        public bool InsertUnit(UnitModel unit, out string newUnitID, out string errorMessage)
        {
            newUnitID = null;
            if (!ValidateUnit(unit, out errorMessage))
                return false;
            return _dal.InsertUnit(unit, out newUnitID, out errorMessage);
        }

        public bool UpdateUnit(UnitModel unit, out string errorMessage)
        {
            if (!ValidateUnit(unit, out errorMessage))
                return false;
            return _dal.UpdateUnit(unit, out errorMessage);
        }

        public bool DeleteUnit(string unitID, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(unitID))
            {
                errorMessage = "شناسه واحد نامعتبر است.";
                return false;
            }
            return _dal.DeleteUnit(unitID, out errorMessage);
        }

        public List<UnitModel> GetAllUnits(out string errorMessage)
        {
            return _dal.GetAllUnits(out errorMessage);
        }

        public List<UnitModel> SearchUnits(string keyword, out string errorMessage)
        {
            return _dal.SearchUnits(keyword, out errorMessage);
        }

        public bool IsDuplicateUnit(string unitType, string muTitle, string puTitle, string excludeUnitID = null)
        {
            return _dal.IsDuplicateUnit(unitType, muTitle, puTitle, excludeUnitID);
        }

        private bool ValidateUnit(UnitModel unit, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (unit == null)
            {
                errorMessage = "مدل واحد نامعتبر است.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(unit.MeasurmentUnitTitle))
            {
                errorMessage = "عنوان واحد اندازه‌گیری نمی‌تواند خالی باشد.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(unit.PunitTitle))
            {
                errorMessage = "عنوان واحد کاربردی نمی‌تواند خالی باشد.";
                return false;
            }

            if (unit.MesurmentUnitQuantity <= 0)
            {
                errorMessage = "مقدار واحد اندازه‌گیری باید بیشتر از صفر باشد.";
                return false;
            }

            if (unit.PunitQuantity <= 0)
            {
                errorMessage = "مقدار واحد کاربردی باید بیشتر از صفر باشد.";
                return false;
            }

            return true;
        }

    }
}
