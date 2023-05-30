using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaroGameVer2
{
    public class Player
    {
        private string player_name;
        public string Player_name
        {
            get { return player_name; }
            set { player_name = value; }
        }
        private Image mark;
        public Image Mark
        {
            get { return mark; }
            set { mark = value; }
        }
        public Player(string player_name, Image mark )
        {
            this.Player_name = player_name;
            this.Mark = mark;
        }
    }

}
