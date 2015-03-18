using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOPeenRijLibrary
{
    public class XOPeenRijInterface
    {
        private XOPeenRij game;

        public XOPeenRijInterface()
        {
            
        }
        public void newGame()
        {
            game = new XOPeenRij();
        }
        public bool gameRunning()
        {
            if (game != null)
            {
                return true;
            }
            else return false;
        }
    }
}
