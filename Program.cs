using System;
using System.Collections.Generic;



namespace puissance4
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("==================================================================");
            Console.WriteLine("============================ PlayPower4 ==========================");
            Console.WriteLine("==================================================================");


            /* int numberOfPlayers = GameBoard.AskUserInt("How many players want play?");
             List<Player> playerList = new List<Player>();
             for (int i = 0; i < numberOfPlayers; i++)
             {
                 Console.WriteLine("name of player"); //ask the name of player
                 string name = Console.ReadLine();
                 Console.WriteLine("Choice your Token");// ask the color of player
                 string token = Console.ReadLine();
                 playerList.Add(new Player(name, token[0]));// add player to list
             }*/

            Game game = new Game();
            game.Start();
            game.Play();

            //int lines = GameBoard.AskUserInt("number of Line of gameboard");
            //int columns = GameBoard.AskUserInt("number of columns of gameboard");
            //GameBoard theGameBoard = new GameBoard(lines, columns); // create a board with number of lines and columns
            /*for (int i = 0; i < playerList.Count; i++)
            {
                int numberOfColumn = GameBoard.AskUserInt("{0} How column want you put token?");
                theGameBoard.PlaceToken(numberOfColumn, playerList[i]);

            }*/
            //theGameBoard.displayGameBoard();





        }

    }
}
