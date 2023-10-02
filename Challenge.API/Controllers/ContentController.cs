using Categories.Dtos;
using Categories.lnterfaces;
using Challenge.API.Model;
using Content.Dtos.Request;
using Contents.lnterfaces;
using ExceptionCategories;
using ExceptionContents;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly IContentsServices _contentsServices;
        public ContentController(IContentsServices contentsServices) { _contentsServices = contentsServices; }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(ContentRequest request)
        {
            DataResponse<List<ManageContentResponse>> data = new DataResponse<List<ManageContentResponse>>();
            try
            {
                List<ManageContentResponse> result = await _contentsServices.Create(request);

                data.status = StatusCodes.Status200OK;
                data.data = result;
                return Ok(data);
            }
            catch (ExecptionCreateContent ex)
            {
                data.message = ex.Message;
                data.status = StatusCodes.Status400BadRequest;
                data.data = null;
                return StatusCode(StatusCodes.Status400BadRequest, data);
            }
            catch (ExceptionCreateManageContent ex)
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
                return StatusCode(data.status, data);
            }
        }

        [HttpGet()]
        public IActionResult Get([FromQuery] int? categoryId = 0, int? subcategoriId = 0 , 
            int? interiorSubcategory = 0 , string? name = "")
        {
            DataResponse<List<ManageContentResponse>> data = new DataResponse<List<ManageContentResponse>>();
            try
            {
                List<ManageContentResponse> result = _contentsServices.GetManageContente((int)categoryId,
                    (int)subcategoriId, (int)interiorSubcategory, name );

                data.status = StatusCodes.Status200OK;
                data.data = result;
                return Ok(data);
            }
            catch (ExecptionCreateContent ex)
            {
                data.message = ex.Message;
                data.status = StatusCodes.Status400BadRequest;
                data.data = null;
                return StatusCode(StatusCodes.Status400BadRequest, data);
            }
            catch (ExceptionCreateManageContent ex)
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
                return StatusCode(data.status, data);
            }
        }
    }
}
