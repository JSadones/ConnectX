namespace ConnectXLibrary
{
    public class ResponseForWebClient
    {
        public string type;
        int row, column, player;
        bool won, full, status;

        public string getType()
        {
            return type;
        }

        public void setType(string type)
        {
            this.type = type;
        }

        public ResponseForWebClient(string type, int row, int column, int player, bool status, bool won, bool full)
        {
            this.type = type;
            this.row = row;
            this.column = column;
            this.player = player;
            this.status = status;
            this.won = won;
            this.full = full;

        }
    }
}
