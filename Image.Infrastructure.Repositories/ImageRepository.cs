using Challenge.Entities.Entities;
using ExceptionImages;
using Image.Dtos;
using Image.lnterfaces;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Image.Infrastructure.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly ApplicationContext _context;

        public ImageRepository(ApplicationContext context) { _context = context; }

        public async Task<int> Create(ImageRequest request, byte[] imageData)
        {
            try
            {
                ImageUpload image = SetImage(request, imageData);
                _context.imageUploads.Add(image);
                await _context.SaveChangesAsync();

                return image.id_image_Upload;
            }
            catch (Exception)
            {
                throw new ExceptionCreateImage();
            }
        }

        public async Task<ImageResponse?> GetByIdCategoryIdSubcategory(int categoryId, int subcategoryId)
        {
            ImageUpload? image = await _context.imageUploads.FirstOrDefaultAsync(x => x.active == true
            && x.idSubcategories == subcategoryId && x.idCategories == categoryId);

            return MapperImage(image);
        }

        public async Task<List<ImageUpload>> GetAll() => await _context.imageUploads.Where(x => x.active == true).ToListAsync();        

        private ImageResponse? MapperImage(ImageUpload? request)
        {
            if (request == null) return null;

            string imageData = Encoding.ASCII.GetString(request.image_Data);
            return new ImageResponse()
            {
                imageId = request.id_image_Upload,
                nameImage = request.name,
                imagenFile = imageData
            };
        }

        private ImageUpload SetImage(ImageRequest request, byte[] imageData)
        {
            return new ImageUpload()
            {
                idSubcategories = request.subCategoryId,
                idCategories = request.categoryId,
                image_Data = imageData,
                name = request.nameImage,
                active = true,
                create_date = DateTime.Now
            };
        }


    }
}