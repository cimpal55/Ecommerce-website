using Ecommerce.Shared.Models.Data;

namespace Ecommerce.Client.Services.CategoriesService
{
    public interface ICategoriesService
    {
        Task InsertCategoryAsync(CategoriesRecord category);
        Task DeleteCategoryAsync(CategoriesRecord category);
        Task UpdateCategoryAsync(CategoriesRecord category);
        Task<ServiceResponseRecord<List<CategoriesRecord>>> AddCategory(CategoriesRecord category);
        Task<ServiceResponseRecord<List<CategoriesRecord>>> DeleteCategory(int id);
        Task<ServiceResponseRecord<List<CategoriesRecord>>> UpdateCategory(CategoriesRecord category);
        Task<CategoriesRecord> GetCategoryById(int id);
        Task<ServiceResponseRecord<List<CategoriesRecord>>> GetAdminCategories();
        Task<ServiceResponseRecord<List<CategoriesRecord>>> GetCategories();
    }
}
