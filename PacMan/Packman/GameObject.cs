using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class GameObject
    {
        char displayCharacter;
        GameObjectType gameObjectType;
        GameCell currentCell;
        public GameObject(GameObjectType type, char dispalyCharacter)
        {
            this.displayCharacter = dispalyCharacter;
            this.gameObjectType = type;
        }
        public static GameObjectType getGameObjectType(char displayCharacter)
        {
            if (displayCharacter == '|' || displayCharacter == '%' || displayCharacter == '#')
            {
                return GameObjectType.WALL;
            }
            if (displayCharacter == '.')
            {
                return GameObjectType.REWARD;
            }
            if (displayCharacter == 'G') // Add condition for the HorizontalGhost display character
            {
                return GameObjectType.ENEMY; // Add a new GameObjectType for the HorizontalGhost
            }
            return GameObjectType.None;
        }
        public char DisplayCharacter { get => displayCharacter; set => displayCharacter = value; }
        public GameObjectType GameObjectType { get => gameObjectType; set => gameObjectType = value; }
        public GameCell CurrentCell
        {
            get => currentCell;
            set
            {
                currentCell = value;
                currentCell.CurrentGameObject = this;
            }
        }
    }
}
