using AutoMapper;
using Ecommerce.BLL.DTOs.Language;
using Ecommerce.BLL.Services;
using Ecommerce.DAL.Entities;
using Ecommerce.DAL.Repositories.Interfaces;

namespace Ecommerce.BLL.Manager
{
    public class LanguageManager : CrudManager<Language, LanguageDto, CreateLanguageDto, UpdateLanguageDto>, ILanguageService
    {
        public LanguageManager(IRepository<Language> respository, IMapper mapper) : base(respository, mapper)
        {
        }
    }
}
