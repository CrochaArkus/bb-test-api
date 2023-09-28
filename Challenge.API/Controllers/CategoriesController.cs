using Categories.Dtos;
using Categories.lnterfaces;
using Challenge.API.Model;
using ExceptionCategories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Challenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesServices _categoriesServices;
        public CategoriesController(ICategoriesServices categoriesServices) { _categoriesServices = categoriesServices; }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateCategories(CategoriesRequest request)
        {
            DataResponse<int> data= new DataResponse<int>();
            try
            {
                int id = await _categoriesServices.CreateCategories(request);
                
                data.status = StatusCodes.Status200OK;
                data.data = id;
                return Ok(data);
            }
            catch (ExceptionCreateCategories ex)
            {
                data.message = ex.Message;
                data.status = StatusCodes.Status400BadRequest;
                data.data = 0;
                return StatusCode(StatusCodes.Status400BadRequest, data);
            }
            catch (Exception ex)
            {
                data.message= ex.Message;
                data.status = StatusCodes.Status500InternalServerError;
                data.data = 0;
                return StatusCode(data.status, data);
            }
        }
        [HttpPost("Create/Sub")]
        public async Task<IActionResult> CreateSubCategories(SubCategoriesRequest request)
        {
            DataResponse<int> data = new DataResponse<int>();
            try
            {
                int id = await _categoriesServices.CreateSubCategories(request);

                data.status = StatusCodes.Status200OK;
                data.data = id;
                return Ok(data);
            }
            catch (ExceptionCreateSubCategories ex)
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
                return StatusCode(StatusCodes.Status500InternalServerError, data);
            }
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAllCategories()
        {
            DataResponse<List<CategoriesResponse>> data = new DataResponse<List<CategoriesResponse>>();
            try
            {
                List<CategoriesResponse> categories = await _categoriesServices.GetAllCategories();

                data.status = StatusCodes.Status200OK;
                data.data = categories;
                return Ok(data);
            }            
            catch (Exception ex)
            {
                data.message = ex.Message;
                data.status = StatusCodes.Status500InternalServerError;
                data.data = null;
                return StatusCode(StatusCodes.Status500InternalServerError, data);
            }
        }
        [HttpGet("Sub/{categoryId}")]
        public async Task<IActionResult> GetSubCategoriesByIdCategory(int categoryId)
        {
            DataResponse<List<SubCategoriesResponse>> data = new DataResponse<List<SubCategoriesResponse>>();
            try
            {
                List<SubCategoriesResponse> subCategories = await _categoriesServices.GetSubCategoriesByIdCategory(categoryId);

                data.status = StatusCodes.Status200OK;
                data.data = subCategories;
                return Ok(data);
            }            
            catch (Exception ex)
            {
                data.message = ex.Message;
                data.status = StatusCodes.Status500InternalServerError;
                data.data = null;
                return StatusCode(StatusCodes.Status500InternalServerError, data);
            }
        }
        [HttpPut()]
        public async Task<IActionResult> UpdateCategory(CategorySubCompleteRequest request)
        {
            DataResponse<string> data = new DataResponse<string>();
            try
            {
                await _categoriesServices.UpdateCategory(request.id,request.Name);
                data.status = StatusCodes.Status200OK;
                data.data = "Success";
                return Ok(data);
            }
            catch (ExceptionCategoryNoExist ex)
            {
                data.message = ex.Message;
                data.status = StatusCodes.Status400BadRequest;
                data.data = null;
                return StatusCode(StatusCodes.Status400BadRequest, data);
            }
            catch (ExceptionUpdateCategories ex)
            {
                data.message = ex.Message;
                data.status = StatusCodes.Status400BadRequest;
                data.data = null;
                return StatusCode(StatusCodes.Status400BadRequest, data);
            }
            catch (Exception ex)
            {
                data.message = ex.Message;
                data.status = StatusCodes.Status500InternalServerError;
                data.data = null;
                return StatusCode(StatusCodes.Status500InternalServerError, data);
            }
        }
        [HttpPut("Sub")]
        public async Task<IActionResult> UpdateSubCategory(SubCategorySubCompleteRequest request)
        {
            DataResponse<string> data = new DataResponse<string>();
            try
            {
                await _categoriesServices.UpdateSubCategory(request.id, request.categoryId, request.name);
                data.status = StatusCodes.Status200OK;
                data.data = "Success";
                return Ok(data);
            }
            catch (ExceptionSubCategoryNoExist ex)
            {
                data.message = ex.Message;
                data.status = StatusCodes.Status400BadRequest;
                data.data = null;
                return StatusCode(StatusCodes.Status400BadRequest, data);
            }
            catch (ExceptionUpdateSubCategories ex)
            {
                data.message = ex.Message;
                data.status = StatusCodes.Status400BadRequest;
                data.data = null;
                return StatusCode(StatusCodes.Status400BadRequest, data);
            }
            catch (Exception ex)
            {
                data.message = ex.Message;
                data.status = StatusCodes.Status500InternalServerError;
                data.data = null;
                return StatusCode(StatusCodes.Status500InternalServerError, data);
            }
        }
    }
}
