using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public static class ExceptionExtensionMethods
{
    public static string InnerMostMessage(this Exception ex)
    {
        Exception inner = ex;
        while (inner.InnerException != null)
            inner = inner.InnerException;
        return inner.Message;
    }
}
