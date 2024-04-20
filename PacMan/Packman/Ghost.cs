﻿using Pacman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    abstract class Ghost : GameObject
    {
        public Ghost(char displayCharacter, GameCell startCell) : base(GameObjectType.ENEMY, displayCharacter)
        {
            this.CurrentCell = startCell;
        }
        public abstract GameCell move(GameDirection direction);
    }
    
}
