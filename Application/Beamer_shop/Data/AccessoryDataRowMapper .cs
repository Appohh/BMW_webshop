using AutoMapper;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AccessoryAutoMapper
    {
        private IMapper _mapper;
        public AccessoryAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                //cfg.SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
                cfg.CreateMap<DataRow, Accessory>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src["Id"]))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src["Name"]))
                    .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src["Price"]))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src["Description"]))
                    .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src["ImageUrl"]))
                    .ForMember(dest => dest.Keyword, opt => opt.MapFrom(src => src["Type"]))
                    .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src["Type"]));



            });

             _mapper = config.CreateMapper();
        }

        public Accessory MapDataRowToObject(DataRow row)
        {
            return _mapper.Map<DataRow, Accessory>(row);
        }
    }
}
