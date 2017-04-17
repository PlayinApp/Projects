using System;

namespace WebApi2.Controllers
{
    internal class UrlUtil
    {
        internal static string getParam(ValuesController valuesController, string v1, string v2)
        {
           var v= v1 + v2;
            return v;
        }
    }
}