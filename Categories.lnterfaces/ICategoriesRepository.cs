using Categories.Dtos;

namespace Categories.lnterfaces
{
    public interface ICategoriesRepository
    {
        Task<int> CreateCategory(string name);
        Task<int> CreateSubCategory(int idSubCategoria, string name);
        Task<int> CreateInteriorSubCategory(int idCategoria, int idSubcategory, string name);
        Task<List<CategoriesResponse>> GetAllCategories();
        Task<List<SubCategoriesResponse>> GetSubCategoriesByIdCategory(int categoryId);
        Task UpdateCategory(int categoryId, string name);
        Task UpdateSubCategory(int subCategoryId, int idCategory, string name);
        Task<List<InteriorSubCategoriesResponse>> GetInteriorSubcategoriesByIdCategorySubCategories(int categoryId,
            int idSubcategory);
    }
}
