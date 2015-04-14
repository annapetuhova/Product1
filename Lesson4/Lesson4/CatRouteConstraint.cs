using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Routing;
using Newtonsoft.Json.Schema;

namespace Lesson4
{
    public class CatRouteConstraint : IRouteConstraint //ограничения для категорий товаров
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var regex = new Regex(@"[A-Z,a-z]+");
            
            if (values[parameterName].ToString() == "date")
                return false;
            return regex.Matches(values[parameterName].ToString()).Count != 0;
        }
    }

    public class DateConstraint : IRouteConstraint
    {

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var date = values[parameterName];
            DateTime outDate;
            return DateTime.TryParse(date.ToString(), out outDate); //tryparese - метод, возвращает истину, если строка удовлетворяет формату даты. Иначе возвращает ложь

        }
    }
}