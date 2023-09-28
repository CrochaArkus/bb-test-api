using Categories.Dtos;
using Categories.lnterfaces;

namespace Categories.Services
{
    public class CategoriesServices: ICategoriesServices
    {
        private ICategoriesRepository _categoriesRepository;

        public CategoriesServices(ICategoriesRepository categoriesRepository) { _categoriesRepository = categoriesRepository;  }

        public async Task<int> CreateCategories(CategoriesRequest request)  => await _categoriesRepository.CreateCategory(request.Name);
        public async Task UpdateCategory(int categoryId, string name) => await _categoriesRepository.UpdateCategory(categoryId, name);
        public async Task<List<CategoriesResponse>> GetAllCategories() => await _categoriesRepository.GetAllCategories();
        public async Task<int> CreateSubCategories(SubCategoriesRequest request) => 
            await _categoriesRepository.CreateSubCategory(request.categoryId, request.name);       
        public async Task<List<SubCategoriesResponse>> GetSubCategoriesByIdCategory(int categoryId) =>
            await _categoriesRepository.GetSubCategoriesByIdCategory(categoryId);        
        public async Task UpdateSubCategory(int subCategoryId, int idCategory, string name) 
            => await _categoriesRepository.UpdateSubCategory(subCategoryId, idCategory, name);
    }
}