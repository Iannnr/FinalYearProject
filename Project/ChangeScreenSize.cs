using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class ChangeScreenSize 
    {
        public int[] x;
        public int[] ScreenSize(int index)
        {
            switch (index)
            {
                case 0:
                    x = new int[2] { 498, 445 };
                    break;
                case 1:
                    x = new int[2] { 498, 500 };
                    break;
                case 2:
                    x = new int[2] { 498, 308 };
                    break;
                case 3:
                    x = new int[2] { 600, 308 };
                    break;
                case 4:
                    x = new int[2] { 498, 264 };
                    break;
                case 5:
                    x = new int[2] { 498, 174 };
                    break;
                case 6:
                    x = new int[2] { 498, 506 };
                    break;
                default:
                    x = new int[2] { 600, 398 };
                    break;
            }
            return x;
        }
    }
}
