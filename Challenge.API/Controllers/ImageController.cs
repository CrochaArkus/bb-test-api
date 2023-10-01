using Challenge.API.Model;
using ExceptionImages;
using Image.Dtos;
using Image.lnterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImagesServices _imageServices;

        public ImageController(IImagesServices imageServices) { _imageServices = imageServices; }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(ImageRequest request)
        {
            DataResponse<int> data = new DataResponse<int>();
            try
            {
                int id = await _imageServices.Create(request);

                data.status = StatusCodes.Status200OK;
                data.data = id;
                return Ok(data);
            }
            catch (ExceptionCreateImage ex)
            {
                data.message = ex.Message;
                data.status = StatusCodes.Status400BadRequest;
                data.data = 0;
                return StatusCode(StatusCodes.Status400BadRequest, data);
            }
            catch (Exception ex)
            {
                data.message = ex.Message;
                data.status = StatusCodes.Status500InternalServerError;
                data.data = 0;
                return StatusCode(data.status, data);
            }
        }
        [HttpGet("Category/{categoryId}/Sucategory/{subcategoryId}")]
        public async Task<IActionResult> GetByIdCategoryIdSubcategory(int categoryId, int subcategoryId)
        {
            DataResponse<ImageResponse> data = new DataResponse<ImageResponse>();
            try
            {
                ImageResponse? response = await _imageServices.GetByIdCategoryIdSubcategory(categoryId, subcategoryId);

                data.status = StatusCodes.Status200OK;
                data.data = response;
                return Ok(data);
            }            
            catch (Exception ex)
            {
                data.message = ex.Message;
                data.status = StatusCodes.Status500InternalServerError;
                data.data = null;
                return StatusCode(data.status, data);
            }
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            DataResponse<List<ImageUploadResponse>> data = new DataResponse<List<ImageUploadResponse>>();
            try
            {
                List<ImageUploadResponse> response = await _imageServices.GetAll();

                data.status = StatusCodes.Status200OK;
                data.data = response;
                return Ok(data);
            }
            catch (Exception ex)
            {
                data.message = ex.Message;
                data.status = StatusCodes.Status500InternalServerError;
                data.data = null;
                return StatusCode(data.status, data);
            }
        }

        [HttpGet("Category/{categoryId}/Sucategory/{subcategoryId}/InteriorCategory/{interiorCategoryId}")]
        public async Task<IActionResult> GetByIdCategorySubactegoryInteriorCategory(int categoryId, 
            int subcategoryId, int interiorCategoryId)
        {
            DataResponse<ImageResponse> data = new DataResponse<ImageResponse>();
            try
            {
                ImageResponse? response = await _imageServices.GetByIdCategorySubactegoryInteriorCategory(categoryId,
                    subcategoryId, interiorCategoryId);

                data.status = StatusCodes.Status200OK;
                data.data = response;
                return Ok(data);
            }
            catch (Exception ex)
            {
                data.message = ex.Message;
                data.status = StatusCodes.Status500InternalServerError;
                data.data = null;
                return StatusCode(data.status, data);
            }
        }

        [HttpGet("Category/{categoryId}")]
        public async Task<IActionResult> GetByIdCategory(int categoryId)
        {
            DataResponse<ImageResponse> data = new DataResponse<ImageResponse>();
            try
            {
                ImageResponse? response = await _imageServices.GetByIdCategory(categoryId);

                data.status = StatusCodes.Status200OK;
                data.data = response;
                return Ok(data);
            }
            catch (Exception ex)
            {
                data.message = ex.Message;
                data.status = StatusCodes.Status500InternalServerError;
                data.data = null;
                return StatusCode(data.status, data);
            }
        }
    }
}
