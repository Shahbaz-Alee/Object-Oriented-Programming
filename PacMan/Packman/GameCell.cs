﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class GameCell
    {
        public int x;
        public int y;
        GameObject currentGameObject;
        GameGrid grid;

        public GameCell(int x, int y, GameGrid grid)
        {
            this.x = x;
            this.y = y;
            this.grid = grid;
        }
        public GameCell Right
        {
            get
            {
                if (y < grid.Cols - 1)
                {
                    return grid.getCell(x, y + 1);
                }
                else
                {
                    return null;
                }
            }
        }

        public GameCell Left
        {
            get
            {
                if (y > 0)
                {
                    return grid.getCell(x, y - 1);
                }
                else
                {
                    return null;
                }
            }
        }
        public GameCell nextCell(GameDirection direction)
        {
            if (direction == GameDirection.Left)
            {
                if (this.y > 0)
                {
                    GameCell ncell = grid.getCell(x, y - 1);
                    if (ncell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                    {
                        return ncell;
                    }
                }
            }
            if (direction == GameDirection.Right)
            {
                if (this.y < grid.Cols - 1)
                {
                    GameCell ncell = grid.getCell(this.x, this.y + 1);
                    if (ncell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                    {
                        return ncell;
                    }
                }
            }
            if (direction == GameDirection.Up)
            {
                if (this.x > 0)
                {
                    GameCell ncell = grid.getCell(this.x - 1, this.y);
                    if (ncell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                    {
                        return ncell;
                    }
                }
            }
            if (direction == GameDirection.Down)
            {
                if (this.x < grid.Rows - 1)
                {
                    GameCell ncell = grid.getCell(this.x + 1, this.y);
                    if (ncell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                    {
                        return ncell;
                    }
                }
            }
            return this;
        }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public GameObject CurrentGameObject { get => currentGameObject; set => currentGameObject = value; }
    }
}
