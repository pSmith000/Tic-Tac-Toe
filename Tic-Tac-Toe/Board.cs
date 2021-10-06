using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe
{
    class Board
    {
        private char _player1Token;
        private char _player2Token;
        private char _currentToken;
        private char[,] _board;
        private int _currentTurn = 0;

        /// <summary>
        /// Initializes player tokens and the game board
        /// </summary>
        public void Start()
        {
            _player1Token = 'x';
            _player2Token = 'o';
            _currentToken = _player1Token;
            _board = new char[3, 3] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
        }

        /// <summary>
        /// Gets the input from the player.
        /// Sets the player token at the desired spot in the 2d array
        /// Checks if there is a winner.
        /// Changes the current token in play.
        /// </summary>
        public void Update()
        {
            bool validOption = false;


            while (validOption == false)
            {
                Console.Write("Put the number of the spot where you want to go Player " + _currentToken + "!\n> ");
                int choice = Game.GetInput() - 1;

                if (choice > -1 && choice < 9 && SetToken(_currentToken, choice / 3, choice % 3))
                {
                    validOption = true;
                    _currentTurn++;
                }
            }

            if (CheckWinner(_currentToken))
            {
                RestartGame();
            }
            else if (_currentTurn == 9)
            {
                Console.WriteLine("It's a tie!");
                RestartGame();
            }
            else
            {
                if (_currentToken == _player1Token)
                    _currentToken = _player2Token;

                else
                    _currentToken = _player1Token;
            }
            
        }

        /// <summary>
        /// Draws the board and lets the players know whose turn it is
        /// </summary>
        public void Draw()
        {
            Console.WriteLine(_board[0, 0] + " | " + _board[0, 1] + " | " + _board[0, 2] + "\n" +
                              "_________\n" +
                              _board[1, 0] + " | " + _board[1, 1] + " | " + _board[1, 2] + "\n" +
                              "_________\n" +
                              _board[2, 0] + " | " + _board[2, 1] + " | " + _board[2, 2] + "\n");
        }

        /// <summary>
        /// Called whent he game ends
        /// </summary>
        public void End()
        {
            
            
        }

        public void RestartGame()
        {
            Console.Write("Would you like to play again?\n1. Yes\n2. No\n> ");

            int choice = Game.GetInput();

            if (choice == 1)
            {
                ClearBoard();
                _currentTurn = 0;
            }
            else
            {
                Game.ExitApplication();

            }
        }
        /// <summary>
        /// Assigns the spot at a given indices in the board array to be the given token.
        /// </summary>
        /// <param name="token">The token to set the array index to.</param>
        /// <param name="posX">The x position of the token.</param>
        /// <param name="posY">The y position of the token.</param>
        /// <returns>Return false if the indices are out of range</returns>
        public bool SetToken(char token, int posX, int posY)
        {
            int num;
            if (int.TryParse(_board[posX, posY].ToString(), out num))
            {
                _board[posX, posY] = token;
                return true;
            }
            else
            {
                Console.WriteLine("Invalid location.");
                return false;
            }
        }

        /// <summary>
        /// Checks to see if the token appears three times consecutively vertically, horizontally, or diagonally
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private bool CheckWinner(char token)
        {
            Console.Clear();
            Draw();

            for (int i = 0; i < 3; i++)
            {
                if (_board[0,i] == token && _board[1,i] == token && _board[2,i] == token)
                {
                    Console.WriteLine(token + " is the winner!");
                    Console.ReadKey();
                    return true;
                }
                    
            }
            for (int i = 0; i < 3; i++)
            {
                if (_board[i, 0] == token && _board[i, 1] == token && _board[i, 2] == token)
                {
                    Console.WriteLine(token + " is the winner!");
                    Console.ReadKey();
                    return true;
                }

            }
            if (_board[0, 0] == token && _board[1, 1] == token && _board[2, 2] == token)
            {
                Console.WriteLine(token + " is the winner!");
                Console.ReadKey();
                return true;
            }
            if (_board[0, 2] == token && _board[1, 1] == token && _board[2, 0] == token)
            {
                Console.WriteLine(token + " is the winner!");
                Console.ReadKey();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Resets the board to it's default stats.
        /// </summary>
        public void ClearBoard()
        {
            _board = new char[3, 3] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
        }
    }
}

    
