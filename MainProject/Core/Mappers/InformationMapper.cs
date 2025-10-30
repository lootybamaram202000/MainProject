using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainProject.Entities;

namespace MainProject.Core.Mappers
{
    public static class InformationMapper
    {
        public static InformationModel ToModel(InformationDto dto, string tableName, string category)
        {
            return new InformationModel
            {
                TableName = tableName,
                Category = category,
                Title = dto.Context,
                PersianTitle = dto.PersianTitle ?? "NotDefined",
                StringValueEng = dto.StringValueEng ?? "NotDefined",
                StringValuePer = dto.StringValuePer ?? "NotDefined",
                DigitalValue = dto.DigitalValue == 0 ? 1 : dto.DigitalValue
            };
        }

        public static InformationDto ToDto(InformationModel model)
        {
            return new InformationDto
            {
                Context = model.Title,
                PersianTitle = model.PersianTitle,
                StringValueEng = model.StringValueEng,
                StringValuePer = model.StringValuePer,
                DigitalValue = model.DigitalValue
            };
        }
    }

}
