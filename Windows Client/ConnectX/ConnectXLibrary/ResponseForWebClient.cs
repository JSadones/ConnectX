using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectXLibrary
{
    public class ResponseForWebClient
    {
        string type;

        public ResponseForWebClient() : this(""){}

        public ResponseForWebClient(string type)
        {
            this.type = type;
        }

        public string getType()
        {
            return type;
        }

        public void setType(string type)
        {
            this.type = type;
        }
    }
}
