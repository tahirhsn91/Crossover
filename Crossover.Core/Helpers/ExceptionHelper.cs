using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Crossover.Core.Helpers
{
    public class ExceptionHelper
    {
        public static void ThrowAPIException(HttpStatusCode code, string reasonPhrase, string content)
        {
            var resp = new HttpResponseMessage(code);

            resp.Content = new StringContent(content);
            resp.ReasonPhrase = reasonPhrase;

            throw new HttpResponseException(resp);
        }

        public static Exception GetAPIException(HttpStatusCode code, string reasonPhrase, string content)
        {
            var resp = new HttpResponseMessage(code);

            resp.Content = new StringContent(content);
            resp.ReasonPhrase = reasonPhrase;

            return new HttpResponseException(resp);
        }
    }
}
