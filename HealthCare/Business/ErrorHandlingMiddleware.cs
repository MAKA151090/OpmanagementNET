using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using HealthCare.Context;
using HealthCare.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Business
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
      

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
          
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // Log the exception
                // Handle the exception
                // Return an appropriate response
                WebErrorsModel webErrors = new WebErrorsModel();
                webErrors.ErrDateTime = DateTime.Now.ToString();
                webErrors.ErrodDesc=ex.Message.ToString();
                webErrors.Username = "Admin";
                webErrors.ScreenName= ex.Message.ToString();

             

                context.Response.Redirect("/Shared/ErrorView.cshtml");
                
            }
        }
    }

  
}
