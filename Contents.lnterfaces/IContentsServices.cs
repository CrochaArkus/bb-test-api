using Content.Dtos.Request;

namespace Contents.lnterfaces
{
    public interface IContentsServices
    {
        Task<List<ManageContentResponse>> Create(ContentRequest request);
        List<ManageContentResponse> GetManageContente(int categoryId = 0, int subcategoriId = 0,
            int interiorSubcategory = 0, string name = "");
    }
}
