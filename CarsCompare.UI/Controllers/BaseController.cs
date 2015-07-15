using CarsCompare.Logger;
using CarsCompare.UI.ActionResults;
using System.Web.Mvc;

namespace CarsCompare.UI.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly LogWriter LogWriter = new LogWriter();

        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding)
        {
            return new JsonNetResult
            {
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                Data = data
            };
        }

        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonNetResult
            {
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                Data = data,
                JsonRequestBehavior = behavior
            };
        }
    }
}