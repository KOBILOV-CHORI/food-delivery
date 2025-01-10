using Domain.Dtos;
using Domain.Filters;
using Infrastructure.Responses;

namespace Infrastructure.Services.MenuServices;

public interface IMenuService
{
    ApiResponse<bool> AddMenu(AddMenuDto addMenuDto);
    ApiResponse<bool> UpdateMenu(UpdateMenuDto updateMenuDto);
    ApiResponse<bool> DeleteMenu(int id);
    PaginationResponse<List<GetMenuDto>> GetAllMenus(MenuFilter filter);
    ApiResponse<GetMenuDto> GetMenuById(int id);
}
