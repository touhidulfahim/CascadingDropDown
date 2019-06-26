using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using CascadingDropDownApp.DTO;
using CascadingDropDownApp.Models;

namespace CascadingDropDownApp.MapperConfig
{
    public class AutoMapperConfig
    {
        public static void Config()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                //Source to Destination
                //Entity to DTO(View/UI)
                cfg.CreateMap<DepartmentModels, DepartmentDTO>();

                //Source to Destination
                //DTO(UI/View) to Entity
                cfg.CreateMap<DepartmentDTO, DepartmentModels>();
                    //.ForMember(dest=>dest.DepartmentCode,opt=>opt.MapFrom(src=>src.DepartmentCode))
                    //.ForMember(dest=>dest.DepartmentName,opt=>opt.MapFrom(src=>src.DepartmentName))
                    //.ForMember(dest=>dest.IsActive, opt=>opt.MapFrom(src=>src.IsActive))
                    //.ForMember(dest=>dest.DateOfEntry, opt=>opt.MapFrom(src=>src.DateOfEntry));

            });
        }
    }
}