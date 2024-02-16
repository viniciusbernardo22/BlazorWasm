using WasmApp.Models;

namespace WasmApp.Interfaces;

public interface ICategoryService
{
    Task<List<Category>> GetAllCategoriesAsync();

    Task<Category> CreateNewCategoryAsync(Category model);

    Task<Category> GetCategoryById(int id);

    Task<Category> EditCategory(Category model);
}