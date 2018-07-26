using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace aspnetGame.Controllers.Extensions
{
    public class RequireRequestValueAttribute : ActionMethodSelectorAttribute
    {
        public RequireRequestValueAttribute(string[] valueNames)
        {
            ValueNames = valueNames;
        }
        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            Boolean result = true;
            foreach (var item in ValueNames)
            {
                if (controllerContext.HttpContext.Request[item] == null)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
        public string[] ValueNames { get; private set; }
    }
}