using AutoMapper;
using DomainDTOs.Address;
using DomainDTOs.Customer;
using DomainDTOs.Order;
using DomainObjects.Address;
using DomainObjects.Customer;
using DomainObjects.Orders;

namespace ThAmCo.Profiles.Mapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {

            CreateMap<CompanyDetailsDTO, BillingAddress>()
                .ForMember(dest => dest.BillingAddresssID, opt => opt.MapFrom(src => src.CompanyAddressId))
                .ForMember(dest => dest.BillingAddresss_Shopname, opt => opt.MapFrom(src => src.CompanyName))
                .ForMember(dest => dest.BillingAddresss_Shopnumber, opt => opt.MapFrom(src => src.ShopNumber))
                .ForMember(dest => dest.BillingAddresss_Street, opt => opt.MapFrom(src => src.Street))
                .ForMember(dest => dest.BillingAddresss_City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.BillingAddresss_Country, opt => opt.MapFrom(src => src.Country))
                .ForMember(dest => dest.BillingAddresss_PostalCode, opt => opt.MapFrom(src => src.PostalCode))
                .ReverseMap();

            CreateMap<AddressDTO, ShippingAddress>()
               .ForMember(dest => dest.ShippingAddress_HouseNumber, opt => opt.MapFrom(src => src.HouseNumber))
               .ForMember(dest => dest.ShippingAddress_Street, opt => opt.MapFrom(src => src.Street))
               .ForMember(dest => dest.ShippingAddress_City, opt => opt.MapFrom(src => src.City))
               .ForMember(dest => dest.ShippingAddress_Country, opt => opt.MapFrom(src => src.country))
               .ForMember(dest => dest.ShippingAddress_PostalCode, opt => opt.MapFrom(src => src.PostalCode))
               .ReverseMap();


            CreateMap<CustomerDTO, Customer>()
               .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
               .ForMember(dest => dest.CustomerContactNumber, opt => opt.MapFrom(src => src.CustomerContactNumber))
               .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerName))
               .ForMember(dest => dest.CustomerEmailAddress, opt => opt.MapFrom(src => src.CustomerEmailAddress))
               .ReverseMap();

            CreateMap<OrderItemDTO, OrderItem>()
                .ReverseMap();

            CreateMap<AddNewOrderDTO, Order>()
               .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
               .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => Convert.ToDouble(src.Total)))
               .ForMember(dest => dest.Subtotal, opt => opt.MapFrom(src => Convert.ToDouble(src.Subtotal)))
               .ForMember(dest => dest.DeliveryCharge, opt => opt.MapFrom(src => Convert.ToDouble(src.DeliveryCharge)))
               .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
               .ForMember(dest => dest.OrderCreationDate, opt => opt.MapFrom(src => src.OrderCreationDate))
               .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
               .ForMember(dest => dest.OrderNotes, opt => opt.MapFrom(src => src.OrderNotes))
               .ForMember(dest => dest.OrderedItems, opt => opt.Ignore())
               .ForMember(dest => dest.Customer, opt => opt.Ignore())  // Ignore Customer mapping
               .ForMember(dest => dest.ShippingAddress, opt => opt.Ignore())  // Ignore ShippingAddress mapping
               .ForMember(dest => dest.BillingAddress, opt => opt.Ignore()); // Ignore BillingAddress mapping

            CreateMap<Order, OrderDTO>()
               .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
               .ForMember(dest => dest.OrderCreationDate, opt => opt.MapFrom(src => src.OrderCreationDate))
               .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
               .ForMember(dest => dest.PaymentMethod, opt => opt.MapFrom(src => src.PaymentMethod))
               .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
               .ForMember(dest => dest.Subtotal, opt => opt.MapFrom(src => src.Subtotal))
               .ForMember(dest => dest.DeliveryCharge, opt => opt.MapFrom(src => src.DeliveryCharge))
               .ForMember(dest => dest.OrderNotes, opt => opt.MapFrom(src => src.OrderNotes))
               .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
               .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
               .ForMember(dest => dest.OrderedItems, opt => opt.MapFrom(src => src.OrderedItems))
               .ForMember(dest => dest.ShippingAddress, opt => opt.MapFrom(src => src.ShippingAddress))
               .ForMember(dest => dest.BillingAddress, opt => opt.MapFrom(src => src.BillingAddress));

        }
    }
}
