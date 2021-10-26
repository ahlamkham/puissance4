using System;
using System.Collections.Generic;
using System.Text;
using puissance4;


namespace puissance4
{
    class Game
    {

       private  List<Player> players; //List of players
       private GameBoard theGameBoard;
       private int numberCurrentPlayer; //  number of player who plays  
       private bool nullPart; // true if the part is null 
       private List<string> listOfToken;


        public Game()
        {
            players = new List<Player>();
            nullPart = false;

            theGameBoard = new GameBoard();
            listOfToken = new List<string>(); // List of token for player 
            listOfToken.Add("Red");
            listOfToken.Add("Yellow");
            listOfToken.Add("Green"); 
            listOfToken.Add("White");
            listOfToken.Add("Brown");
            listOfToken.Add("Orange");
            listOfToken.Add("Purple");

        }


        //next player 
        public int nextPlayer()
        {
            numberCurrentPlayer = (++numberCurrentPlayer) % players.Count;
            return numberCurrentPlayer;
        }

        //return the gameboard
        public GameBoard gBoard()
        {
            return theGameBoard;
        }

        // get current player
        public int currentPlay
        {
            get
            {
                return numberCurrentPlayer;
            }
        }

        public bool partNul()
        {
            return nullPart;
        }

        // To display token 
        public string DisplayToken()
        {
            for (int tok = 0; tok < listOfToken.Count; tok++)
            {
                Console.WriteLine(listOfToken[tok]);
            }
            return "";

        }


        public void Start()
        {
            string token;
            string name;
            int numberOfPlayers = GameBoard.AskUserInt("How many players want play?");
            for (int i = 0; i < numberOfPlayers; i++)
            {
                Console.WriteLine("Name of Player {0}", i + 1); //ask the name of player
                name = Console.ReadLine();
                Console.WriteLine("Choice your Token {0}, in the List Please", name);// ask the color of player
                Console.WriteLine("--------- List Of Token ----------");
                DisplayToken();
                Console.WriteLine("----------------------------------");
                token = Console.ReadLine();
                Console.WriteLine("============= Noted ==============");
                while (listOfToken.Contains(token) == false)  // check 2 players don't have the same token 
                {
                    Console.WriteLine("Choice in the List please");
                    Console.WriteLine("--------- List Of Token ----------");
                    DisplayToken();
                    Console.WriteLine("----------------------------------");
                    token = Console.ReadLine();
                    Console.WriteLine("============= Noted ==============");

                }
                players.Add(new Player(name, token[0]));// add player to list
                listOfToken.Remove(token); //remove the chosen token 
            }
        }
        // methods to play and define winner 
            public void Play()
        {
            int winner = -1;
            int currentPlay = 0;
            int playShot = 0;

            theGameBoard.DisplayGameBoard();

            while ((winner == -1))
            {
               
                int numberOfColumn = GameBoard.AskUserInt("Can you choice a column?");
                theGameBoard.PlaceToken(numberOfColumn, players[currentPlay]);
                playShot += 1;
                theGameBoard.DisplayGameBoard();
                if (theGameBoard.IsGameboardFull())
                {
                    winner = -1;
                }
                    if (theGameBoard.Search4())  //check if there is alignment of token and the winner is the current player 
                    {
                        winner = currentPlay;

                    }
                    // next player
                    currentPlay = nextPlayer();
            }
            Console.WriteLine("Part is Finish");
            theGameBoard.DisplayGameBoard();
            if(winner == -1)
            {
                Console.WriteLine("The part is null");
            }
            else
            {
                if (currentPlay % players.Count == 0) // total number of strokes 
                {
                    playShot = playShot/ 2;
                    Console.WriteLine("THE WINNER IS {0}, HE IS WITH WITH {1} STROKES", players[winner].name, playShot);
                }
                else
                {
                    playShot = (playShot/2) + 1;
                }
                Console.WriteLine("The winner is {0}, he is win with {1} strokes", players[winner].name, playShot/*(playShot/2)+1*/ );
            }

        }

    }
}
