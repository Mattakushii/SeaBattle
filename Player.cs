using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Player
    {
        private string name;
        public Field enemyField;
        public Field selfField;
        private int partCount;
        public bool isActive;

        public Player(string name)
        {
            SetName(name);
            enemyField = new Field();
            selfField = new Field();
            isActive = false;
            SetPartCount(20);
        }

        public Player (string name, bool isActive)
        {
            SetName(name);
            enemyField = new Field();
            selfField = new Field();
            this.isActive = isActive;
            SetPartCount(20);
        }

        public void switchTurn()
        {
            isActive = !isActive;
        }

        public void SetName(string name) { this.name = name; }

        public string GetName() { return name; }

        public void SetPartCount(int partCount) { this.partCount = partCount; }

        public int GetPartCount() { return partCount; }

        public bool IsShip(int headX, int headY, int taleX, int taleY)
        {
            if (Math.Abs(headX - taleX) == 0)
            {
                for (int i = headY; i <= taleY; i++)
                {
                    if (selfField.checkZone(headX, i) == Field.ship) return true;
                }
            }
            else if (Math.Abs(headY - taleY) == 0)
            {
                for (int i = headX; i <= taleX; i++)
                {
                    if (selfField.checkZone(i, headY) == Field.ship) return true;
                }
            }
            return false;
        }

        public bool PlaceShip(int headX, int headY, int tailX, int tailY)
        {
            if (Math.Abs(headX - tailX) == 0)
            {
                for (int i = headY - 1; i <= tailY - 1; i++)
                {
                    selfField.markZone(headX - 1, i, Field.ship);
                }
                return true;
            }
            else if (Math.Abs(headY - tailY) == 0)
            {
                for (int i = headX - 1; i <= tailX - 1; i++)
                {
                    selfField.markZone(i, headY - 1, Field.ship);
                }
                return true;
            }
            return false;
        }

        public char GetZone(int x, int y)
        {
            return selfField.checkZone(x, y);
        }

        public void Hit(int x, int y)
        {
            selfField.markZone(x, y, Field.shotDown);
            SetPartCount(GetPartCount() - 1);
        }

        public void Miss(int x, int y)
        {
            selfField.markZone(x, y, Field.attacked);
        }

        public bool Shoot(Player enemy, int x, int y)
        {
            x--;
            y--;
            switch(enemy.GetZone(x, y))
            {
                case Field.water:
                case Field.attacked:
                    {
                        enemy.Miss(x, y);
                        enemy.switchTurn();
                        switchTurn();
                        enemyField.markZone(x, y, Field.attacked);
                        //Console.WriteLine("сударь вы KOSOY EBLAN");
                        //selfField.PrintGameField(40);
                        return false;
                    }
                case Field.ship:
                    {
                        enemy.Hit(x, y);
                        enemyField.markZone(x, y, Field.shotDown);
                        Console.WriteLine("сударь вы попали");
                        //enemyField.PrintGameField(0);
                        //selfField.PrintGameField(40);
                        return true;
                    }
                default:
                    {
                        //enemyField.PrintGameField(0);
                        //selfField.PrintGameField(40);
                        break;
                    }
            }
            return false;
        }

        public void PlaceFleet()
        {
            //selfField.PrintGameField(40);
            Console.WriteLine("Разместите четырехпалубный линкор (4 клетки)");

            Console.Write("Начало X: ");  int headX = Convert.ToInt32(Console.ReadLine());
            Console.Write("Начало Y: ");  int headY = Convert.ToInt32(Console.ReadLine());
            Console.Write( "Конец X: ");  int tailX = Convert.ToInt32(Console.ReadLine());
            Console.Write( "Конец Y: ");  int tailY = Convert.ToInt32(Console.ReadLine());
            PlaceShip(headX, headY, tailX, tailY);
            //selfField.PrintGameField(40);

            Console.WriteLine("Разместите трехпалубные крейсеры (3 клетки)");
            for (int i = 1; i < 3; i++)
            {
                Console.WriteLine("Разместите крейсер");
                Console.Write("Начало X: "); headX = Convert.ToInt32(Console.ReadLine());
                Console.Write("Начало Y: "); headY = Convert.ToInt32(Console.ReadLine());
                Console.Write( "Конец X: "); tailX = Convert.ToInt32(Console.ReadLine());
                Console.Write( "Конец Y: "); tailY = Convert.ToInt32(Console.ReadLine());
                PlaceShip(headX, headY, tailX, tailY);
                //selfField.PrintGameField(40);
            }

            Console.WriteLine("Разместите двухпалубные эсминцы (2 клетки)");
            for (int i = 1; i < 4; i++)
            {
                Console.WriteLine("Разместите эсминец");
                Console.Write("Начало X: "); headX = Convert.ToInt32(Console.ReadLine());
                Console.Write("Начало Y: "); headY = Convert.ToInt32(Console.ReadLine());
                Console.Write( "Конец X: "); tailX = Convert.ToInt32(Console.ReadLine());
                Console.Write( "Конец Y: "); tailY = Convert.ToInt32(Console.ReadLine());
                PlaceShip(headX, headY, tailX, tailY);
                //selfField.PrintGameField(40);
            }

            Console.WriteLine("Разместите лодки (1 клетка)");
            for (int i = 1; i < 5; i++)
            {
                Console.WriteLine("Разместите лодку");
                Console.Write("X: "); headX = Convert.ToInt32(Console.ReadLine());
                Console.Write("Y: "); headY = Convert.ToInt32(Console.ReadLine());
                selfField.markZone(headX, headY, Field.ship);
                //selfField.PrintGameField(30);

            }

        }
    }
}