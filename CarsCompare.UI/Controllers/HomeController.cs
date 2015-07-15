using CarsCompare.Database;
using CarsCompare.Logger;
using CarsCompare.UI.ActionFilters;
using CarsCompare.UI.Cache;
using CarsCompare.UI.ViewModels;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CarsCompare.UI.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;
        private readonly LogWriter _logWriter;

        public HomeController(ICacheService cache, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
            _logWriter = new LogWriter();
        }

        [HttpGet]
        [BrowserActionFilter]
        public ActionResult Index()
        {
            ViewBag.Message = "CarsCompare home page.";

            return View();
        }

        [HttpGet]
        [BrowserActionFilter]
        public async Task<JsonResult> GetBrands()
        {
            var brandSearch = new BrandSearch(_unitOfWork, _cache, _logWriter);

            var brandViewModels = await brandSearch.GetBrands();

            var result = new DataResultViewModel
            {
                Brands = brandViewModels
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [BrowserActionFilter]
        public async Task<JsonResult> GetModelsByBrandId(int brandId)
        {
            var modelSearch = new ModelSearch(_unitOfWork, _cache, _logWriter);

            var modelViewModels = await modelSearch.GetModelsByBrandId(brandId);

            var result = new DataResultViewModel
            {
                Models = modelViewModels
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [BrowserActionFilter]
        public async Task<JsonResult> GetVersionsByModelId(int modelId)
        {
            var versionSearch = new VersionSearch(_unitOfWork, _cache, _logWriter);

            var versionViewModels = await versionSearch.GetVersionsByModelId(modelId);

            var result = new DataResultViewModel
            {
                Versions = versionViewModels
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [BrowserActionFilter]
        public async Task<JsonResult> GetModifiesByModelIdAndVersionId(int modelId, int versionId)
        {
            var modifySearch = new ModifySearch(_unitOfWork, _cache, _logWriter);

            var modifyViewModels = await modifySearch.GetModifiesByModelIdAndVersionId(modelId, versionId);

            var result = new DataResultViewModel
            {
                Modifies = modifyViewModels
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [BrowserActionFilter]
        public async Task<JsonResult> GetParamsAndImageByModifyId(CarViewModel viewModel)
        {
            var paramSearch = new ParamSearch(_unitOfWork, _cache, _logWriter);
            var imageSearch = new ImageSearch(_cache, _logWriter);

            var paramViewModels = await paramSearch.GetParamsByModifyId(viewModel.ModifyId);
            var imageUrl = await imageSearch.GetImageAsync(viewModel);

            var result = new DataResultViewModel
            {
                Params = paramViewModels,
                ImageUrl = imageUrl
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [BrowserActionFilter]
        public async Task<JsonResult> GetParamGroupsWithParamNames()
        {
            var paramGroupSearch = new ParamGroupSearch(_unitOfWork, _cache, _logWriter);

            var paramGroupsViewModels = await paramGroupSearch.GetParamGroupsWithParamNames();

            var result = new DataResultViewModel
            {
                ParamGroups = paramGroupsViewModels
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _unitOfWork.Dispose();

            base.Dispose(disposing);
        }
    }
}