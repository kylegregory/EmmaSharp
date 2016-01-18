using System;
using RestSharp;

namespace EmmaSharp
{
    public class EmmaException : Exception
    {
        private string message;

        public IRestResponse Response;

        public EmmaException(IRestResponse response)
        {
            Response = response;
            message = "Unexpected response status " + ((int)response.StatusCode).ToString() + " with body:\n" + response.Content;
        }

        public override string Message
        {
            get { return message; }
        }
    }
}
