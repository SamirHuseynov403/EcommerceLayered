using AutoMapper;
using Ecommerce.BLL.DTOs.Currency;
using Ecommerce.DAL.Entities;
using Ecommerce.DAL.Repositories.Interfaces;

namespace Ecommerce.BLL.Manager
{
    public class CurrencyManager : CrudManager<Currency, CurrencyDto, CreateCurrencyDto, UpdateCurrencyDto>, ICurrencyService
    {
        public CurrencyManager(IRepository<Currency> respository, IMapper mapper) : base(respository, mapper)
        {
        }
    }
}
