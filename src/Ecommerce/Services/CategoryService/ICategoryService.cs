using Ecommerce.Shared.Models.Data;

namespace Ecommerce.Client.Services.CategoryService
{
    public interface ICategoryService
    {
        event Action OnChange;
        List<CategoriesRecord> Categories { get; set; }
        List<CategoriesRecord> AdminCategories { get; set; }
        Task GetCategories();
        Task GetAdminCategories();
        Task AddCategory(CategoriesRecord category);
        Task UpdateCategory(CategoriesRecord category);
        Task DeleteCategory(int categoryId);
        CategoriesRecord CreateNewCategory();
    }
}
