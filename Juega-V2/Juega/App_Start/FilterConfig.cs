﻿using System.Web;
using System.Web.Mvc;

namespace Juega
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute()); 
        }

        //public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        //{
        //    filters.Add(new CustomHandleErrorAttribute());
        //    filters.Add(new AuthorizeAttribute());
        //}
    }
}
