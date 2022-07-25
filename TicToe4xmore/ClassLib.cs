using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicToe4xmore
{
    public static class ClassLib
    {
        public static string LanguageLib (string LanguageMode)
        {
            return "";
        }
        static int bnt( int i, int j)
        {
            var aray = btnlist;
            return aray[i, j];
        }
        public static int[,] btnlist;
        public static bool GameLogic(int[,] listofbtn, int turn )
        {
             btnlist = listofbtn;
            string size = SettingsClass.PublicSize;
            switch (size)
            {
                case "3x3":
                    if ((bnt(0, 0) == turn && bnt(0, 1) == turn && bnt(0, 2) == turn)||
                        (bnt(1, 0) == turn && bnt(1, 1) == turn && bnt(1, 2) == turn)||
                        (bnt(2, 0) == turn && bnt(2, 1) == turn && bnt(2 ,2) == turn)||
                        //
                        (bnt(0, 0) == turn && bnt(1, 0) == turn && bnt(2, 0) == turn)||
                        (bnt(0, 1) == turn && bnt(1, 1) == turn && bnt(2, 1) == turn)||
                        (bnt(0, 2) == turn && bnt(1, 2) == turn && bnt(2, 2) == turn)||
                        //
                        (bnt(0,0)==turn && bnt(1,1)==turn && bnt(2,2)==turn)||
                        (bnt(0,2) == turn && bnt(1,1)== turn && bnt(2,0) == turn))
                    {
                        return true;
                    }




                    break;
                case "4x4":
                    break;
                case "5x5":
                    break;
                default:
                    break;
            }
            return false;
        }

    }
}
