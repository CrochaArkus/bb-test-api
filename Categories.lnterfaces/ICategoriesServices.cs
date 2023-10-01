using Categories.Dtos;

namespace Categories.lnterfaces
{
    public interface ICategoriesServices
    {
        Task<int> CreateCategories(CategoriesRequest request);
        Task<int> CreateSubCategories(SubCategoriesRequest request);
        Task<List<CategoriesResponse>> GetAllCategories();
        Task<List<SubCategoriesResponse>> GetSubCategoriesByIdCategory(int categoryId);
        Task UpdateCategory(int categoryId, string name);
        Task UpdateSubCategory(int subCategoryId, int idCategory, string name);
        Task<List<InteriorSubCategoriesResponse>> GetInteriorSubcategoriesByIdCategorySubCategories(int categoryId,
        int idSubcategory);
        Task<int> CreateInteriorSubCategory(InteriorSubcategoryRequest request);
    }
}
