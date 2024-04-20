using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EZInput;

namespace Pacman
{
    internal class PacmanGame
    {
        static void Main(string[] args)
        {
            GameGrid grid = new GameGrid("maze.txt", 24, 71);
            GameCell start = new GameCell(12, 22, grid);
            GameCell startHorizontalGhost = new GameCell(16, 10, grid);
            PacmanPlayer pacman = new PacmanPlayer('P', start);
            HorizontalGhost ghost = new HorizontalGhost('G', startHorizontalGhost); // Creating an instance of HorizontalGhost
            printMaze(grid);
            printGameObject(pacman);
            printGameObject(ghost); // Print the ghost on the grid
            bool gameRunning = true;
            while (gameRunning)
            {
                Thread.Sleep(90);
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    moveGameObject(pacman, GameDirection.Up);
                }
                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    moveGameObject(pacman, GameDirection.Down);
                }
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    moveGameObject(pacman, GameDirection.Left);
                }
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    moveGameObject(pacman, GameDirection.Right);
                }

                // Move the HorizontalGhost
                GameCell nextCell = ghost.move(GameDirection.Left);
                if (nextCell != null)
                {
                    clearGameCellContent(ghost.CurrentCell, new GameObject(GameObjectType.None, ' '));
                    ghost.CurrentCell = nextCell;
                    printGameObject(ghost);
                    
                }
            }
        }
        static void clearGameCellContent(GameCell gameCell, GameObject newGameObject)
        {
            gameCell.CurrentGameObject = newGameObject;
            Console.SetCursorPosition(gameCell.Y, gameCell.X);
            Console.WriteLine(newGameObject.DisplayCharacter);
        }
        static void printGameObject(GameObject gameObject)
        {
            Console.SetCursorPosition(gameObject.CurrentCell.Y, gameObject.CurrentCell.X);
            Console.WriteLine(gameObject.DisplayCharacter);
        }
        static void moveGameObject(GameObject gameObject, GameDirection direction)
        {
            GameCell nextCell = gameObject.CurrentCell.nextCell(direction);
            if (nextCell != null)
            {
                GameObject newGO = new GameObject(GameObjectType.None, ' ');
                GameCell currentCell = gameObject.CurrentCell;
                clearGameCellContent(currentCell, newGO);
                gameObject.CurrentCell = nextCell;
                printGameObject(gameObject);
            }
        }
        static void printMaze(GameGrid grid)
        {
            for(int x=0; x<grid.Rows; x++)
            {
                for(int y=0;y<grid.Cols; y++)
                {
                    GameCell cell=grid.getCell(x,y);
                   // GameCell cell = grid.getCell(x, y);
                    printCell(cell);
                }
            }
        }
        static void printCell(GameCell cell)
        {
            Console.SetCursorPosition(cell.Y, cell.X);
            Console.WriteLine( cell.CurrentGameObject.DisplayCharacter);
        }
    }
}

