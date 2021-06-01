using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Text;

namespace Spymongus.Sprites
{
    class Role
    {
        private Hat hat;
        private bool hasHat = false;
        public int[] crew = { 1, 2, 3, 4, 5, 6, 7 };
        Random rndHat = new Random();

        public void getHat()
        {
            for ( int i = 0; i < hat.hats.Length; i++ )
           {
                rndHat.Next(1);
                hasHat = true;
            }
        }
    }
}
