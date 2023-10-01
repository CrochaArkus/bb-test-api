using Image.Dtos;

namespace Image.lnterfaces
{
    public interface IImagesServices
    {
        Task<int> Create(ImageRequest request);
        Task<ImageResponse?> GetByIdCategoryIdSubcategory(int categoryId, int subcategoryId);
        Task<List<ImageUploadResponse>> GetAll();
        Task<ImageResponse?> GetByIdCategorySubactegoryInteriorCategory(int categoryId,
            int subcategoryId, int interiorSubcategoryId);
        Task<ImageResponse?> GetByIdCategory(int categoryId);
    }
}
