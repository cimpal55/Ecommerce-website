using Ecommerce.Shared.Models.Data;
using LinqToDB;
using Ecommerce.Client.DbAccess;

namespace Ecommerce.Server.Services.CategoriesService
{
    public class CategoriesService : ICategoriesService
    {
        private readonly SqlDataAccess _conn;

        public CategoriesService(SqlDataAccess conn)
        {
            _conn = conn;
        }

        public async Task InsertCategoryAsync(CategoriesRecord category) =>
            await _conn
                .InsertAsync(category)
                .ConfigureAwait(false);
        public async Task DeleteCategoryAsync(CategoriesRecord category) =>
            await _conn
                .DeleteAsync(category)
                .ConfigureAwait(false);
        public async Task UpdateCategoryAsync(CategoriesRecord category) =>
            await _conn
                .UpdateAsync(category)
                .ConfigureAwait(false);

        public async Task<ServiceResponseRecord<List<CategoriesRecord>>> AddCategory(CategoriesRecord category)
        {
            category.Editing = category.IsNew = false;
            await InsertCategoryAsync(category).ConfigureAwait(false);
            return await GetAdminCategories();
        }

        public async Task<ServiceResponseRecord<List<CategoriesRecord>>> DeleteCategory(int id)
        {
            CategoriesRecord category = await GetCategoryById(id);
            if (category == null)
            {
                return new ServiceResponseRecord<List<CategoriesRecord>>
                {
                    Success = false,
                    Message = "Category not found."
                };
            }

            category.Deleted = true;
            await UpdateCategoryAsync(category).ConfigureAwait(false);

            return await GetAdminCategories();
        }
        public async Task<CategoriesRecord> GetCategoryById(int id)
        {
            return await _conn.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ServiceResponseRecord<List<CategoriesRecord>>> GetAdminCategories()
        {
            var categories = await _conn.Categories
                .Where(c => !c.Deleted)
                .ToListAsync();
            return new ServiceResponseRecord<List<CategoriesRecord>>
            {
                Data = categories
            };
        }

        public async Task<ServiceResponseRecord<List<CategoriesRecord>>> GetCategories()
        {
            var categories = await _conn.Categories
                .Where(c => !c.Deleted && c.Visible)
                .ToListAsync();
            return new ServiceResponseRecord<List<CategoriesRecord>>
            {
                Data = categories
            };
        }

        public async Task<ServiceResponseRecord<List<CategoriesRecord>>> UpdateCategory(CategoriesRecord category)
        {
            var dbCategory = await GetCategoryById(category.Id);
            if (dbCategory == null)
            {
                return new ServiceResponseRecord<List<CategoriesRecord>>
                {
                    Success = false,
                    Message = "Category not found."
                };
            }

            dbCategory.Name = category.Name;
            dbCategory.Url = category.Url;
            dbCategory.Visible = category.Visible;

            await UpdateCategoryAsync(dbCategory).ConfigureAwait(false);

            return await GetAdminCategories();

        }
    }
}
