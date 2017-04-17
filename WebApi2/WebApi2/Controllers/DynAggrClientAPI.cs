using System;

namespace WebApi2.Controllers
{
    internal class DynAggrClientAPI
    {
        internal static string openSession(string userid, string pwd)
        {
            var v = userid + pwd;
            return v;
        }
    }
}