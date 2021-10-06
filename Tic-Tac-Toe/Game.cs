﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe
{
    class Game
    {
        private static bool _gameOver = false;
        private static int _currentSceneIndex;
        private Board _gameBoard;

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
            _gameBoard.Update();
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
