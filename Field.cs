using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Field
    {
        const int n = 10;
        public const char water = '~';
        public const char attacked = 'O';
        public const char shotDown = 'X';
        public const char ship = 'H';
        private char[,] gameField = new char[n, n];


        public Field()
        {
            FillGameField();
        }

        public void FillGameField()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    gameField[i, j] = water;
                }
            }
        }

        public void PrintGameField(int margin)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.SetCursorPosition(margin + 2 * i, j + 3);
                    Console.WriteLine("{0}\t", gameField[i, j]);
                }
            }
        }

        public char checkZone(int x, int y)
        {
            return gameField[x, y];
        }

        public bool markZone(int x, int y, char mark)
        {
            switch(mark)
            {
                case water: 
                case ship:
                case attacked:
                case shotDown:
                    {
                        gameField[x, y] = mark;
                        break;
                    }
                default:
                    return false;
            }
            return true;
        }
    }
}
