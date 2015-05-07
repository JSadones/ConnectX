using System;
using System.Linq;
using System.Collections.Generic;

namespace ConnectXLibrary
{
    public class ResponseForWebClient
    {
        private bool status;
        Dictionary<string, string> request = new Dictionary<string, string>();
        Dictionary<string, string> response = new Dictionary<string, string>(); 
        
        public ResponseForWebClient(bool status, Dictionary<string, string> request, Dictionary<string, string> response)
        {
            this.status = status;
            this.request = request;
            this.response = response;

        }
    }
}
