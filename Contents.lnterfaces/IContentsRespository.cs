using Challenge.Entities.Entities;
using Content.Dtos.Request;

namespace Contents.lnterfaces
{
    public interface IContentsRespository
    {
        Task<int> Create(ContentRequest contentRequest);
        Task<MagnamentContentsCategories> CreateManageContent(ListCategories request, int idContent);
        List<ManageContentResponse> GetManageContenteCreateContent(List<MagnamentContentsCategories> request);
        List<ManageContentResponse> GetManageContenteByCategory(int categoryId);
        List<ManageContentResponse> GetManageContenteByCategorySubcategory(int categoryId, int subcategory);
        List<ManageContentResponse> GetManageContenteByCategorySubcategoryInteriorSubCategory(int categoryId,
            int subcategoryId, int interiorSubcategoryId);
        List<ManageContentResponse> GetManageContenteByName(string name);
        List<ManageContentResponse> GetManageContenteByNameCategoryId(string name, int categoryId);
        List<ManageContentResponse> GetManageContenteByNameCategoryIdSubcategoryId(string name,
            int categoryId, int SubcategoryId);
        List<ManageContentResponse> GetManageContenteByNameCategoryIdSubcategoryIdInteriorSubcategoryId
            (string name, int categoryId, int SubcategoryId, int interiorSubcategoryId);
        List<ManageContentResponse> GetManageContente();
    }
}