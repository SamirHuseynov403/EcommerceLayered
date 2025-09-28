using Ecommerce.BLL.DTOs.Currency;
using Ecommerce.BLL.Services;
using Ecommerce.DAL.Entities;

public interface ICurrencyService : ICrudService<Currency, CurrencyDto, CreateCurrencyDto, UpdateCurrencyDto> { }
