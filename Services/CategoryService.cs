using RestSharp;
using WasmApp.Interfaces;
using WasmApp.Models;

namespace WasmApp.Services;

public class CategoryService : ICategoryService
{
    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        var client = new RestClient();
        var request = new RestRequest($"{Configuration.ApiUrl}v1/categories");

        return await client.GetAsync<List<Category>>(request);
    }

    public async Task<Category> CreateNewCategoryAsync(Category model)
    {
        var client = new RestClient();
        var request = new RestRequest($"{Configuration.ApiUrl}v1/categories").AddJsonBody(model);

        var category = await client.PostAsync<Category?>(request);

        return category;
    }

    public async Task<Category> GetCategoryById(int Id)
    {
        var client = new RestClient();
        var request = new RestRequest($"{Configuration.ApiUrl}v1/categories/{Id}");
        var category = await client.GetAsync<Category?>(request);

        return category;
    }

    public async Task<Category> EditCategory(Category model)
    {
        var client = new RestClient();
        var request = new RestRequest($"{Configuration.ApiUrl}v1/categories/{model.Id}").AddJsonBody(model);
        var category = await client.PutAsync<Category?>(request);

        return category;
    }
}