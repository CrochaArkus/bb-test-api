using Challenge.Entities.Entities;
using Image.Dtos;
using Image.lnterfaces;
using System.Text;

namespace Image.Services
{
    public class ImagesServices: IImagesServices
    {
        private IImageRepository _imageRepository;

        public ImagesServices(IImageRepository imageRepository) { _imageRepository = imageRepository; }

        public async Task<int> Create(ImageRequest request) 
        {
           byte[] imageData = Encoding.ASCII.GetBytes(request.image);
           return await _imageRepository.Create(request, imageData);
        }

        public async Task<List<ImageUploadResponse>> GetAll() {

            List<ImageUpload> imageUploads = await _imageRepository.GetAll();

            return imageUploads.Select(imageUpload => new ImageUploadResponse
            {
                idImage = imageUpload.id_image_Upload,
                idInteriorSubcategories = imageUpload.idInteriorSubcategories,
                idSubcategories = imageUpload.idSubcategories,
                idCategories = imageUpload.idCategories,
                imageFile = Encoding.ASCII.GetString(imageUpload.image_Data),
                active= imageUpload.active

            }).ToList();
        }

        public async Task<ImageResponse?> GetByIdCategoryIdSubcategory(int categoryId, int subcategoryId) =>
            await _imageRepository.GetByIdCategoryIdSubcategory(categoryId, subcategoryId);

        public async Task<ImageResponse?> GetByIdCategory(int categoryId) =>
            await _imageRepository.GetByIdCategory(categoryId);

        public async Task<ImageResponse?> GetByIdCategorySubactegoryInteriorCategory(int categoryId,
            int subcategoryId, int interiorSubcategoryId) =>
            await _imageRepository.GetByIdCategorySubactegoryInteriorCategory(categoryId,
                subcategoryId, interiorSubcategoryId);




    }
}