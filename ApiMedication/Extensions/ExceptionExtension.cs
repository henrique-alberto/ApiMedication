using ApiMedication.Models;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace ApiMedication.Extensions
{
    public static class ExceptionExtension
    {
        public static void ExceptionHandler(this IApplicationBuilder app)
        {
              app.UseExceptionHandler(error =>
              {
                  error.Run(async context =>
                  {
                      context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                      context.Response.ContentType = "application/json";

                      var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                      if (exceptionFeature != null)
                      {
                          await context.Response.WriteAsync(new ErrorDetails()
                          {
                              StatusCode = context.Response.StatusCode,
                              Message = exceptionFeature.Error.Message,
                              Trace = exceptionFeature.Error.StackTrace
                          }.ToString());
                      }
                  });
              });
        }
    }
}
