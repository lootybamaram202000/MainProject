using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainProject.DataAccess;
using MainProject.Entities;
using MainProject.Helpers;

namespace MainProject.Core
{
    internal class SectionManager

    {
        private readonly SectionDAL _dal = new SectionDAL();

        public bool InsertSection(SectionModel section, out string newSecID)
        {
            return _dal.InsertSection(section, out newSecID);
        }

        public bool UpdateSection(SectionModel section)
        {
            return _dal.UpdateSection(section);
        }

        public bool DeleteSection(string sectionId)
        {
            return _dal.DeleteSection(sectionId);
        }

        public List<SectionModel> GetAllSections()
        {
            return _dal.GetAllSections();
        }
    }
}
