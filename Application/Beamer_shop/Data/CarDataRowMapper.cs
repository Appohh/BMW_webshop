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
    public class CarAutoMapper
    {
        private IMapper _mapper;
        public CarAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                //cfg.SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
                cfg.CreateMap<DataRow, Car>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src["Id"]))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src["Name"]))
                    .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src["Price"]))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src["Description"]))
                    .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src["ImageUrl"]))
                    .ForMember(dest => dest.Keyword, opt => opt.MapFrom(src => src["Make"]))
                    .ForMember(dest => dest.ChassisNumber, opt => opt.MapFrom(src => src["ChassisNumber"]))
                    .ForMember(dest => dest.Plate, opt => opt.MapFrom(src => src["Plate"]))
                    .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src["Brand"]))
                    .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src["Model"]))
                    .ForMember(dest => dest.Make, opt => opt.MapFrom(src => src["Make"]))
                    .ForMember(dest => dest.Milage, opt => opt.MapFrom(src => src["Milage"]))
                    .ForMember(dest => dest.Engine, opt => opt.MapFrom(src => src["Engine"]))
                    .ForMember(dest => dest.Fuel, opt => opt.MapFrom(src => src["Fuel"]))
                    .ForMember(dest => dest.HorsePower, opt => opt.MapFrom(src => src["HorsePower"]))
                    .ForMember(dest => dest.Torque, opt => opt.MapFrom(src => src["Torque"]))
                    .ForMember(dest => dest.Time0to60, opt => opt.MapFrom(src => src["Time0to60"]))
                    .ForMember(dest => dest.TopSpeed, opt => opt.MapFrom(src => src["TopSpeed"]))
                    .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src["Weight"]));
            });

             _mapper = config.CreateMapper();
        }

        public Car MapDataRowToObject(DataRow row)
        {
            return _mapper.Map<DataRow, Car>(row);
        }   
    }
}
