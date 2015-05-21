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
        public async Task<JsonResult> GetData()
        {
            var brandSearch = new BrandSearch(_unitOfWork, _cache, _logWriter);
            var modelSearch = new ModelSearch(_unitOfWork, _cache, _logWriter);
            var versionSearch = new VersionSearch(_unitOfWork, _cache, _logWriter);
            var modifySearch = new ModifySearch(_unitOfWork, _cache, _logWriter);
            var paramSearch = new ParamSearch(_unitOfWork, _cache, _logWriter);
            var paramNameSearch = new ParamNameSearch(_unitOfWork, _cache, _logWriter);
            var paramGroupSearch = new ParamGroupSearch(_unitOfWork, _cache, _logWriter);

            var brandViewModels = await brandSearch.GetBrands();
            var modelViewModels = await modelSearch.GetModels();
            var versionViewModels = await versionSearch.GetVersions();
            var modifyViewModels = await modifySearch.GetModifies();
            var paramViewModels = await paramSearch.GetParams();
            var paramNameViewModels = await paramNameSearch.GetParamNames();
            var paramGroupViewModels = await paramGroupSearch.GetParamGroups();

            var result = new HomeIndexViewModel
            {
                Brands = brandViewModels,
                Models = modelViewModels,
                Versions = versionViewModels,
                Modifies = modifyViewModels,
                Params = paramViewModels,
                ParamNames = paramNameViewModels,
                ParamGroups = paramGroupViewModels
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [BrowserActionFilter]
        public ActionResult About()
        {
            ViewBag.Message = "CarsCompare description page.";

            return View();
        }

        [HttpGet]
        [BrowserActionFilter]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}