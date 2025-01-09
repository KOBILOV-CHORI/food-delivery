using Domain.Dtos;
using Infrastructure.Responses;

namespace Infrastructure.Services.MenuServices;

public interface IMenuService
{
    ApiResponse<bool> AddMenu(AddMenuDto addMenuDto);
    ApiResponse<bool> UpdateMenu(UpdateMenuDto updateMenuDto);
    ApiResponse<bool> DeleteMenu(int id);
    ApiResponse<List<GetMenuDto>> GetAllMenus();
    ApiResponse<GetMenuDto> GetMenuById(int id);
}
