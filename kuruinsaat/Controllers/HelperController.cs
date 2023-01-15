using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kuruinsaat.Controllers
{

    // GET: Helper
    [AttributeUsage(AttributeTargets.Class)]
    public class DefaultActionAttribute : ActionFilterAttribute
    {
        private string _defaultActionName;
        private string _changeTo;

        public DefaultActionAttribute(string changeTo, string defaultActionName = "Index")
        {
            _defaultActionName = defaultActionName;
            _changeTo = changeTo;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string currentAction = filterContext.RequestContext.RouteData.Values["action"].ToString();
            if (string.Compare(_defaultActionName, currentAction, true) == 0)
            {
                filterContext.RequestContext.RouteData.Values["action"] = _changeTo;
            }
            base.OnActionExecuting(filterContext);
        }

    }
}