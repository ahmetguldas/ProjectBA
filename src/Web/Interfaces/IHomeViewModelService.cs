using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Interfaces
{
    public interface IHomeViewModelService
    {
        Task<HomeIndexViewModel> GetHomeIndexViewModel(int? categoryId, int? authorId, int page, int pageSize);
        Task<List<SelectListItem>> GetCategories();
        Task<List<SelectListItem>> GetAuthors();
    }
}
