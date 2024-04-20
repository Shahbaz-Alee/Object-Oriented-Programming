using Pacman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class HorizontalGhost : Ghost
    {
        public HorizontalGhost(char displayCharacter, GameCell startCell) : base(displayCharacter, startCell)
        {
            this.CurrentCell = startCell;
        }

        public override GameCell move(GameDirection direction)
        {
            GameCell nextCell = CurrentCell.nextCell(direction);

            if (nextCell != null)
            {
                char nextCellCharacter = nextCell.CurrentGameObject.DisplayCharacter;

                if (nextCellCharacter == '|' || nextCellCharacter == '#' || nextCellCharacter == '%')
                {
                    // Reverse the direction
                    if (direction == GameDirection.Left)
                        direction = GameDirection.Right;
                    else if (direction == GameDirection.Right)
                        direction = GameDirection.Left;
                }

                // Move to the next cell based on the updated direction
                nextCell = CurrentCell.nextCell(direction);
            }

            return nextCell;
        }
    }
}
