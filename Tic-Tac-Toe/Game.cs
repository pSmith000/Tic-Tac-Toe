using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe
{
    class Game
    {
        private static bool _gameOver = false;
        private static int _currentSceneIndex;
        private Board _gameBoard;
        private static int _sceneCount = 2;

        /// <summary>
        /// Begins the game
        /// </summary>
        public void Run()
        {
            Start();

            while (!_gameOver)
            {
                Draw();
                Update();
            }

            End();
        }

        /// <summary>
        /// Called when game starts
        /// </summary>
        private void Start()
        {
            _gameBoard = new Board();
            _gameBoard.Start();
        }

        /// <summary>
        /// Called every time the game loops
        /// </summary>
        private void Update()
        {
            switch (_currentSceneIndex)
            {
                case 0:
                    _gameBoard.Update();
                    break;
                case 1:
                    RestartGame();
                    break;
            }
            
        }
        public void RestartGame()
        {
            Console.Write("Would you like to play again?\n1. Yes\n2. No\n> ");

            int choice = Game.GetInput();

            if (choice == 1)
            {
                _currentSceneIndex = 0;
                _gameBoard.InitializeBoard();
            }
            else if (choice == 2)
            {
                ExitApplication();
            }
            else
            {
                Console.WriteLine("Invalid Answer");
            }
        }

        public static bool SetCurrentScene(int index)
        {
            if (index < 0 || index > _sceneCount)
                return false;

            _currentSceneIndex = index;
            return true;
        }

        /// <summary>
        /// Draws the display to reflect any changes made while running
        /// </summary>
        private void Draw()
        {
            Console.Clear();
            _gameBoard.Draw();
        }

        public static void ExitApplication()
        {
            _gameOver = true;

        }

        /// <summary>
        /// Called when the game ends
        /// </summary>
        private void End()
        {
            _gameBoard.End();
        }

        public static int GetInput()
        {
            int choice = -1;
            if (!int.TryParse(Console.ReadLine(), out choice))
                choice = -1;

            return choice;
        }
    }
}
