using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public struct Player
    {
        public string Name;
        public float HP;
        public bool IsVisible;

        public override string ToString()
        {
            return (string.Format("Name {0}, Hp {1},IsVisible {2}", Name, HP, IsVisible));
        }
    }
}

