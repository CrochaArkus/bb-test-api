using Challenge.Entities.Entities;
using Content.Dtos.Request;
using Contents.lnterfaces;

namespace Contents.Services
{
    public class ContentsServices: IContentsServices
    {
        private IContentsRespository _contentsRespository;

        public ContentsServices(IContentsRespository contentsRespository) { _contentsRespository = contentsRespository; }

        public async Task<List<ManageContentResponse>> Create(ContentRequest request) 
        {
            List<MagnamentContentsCategories> magnamentContentsCategories = new List<MagnamentContentsCategories>();
            int idContent = await _contentsRespository.Create(request);
            foreach (ListCategories listCategories in request.listCategories) 
            {
                MagnamentContentsCategories magnamentContents = await _contentsRespository.CreateManageContent(listCategories,
                    idContent);

                magnamentContentsCategories.Add(magnamentContents);
            }

           return _contentsRespository.GetManageContenteCreateContent(magnamentContentsCategories);
        }

        public List<ManageContentResponse> GetManageContente(int categoryId = 0, int subcategoriId = 0,
            int interiorSubcategory = 0, string name = "") 
        {
            if(categoryId > 0 && subcategoriId == 0 && interiorSubcategory == 0 && name == string.Empty)
              return _contentsRespository.GetManageContenteByCategory(categoryId);

            if (categoryId > 0 && subcategoriId > 0 && interiorSubcategory == 0 && name == string.Empty)
              return _contentsRespository.GetManageContenteByCategorySubcategory(categoryId, subcategoriId);

            if (categoryId > 0 && subcategoriId > 0 && interiorSubcategory > 0 && name == string.Empty)
                return _contentsRespository.GetManageContenteByCategorySubcategoryInteriorSubCategory(categoryId,
                    subcategoriId, interiorSubcategory);
            if (categoryId == 0 && subcategoriId == 0 && interiorSubcategory == 0 && name != string.Empty)
                return _contentsRespository.GetManageContenteByName(name);
            if (categoryId > 0 && subcategoriId == 0 && interiorSubcategory == 0 && name != string.Empty)
                return _contentsRespository.GetManageContenteByNameCategoryId(name, categoryId);
            if (categoryId > 0 && subcategoriId > 0 && interiorSubcategory == 0 && name != string.Empty)
                return _contentsRespository.GetManageContenteByNameCategoryIdSubcategoryId(name, 
                    categoryId, subcategoriId);
            if (categoryId > 0 && subcategoriId > 0 && interiorSubcategory > 0 && name != string.Empty)
                return _contentsRespository.GetManageContenteByNameCategoryIdSubcategoryIdInteriorSubcategoryId
                    (name, categoryId, subcategoriId, interiorSubcategory);

            return _contentsRespository.GetManageContente();
        }
            
    }
}