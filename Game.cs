using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Game
    {
        static void Main(string[] args)
        {
            string name1 = Console.ReadLine();
            string name2 = Console.ReadLine();
            var player1 = new Player(name1 , true);
            var player2 = new Player(name2);
            Player activePlayer, passivePlayer;
            int shootX, shootY;
            bool isHit;
            bool gameOver = false;

            player1.enemyField.PrintGameField(0);
            player1.selfField.PrintGameField(40);
            Console.ReadKey();
             

            player1.PlaceShip(1, 1, 1, 2);
            player2.PlaceShip(5, 2, 5, 5);
            player1.enemyField.PrintGameField(0);
            player1.selfField.PrintGameField(40);

            while (!gameOver)
            {
                activePlayer = (player1.isActive) ? player1 : player2;
                passivePlayer = (player1.isActive) ? player2 : player1;
                activePlayer.selfField.PrintGameField(40);
                activePlayer.enemyField.PrintGameField(0);
                Console.SetCursorPosition(1, 30); Console.WriteLine(String.Format("Ходит игрок {0}", activePlayer.GetName()));
                Console.Write("Shoot X: "); shootX = Convert.ToInt32(Console.ReadLine());
                Console.Write("Shoot Y: "); shootY = Convert.ToInt32(Console.ReadLine());
                activePlayer.Shoot(passivePlayer, shootX, shootY);
                activePlayer.selfField.PrintGameField(40);
                activePlayer.enemyField.PrintGameField(0);
            }
            Console.ReadKey();
        }
    }
}
