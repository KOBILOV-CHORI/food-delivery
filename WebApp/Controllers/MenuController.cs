using Domain.Dtos;
using Domain.Filters;
using Infrastructure.Responses;
using Infrastructure.Services.MenuServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MenuController(IMenuService MenuService) : Controller
{
    [HttpGet] public PaginationResponse<List<GetMenuDto>> GetAllMenus([FromQuery] MenuFilter filter) => MenuService.GetAllMenus(filter);
    [HttpGet("{id}")] public ApiResponse<GetMenuDto> GetMenuById(int id) => MenuService.GetMenuById(id);
    [HttpDelete("{id}")] public ApiResponse<bool> DeleteMenu(int id) => MenuService.DeleteMenu(id);
    [HttpPost] public ApiResponse<bool> AddMenu([FromBody] AddMenuDto addMenuDto) => MenuService.AddMenu(addMenuDto);
    [HttpPut] public ApiResponse<bool> UpdateMenu([FromBody] UpdateMenuDto updateMenuDto) => MenuService.UpdateMenu(updateMenuDto);
}