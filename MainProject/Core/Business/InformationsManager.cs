using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainProject.DataAccess;
using MainProject.Entities;

namespace MainProject.Core.Business
{
    public class InformationsManager
    {
        private readonly InformationDAL _dal = new InformationDAL();

        public List<InformationDto> GetForComboBox(string context)
        {
            return _dal.GetInformationByContext(context);
        }

        public void AddInformation(InformationDto info)
        {
            _dal.InsertInformation(info);
        }

        public void EditInformation(InformationDto info)
        {
            _dal.UpdateInformation(info);
        }

        public void RemoveInformation(InformationDto info)
        {
            _dal.DeleteInformation(info);
        }
    }
}
