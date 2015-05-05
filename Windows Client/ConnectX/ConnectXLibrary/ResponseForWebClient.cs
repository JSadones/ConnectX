namespace ConnectXLibrary
{
    public class ResponseForWebClient
    {
        public string type, row, column, player, status, won;

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
