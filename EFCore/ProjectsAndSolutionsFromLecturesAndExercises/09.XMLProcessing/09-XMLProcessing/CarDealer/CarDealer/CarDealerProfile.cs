using AutoMapper;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<SupplierInputModel, Supplier>();
            this.CreateMap<PartInputModel, Part>();
            this.CreateMap<CustomerInputModel, Customer>();
            this.CreateMap<SaleInputModel, Sale>();

            this.CreateMap<Car, CarOutputModel>();
            this.CreateMap<Car, BMWOutputModel>();
            this.CreateMap<Supplier, SupplierOutputModel>()
                            .ForMember(x => x.PartsCount, y => y.MapFrom(s => s.Parts.Count));
        }
    }
}
