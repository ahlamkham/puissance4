using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using puissance4;

namespace puissance4
{

    enum State
    {
        NotStart,
        InProgress,
        Finish

    }
    class GameBoard
    {
        public static int nbLines;
        public static int nbColumns;
        private char[,] board;
        State stateGame;

        //Constructor
        public GameBoard( )
        {
            //create and init tab with space char
            nbLines = GameBoard.AskUserInt("number of Line of gameboard");
            nbColumns = GameBoard.AskUserInt("number of columns of gameboard");
            board = new char[nbLines, nbColumns];
            for (int nL = 0; nL < nbLines; nL++)
            {
                for (int nC = 0; nC < nbColumns; nC++)
                {
                    board[nL, nC] = ' ';
                }
            }

            stateGame = State.NotStart;
        }


        // get number of lines
        public int NumberOfLines
        {
            get
            {
                return nbLines;
            }
        }

        // get number of columns
        public int NumberOfColumns
        {
            get
            {
                return nbColumns;
            }
        }

        //show the game board
        public void DisplayGameBoard()
        {
            Console.Write("\n");
            string affiche1 = "-----";
            for (int i = 0; i < nbColumns-1; i++)
            {
                affiche1 += "----";
            }
            Console.Write(affiche1);
            //Console.Write("----------------------");
            Console.Write("\n");
            for (int nL = 0; nL < nbLines; nL++)
            {
                Console.Write("|  ");
                for (int nC = 0; nC < nbColumns; nC++)
                {
                    Console.Write(board[nL, nC]);
                    Console.Write("|  ");
                }
                string affiche = "-----";
                Console.Write("\n");
                for (int i = 0; i < nbColumns-1; i++)
                {
                    affiche += "----";
                }
                Console.Write(affiche);
                //Console.Write("---------------------");
                Console.Write("\n");
            }
        }

        //check if gameboard is full
        //param board: the board of game
        public  bool IsGameboardFull()
        {
            for (int nL = 0; nL < nbLines; nL++)
            {
                for (int nC = 0; nC < nbColumns; nC++)
                {
                    if (board[nL, nC] == ' ') // check if there is a cell which is empty 
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /* place a token on the game board
         * param column : number of column
         * param player : color of player 
         */
        public  bool PlaceToken(int column, Player player)
        {
            // if state is  not start 
            if(stateGame == State.NotStart)
            {
                stateGame = State.InProgress;
            }

            // if column is full
            if ((column < 0) || (column > nbColumns))
            {
                return false;
            }

            // find the first place empty on the column 
            for (int line = nbLines; line > 0; line--)
            {
                if (board[line-1,column-1] == ' ')
                {
                    board[line-1, column-1] = player.couleur;
                    return true;
                }
            }

            // the column is full 
            return false;
        }

        //ask user to enter a number 
        public static int AskUserInt(string question)
        {
            Console.WriteLine(question);
            int value;

            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("please enter a valide number :");
            }

            return value;
        }

        //search 4 alignment of token from origin line and column, 
        //deplaceLine and deplaceColumn are parameters of deplacement 
        public bool Search4Alignment(int originLine, int originColumn, int deplaceLine, int deplaceColumn)
        {
            char color = ' ';
            int counter = 0;
            int currentLine = originLine;
            int cuurentColumn = originColumn;
            while(((currentLine>=0) && (currentLine<nbLines)) && ((cuurentColumn >= 0) &&( cuurentColumn < nbColumns)))
            {
                if(board[currentLine,cuurentColumn] != color)
                {
                    color = board[currentLine, cuurentColumn];
                    counter = 1;
                }
                else
                {
                    counter++;
                }
                if((color != ' ') && (counter == 4))
                {
                    return true;
                }

                //we check next cell
                currentLine += deplaceLine;
                cuurentColumn += deplaceColumn;
            }
            return false;

        }
        public bool Search4()
        {
            //alignment in horizontal 
            for (int line = 0; line < nbLines; line++)
            {
                if (Search4Alignment(line, 0, 0, 1))
                {
                    return true;
                }
            }

            //alignment in vertical 
            for (int column = 0; column < nbColumns; column++)
            {
                if (Search4Alignment(0, column, 1, 0))
                {
                    return true;
                }
            }

            // two diagonals from bottom line
            for (int column = 0; column < nbColumns; column++)
            {
                // first diagonal ( / )
                if (Search4Alignment(0, column, 1, 1))
                {
                    return true;
                }
                // second diagonal ( \ )
                if (Search4Alignment(0, column, 1, -1))
                {
                    return true;
                }
            }

            // diagonal from right and left columns
            for (int line = 0; line < nbLines; line++)
            {
                // first diagonal ( / )
                if (Search4Alignment(line, 0, 1, 1))
                {
                    return true;
                }
                // second diagonal  ( \ )
                if (Search4Alignment(line, nbColumns-1, 1, -1))
                {
                    return true;
                }
            }

            return false;

        }

      
    }
}
