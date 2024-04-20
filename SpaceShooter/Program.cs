using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using EZInput;
using System.IO;

namespace SpaceShooter
{
    class Program
    {
        static void Main(string[] args)
        {

            char[,] walls = new char[23, 110];
            readData(walls);
            printWalls(walls);

            // Player character

            char[,] heroShip = {
                       { ' ', '|', '\\', '-', ' ',' '},
                       { '\\','|', '(', ')', '=', '>'},
                       { '/', '|', '(', ')', '=', '>'},
                       { ' ', '|', '/', '-', ' ', ' '}
            };

            // Hero Coordinates
            int heroShipX = 9;
            int heroShipY = 10;
            printHeroShip(ref heroShipX, ref heroShipY, heroShip);

            //  Enemy 1 Character

            char[,] enemy1 = {
                     { ' ', ' ', ' ', ' ', ' ', '/'},
                     { '<', '=', '(', '0', ')', ' '},
                     { ' ', ' ', ' ', ' ', ' ', '\\'}
            };

            //  Enemy 1 Coordinates

            char previous1 = ' ';
            int enemy1X = 9;
            int enemy1Y = 70;
            string enemy1direction = "up";
            int count1 = 0;
            printEnemy1(ref enemy1X, ref enemy1Y, enemy1);

            // Generate Enemy 1 Bullet

            int[] bulletX= new int[100000];
            int[] bulletY=new int[10000];
            bool[] isBulletActive=new bool[10000];
            int bulletCount = 0;

            bool gameRunning = true;
            while (true)
            {
                Thread.Sleep(90);
                
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    moveHeroShipUp(walls, ref heroShipX, ref heroShipY, heroShip);
                }
                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    moveHeroShipDown(walls, ref heroShipX, ref heroShipY, heroShip);
                }
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    moveHeroShipRight(walls, ref heroShipX, ref heroShipY, heroShip);
                }
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    moveHeroShipLeft(walls, ref heroShipX, ref heroShipY, heroShip);
                }

                count1++;
                if (count1 == 5)            // Slowest Movement
                {
                    gameRunning = moveEnemy1(ref enemy1direction, walls, ref enemy1X, ref enemy1Y, ref previous1, ref enemy1X, ref enemy1Y, enemy1);
                    if (gameRunning == false)
                    {
                        break;
                    }
                    count1 = 0;
                }
            }

                Console.ReadKey();
        }
        static void printWalls(char[,] walls)
        {
            for (int x = 0; x < walls.GetLength(0); x++)
            {
                for (int y = 0; y < walls.GetLength(1); y++)
                {
                    Console.Write(walls[x, y]);
                }
                Console.WriteLine();
            }
        }
        
        /////////////Function for moving hero's ship UP
        static void moveHeroShipUp(char[,] walls, ref int heroShipX, ref int heroShipY,char[,] heroShip)
        {
            if (walls[heroShipX - 1, heroShipY] == ' ' || walls[heroShipX - 1, heroShipY] == '.')
            {
                walls[heroShipX, heroShipY] = ' ';
                Console.SetCursorPosition(heroShipY, heroShipX);
                eraseHeroShip(ref heroShipX, ref heroShipY);
                heroShipX = heroShipX - 1;
                Console.SetCursorPosition(heroShipY, heroShipX);
                printHeroShip(ref heroShipX, ref heroShipY, heroShip);
            }
        }

        /////////////Function for moving hero's ship DOWN
        static void moveHeroShipDown(char[,] walls, ref int heroShipX, ref int heroShipY, char[,] heroShip)
        {
            if (walls[heroShipX + 4, heroShipY] == ' ' || walls[heroShipX + 4, heroShipY] == '.')
            {
                walls[heroShipX, heroShipY] = ' ';
                Console.SetCursorPosition(heroShipY, heroShipX);
                eraseHeroShip(ref heroShipX, ref heroShipY);
                heroShipX = heroShipX + 1;
                Console.SetCursorPosition(heroShipY, heroShipX);
                printHeroShip(ref heroShipX, ref heroShipY, heroShip);
            }
        }

        /////////////Function for moving hero's ship RIGHT
        static void moveHeroShipRight(char[,] walls, ref int heroShipX, ref int heroShipY, char[,] heroShip)
        {
            if (walls[heroShipX, heroShipY + 6] == ' ' || walls[heroShipX, heroShipY + 6] == '.')
            {
                walls[heroShipX, heroShipY] = ' ';
                Console.SetCursorPosition(heroShipY, heroShipX);
                eraseHeroShip(ref heroShipX, ref heroShipY);
                heroShipY = heroShipY + 1;
                Console.SetCursorPosition(heroShipY, heroShipX);
                printHeroShip(ref heroShipX, ref heroShipY, heroShip);
            }
        }

        /////////////Function for moving hero's ship LEFT
        static void moveHeroShipLeft(char[,] walls, ref int heroShipX, ref int heroShipY, char[,] heroShip)
        {
            if (walls[heroShipX, heroShipY - 1] == ' ' || walls[heroShipX, heroShipY - 1] == '.')
            {
                walls[heroShipX, heroShipY] = ' ';
                Console.SetCursorPosition(heroShipY, heroShipX);
                eraseHeroShip(ref heroShipX, ref heroShipY);
                heroShipY = heroShipY - 1;
                Console.SetCursorPosition(heroShipY, heroShipX);
                printHeroShip(ref heroShipX, ref heroShipY, heroShip);
            }
        }
        ////////////Function for Printing hero's Ship
        static void printHeroShip(ref int heroShipX, ref int heroShipY, char[,] heroShip)
        {
            Console.SetCursorPosition(heroShipY, heroShipX);
            for (int row = 0; row < 4; row++)
            {
                Console.SetCursorPosition(heroShipY, heroShipX + row);
                for (int col = 0; col < 6; col++)
                {
                    Console.Write(heroShip[row, col]);
                }
            }
        }

        ////////////Function for Erasing hero's Ship
        static void eraseHeroShip(ref int heroShipX,ref int heroShipY)
        {
            for (int row = 0; row < 4; row++)
            {
                Console.SetCursorPosition(heroShipY, heroShipX + row);
                for (int col = 0; col < 6; col++)
                {
                    Console.Write(" ");
                }
            }
        }

        ///////////////////////  Function for printing enemy 1
        static void printEnemy1(ref int enemy1X, ref int enemy1Y, char[,] enemy1)
        {
            Console.SetCursorPosition(enemy1Y, enemy1X);
            for (int row = 0; row < 3; row++)
            {
                Console.SetCursorPosition(enemy1Y, enemy1X + row);
                for (int col = 0; col < 6; col++)
                {
                    Console.Write(enemy1[row, col]);
                }
            }
        }
        static void eraseEnemy1(ref int enemy1X, ref int enemy1Y)
        {
            for (int row = 0; row < 3; row++)
            {
                Console.SetCursorPosition(enemy1Y, enemy1X + row);
                for (int col = 0; col < 6; col++)
                {
                    Console.Write(" ");
                }
            }
        }

        static bool moveEnemy1(ref string direction, char[,] walls, ref int X, ref int Y, ref char previous1,ref int enemy1X,ref int enemy1Y, char[,] enemy1)
        {
            if (direction == "up" && (walls[X - 1, Y] == ' ' || walls[X - 1, Y] == '.'))
            {
                walls[X, Y] = previous1;
                Console.SetCursorPosition(Y, X);
                eraseEnemy1(ref enemy1X, ref enemy1Y);

                X = X - 1;

                previous1 = walls[X, Y];
                Console.SetCursorPosition(Y, X);
                printEnemy1(ref enemy1X, ref enemy1Y, enemy1);

                if (walls[X - 1, Y] == '=' || walls[X - 1, Y] == '|')
                {
                    direction = "down";
                }
            }
            else if (direction == "down" && (walls[X + 1, Y] == ' ' || walls[X + 1, Y] == '.'))
            {
                walls[X, Y] = previous1;
                Console.SetCursorPosition(Y, X);
                eraseEnemy1(ref enemy1X, ref enemy1Y);

                X = X + 1;

                previous1 = walls[X, Y];
                Console.SetCursorPosition(Y, X);
                printEnemy1(ref enemy1X, ref enemy1Y, enemy1);

                if (walls[X + 3, Y] == '=' || walls[X + 3, Y] == '|')
                {
                    direction = "up";
                }
            }
            return true;
        }


        //////////////////////////// Function for generating Hero's Bullet

        static void generateBullet(int[] bulletX,int[] bulletY,ref int bulletCount,ref int heroShipX, ref int heroShipY,bool[] isBulletActive)
        {
            bulletX[bulletCount] = heroShipX + 7;
            bulletY[bulletCount] = heroShipY + 2;
            isBulletActive[bulletCount] = true;
            Console.SetCursorPosition(heroShipX + 7, heroShipY + 2);
            Console.Write("*");
            bulletCount++;
        }
        //////////////////////// Function for loading walls from a file
        static void readData(char[,] walls)
        {
            StreamReader fp = new StreamReader("walls.txt");
            string record;
            int row = 0;
            while ((record = fp.ReadLine()) != null)
            {
                for (int x = 0; x < 110; x++)
                {
                    walls[row, x] = record[x];
                }
                row++;
            }

            fp.Close();
        }
    }
}
