using System;
using System.Collections.Generic;
using System.Text;

namespace Spymongus.Sprites
{
    class Node : Sprite
    {
        private int node;

        public Node() => this.node = node;
        public defaultNodes()
        {          
            for (int x = 0; x < node; x++)
            {
                if ( node == 0)
                {
                    return "Test" + node;
                }
                else
                {
                    return "Test" false;
                }
            }
        }

        //        var whitePixels = 0;
        //        var blackPixels = 0;
        //        for (int i = 0; i<image.width; i++)
        //          for (int j = 0; j<image.height; j++)
        //          { 
        //              Color pixel = image.GetPixel(i, j);

        //              // if it's a white color then just debug...
        //              if (pixel == Color.white)
        //                  whitePixels++;
        //              else 
        //                  blackPixels++;
        //           }
        //    Debug.Log(string.Format("White pixels {0}, black pixels {1}", whitePixels, blackPixels));

//        Texture2D[] _rCards, _bCards, _sCards;
//        _bCards = new Texture2D[9]; 
//_rCards = new Texture2D[9];
//_sCards = new Texture2D[6];

//for (int i = 1; i< 10; i++)
//{
//    _bCards[i] = Content.Load<Texture2D>("Images/Common/Black/"+i);
//    _rCards[i] = Content.Load<Texture2D>("Images/Common/Red/"+i);
//    if(i<6)
//        _sCards[i] = Content.Load<Texture2D>("Images/Special/Card" + (i-1));
//}

    }
}
