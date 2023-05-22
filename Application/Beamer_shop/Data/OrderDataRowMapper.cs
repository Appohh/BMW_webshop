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
    public class OrderAutoMapper
    {
        private IMapper _mapper;
        public OrderAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                //cfg.SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
                cfg.CreateMap<DataRow, Order>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src["Id"]))
                    .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src["CustomerId"]))
                    .ForMember(dest => dest.PaymentType, opt => opt.MapFrom(src => src["PaymentType"]))
                    .ForMember(dest => dest.Paid, opt => opt.MapFrom(src => src["Paid"]))
                    .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src["Discount"]))
                    .ForMember(dest => dest.Shipped, opt =>
                    {
                        opt.MapFrom(src => Convert.IsDBNull(src["Shipped"]) ? null : (DateTime?)src["Shipped"]);
                    })
                    .ForMember(dest => dest.EstimatedDeliveryA, opt => opt.MapFrom(src => src["EstimatedDeliveryA"]))
                    .ForMember(dest => dest.EstimatedDeliveryB, opt => opt.MapFrom(src => src["EstimatedDeliveryB"]))
                    .ForPath(dest => dest.DeliveryAddress.Street, opt => opt.MapFrom(src => src["Street"]))
                    .ForPath(dest => dest.DeliveryAddress.HouseNumber, opt => opt.MapFrom(src => src["Housenumber"]))
                    .ForPath(dest => dest.DeliveryAddress.City, opt => opt.MapFrom(src => src["City"]))
                    .ForPath(dest => dest.DeliveryAddress.Zipcode, opt => opt.MapFrom(src => src["Zipcode"]))
                    .ForPath(dest => dest.DeliveryAddress.Country, opt => opt.MapFrom(src => src["Country"]))
                    .ForMember(dest => dest.TotalTax, opt => opt.MapFrom(src => src["TotalTax"]))
                    .ForMember(dest => dest.TotalShipping, opt => opt.MapFrom(src => src["TotalShipping"]))
                    .ForMember(dest => dest.TotalTotal, opt => opt.MapFrom(src => src["TotalTotal"]))
                    .ForMember(dest => dest.TimeStamp, opt => opt.MapFrom(src => src["Timestamp"]));
            });

             _mapper = config.CreateMapper();
        }

        public Order MapDataRowToObject(DataRow row)
        {
            return _mapper.Map<DataRow, Order>(row);
        }   
    }
}
