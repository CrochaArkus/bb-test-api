using Challenge.Entities.Entities;
using Image.Dtos;

namespace Image.lnterfaces
{
    public interface IImageRepository
    {
        Task<int> Create(ImageRequest request, byte[] imageData);
        Task<ImageResponse?> GetByIdCategoryIdSubcategory(int categoryId, int subcategoryId);
        Task<List<ImageUpload>> GetAll();
        Task<ImageResponse?> GetByIdCategory(int categoryId);
        Task<ImageResponse?> GetByIdCategorySubactegoryInteriorCategory(int categoryId,
            int subcategoryId, int interiorSubcategoryId);
    }
}