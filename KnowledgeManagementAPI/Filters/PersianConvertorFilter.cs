using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace KnowledgeManagementAPI.Filters
{
    public class PersianConvertorFilterAttribute : Attribute, IActionFilter
    {
        readonly string ParameterName;
        public PersianConvertorFilterAttribute(string parameterName)
        => ParameterName = parameterName;
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var DtoProperties = context.ActionArguments[ParameterName].GetType().GetProperties();
            object paramValue;
            if (DtoProperties != null)
                foreach (var item in DtoProperties)
                    if (item.PropertyType == typeof(System.String))
                    {
                        paramValue = item.GetValue(context.ActionArguments[ParameterName]);
                        if (paramValue != null)
                            item.SetValue(context.ActionArguments[ParameterName], paramValue.ToString().ToPersianString());
                    }

                
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }


    }
}
