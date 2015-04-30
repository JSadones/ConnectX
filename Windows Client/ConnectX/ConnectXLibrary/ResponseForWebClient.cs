namespace ConnectXLibrary
{
    public class ResponseForWebClient
    {
        public string type, parameter1, parameter2;

        public ResponseForWebClient() : this("a","b","c"){}

        public ResponseForWebClient(string type, string parameter1, string parameter2)
        {
            this.type = type;
            this.parameter1 = parameter1;
            this.parameter2 = parameter2;
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
