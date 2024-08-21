using BrightonVibe.Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace BrightonVibe.Web;

public class ExceptionHandlerService : IExceptionHandler
{
   /// <summary>
   /// Attempts to handle an exception by setting the appropriate HTTP status code in the response.
   /// </summary>
   /// <param name="httpContext">The current HTTP context.</param>
   /// <param name="exception">The exception that was thrown.</param>
   /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
   /// <returns>A ValueTask indicating whether the exception was handled.</returns>
   public ValueTask<bool> TryHandleAsync(
      HttpContext httpContext,
      Exception exception,
      CancellationToken cancellationToken)
   {
      // Set the response status code based on the type of exception
      httpContext.Response.StatusCode = exception switch
      {
         // Venue exceptions
         VenueNotFoundException => StatusCodes.Status404NotFound,
         
         // VenueCategory exceptions
         VenueTypeNotFoundException => StatusCodes.Status404NotFound,

         // Default case for unhandled exceptions
         _ => StatusCodes.Status500InternalServerError
      };

      return ValueTask.FromResult(true);
   }
}