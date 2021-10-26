using System;
using System.Collections.Generic;
using System.Text;

namespace puissance4
{
    class Player
    {
        public string name;
        public char couleur;

        //init the player with his name and color
        public Player(string namee, char couleurr)
        {
            name = namee;
            couleur = couleurr;
        }


        //get name of player
        public string Name
        {
            get
            {
                return name;
            }
        }


        //get color of player
        public char Couleur
        {
            get
            {
                return couleur;
            }
            set
            {
                couleur = value;
            }
        }




    }
}
