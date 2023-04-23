namespace ITMasters.Api.Extensions;

public static class MetaDataHelper
{
    public static void ResponseHeadersHelper(this HttpContext httpContext)
    {
        httpContext.Response.Headers.Add("Success", "Successfuly response");
    }
}