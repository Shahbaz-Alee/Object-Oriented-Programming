using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class PacmanPlayer:GameObject
    {
        public PacmanPlayer(char displayCharacter,GameCell startCell):base(GameObjectType.PLAYER,displayCharacter)
        {
            this.CurrentCell = startCell;
        }
        public GameCell move(GameDirection direction)
        {
            return this.CurrentCell.nextCell(direction);
        }
    }
}
