using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.IO;

namespace YetAnotherNewsSite.Controllers
{
    internal class ViewContext
    {
        private ControllerContext controllerContext;
        private object view;
        private ViewDataDictionary viewData;
        private ITempDataDictionary tempData;
        private StringWriter sw;

        public ViewContext(ControllerContext controllerContext, object view, ViewDataDictionary viewData, ITempDataDictionary tempData, StringWriter sw)
        {
            this.controllerContext = controllerContext;
            this.view = view;
            this.viewData = viewData;
            this.tempData = tempData;
            this.sw = sw;
        }
    }
}