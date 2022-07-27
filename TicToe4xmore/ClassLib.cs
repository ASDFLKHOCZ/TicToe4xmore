using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicToe4xmore
{
    public static class ClassLib
    {
        public static string LanguageLogic (string LanguageContent)
        {
            switch (SettingsClass.PublicLanguage)
            {
                case "ENG":
                    switch (LanguageContent)
                    {
                        case "infobox": return "This Game was created fF2P. \r\nRule: take 3 identical symbols in a row for win.";
                            break;
                    }
                    break;
                case "UA":
                    switch (LanguageContent)
                    {
                        case "infobox": return "Ця гра створенна для безплатного використання. \r\nПравила: взяти 3 однакових символів для перемога.";
                            break;
                    }
                    break;
                default:
                    return "";
                    break;
            }
            return "";
        }
        static int bnt( int i, int j)
        {
            var aray = btnlist;
            return aray[i, j];
        }

        static bool bntloc(int i, int j, int turn)
        {
            if(bnt(i,j)==turn){return true;}
            else
            {
                return false;
            }
        }
        public static int[,] btnlist;
        public static bool GameLogic(int[,] listofbtn, int turn )
        {
             btnlist = listofbtn;
            string size = SettingsClass.PublicSize;
            switch (size)
            {
                case "3x3":
                    if ((bntloc(0, 0, turn) && bntloc(0, 1, turn) && bntloc(0, 2, turn) )||
                        (bntloc(1, 0, turn) && bntloc(1, 1, turn) && bntloc(1, 2, turn))||
                        (bntloc(2, 0, turn) && bntloc(2, 1, turn) && bntloc(2 ,2, turn))||
                        //
                        (bntloc(0, 0, turn) && bntloc(1, 0, turn) && bntloc(2, 0, turn))||
                        (bntloc(0, 1, turn) && bntloc(1, 1, turn) && bntloc(2, 1, turn))||
                        (bntloc(0, 2, turn) && bntloc(1, 2, turn) && bntloc(2, 2, turn))||
                        //
                        (bntloc(0,0, turn) && bntloc(1,1, turn) && bntloc(2,2, turn))||
                        (bntloc(0,2, turn) && bntloc(1,1, turn) && bntloc(2,0, turn)))
                    {
                        return true;
                    }




                    break;
                case "4x4":
                    if((bntloc(0,0, turn) && bntloc(0,1, turn) && bntloc(0,2, turn))||(bntloc(0,1, turn) && bntloc(0,2, turn) && bntloc(0,3, turn))||
                       (bntloc(1,0, turn) && bntloc(1,1, turn) && bntloc(1,2, turn))||(bntloc(1,1, turn) && bntloc(1,2, turn) && bntloc(1,3, turn))||
                       (bntloc(2,0, turn) && bntloc(2,1, turn) && bntloc(2,2, turn))||(bntloc(2,1, turn) && bntloc(2,2, turn) && bntloc(2,3, turn))||
                       (bntloc(3,0, turn) && bntloc(3,1, turn) && bntloc(3,2, turn))||(bntloc(3,1, turn) && bntloc(3,2, turn) && bntloc(3,3, turn))||
                       //
                       (bntloc(0,0, turn) && bntloc(1,0, turn) && bntloc(2,0, turn))||(bntloc(1,0, turn) && bntloc(2,0, turn) && bntloc(3,0, turn))||
                       (bntloc(0,1, turn) && bntloc(1,1, turn) && bntloc(2,1, turn))||(bntloc(1,1, turn) && bntloc(2,1, turn) && bntloc(3,1, turn))||
                       (bntloc(0,2, turn) && bntloc(1,2, turn) && bntloc(2,2, turn))||(bntloc(1,2, turn) && bntloc(2,2, turn) && bntloc(3,2, turn))||
                       (bntloc(0,3, turn) && bntloc(1,3, turn) && bntloc(2,3, turn))||(bntloc(1,3, turn) && bntloc(2,3, turn) && bntloc(3,3, turn))||
                       //
                       (bntloc(0,0, turn) && bntloc(1,1, turn) && bntloc(2,2, turn))||(bntloc(1,1, turn) && bntloc(2,2, turn) && bntloc(3,3, turn))||
                       (bntloc(0,3, turn) && bntloc(1,2, turn) && bntloc(2,1, turn))||(bntloc(1,2, turn) && bntloc(2,1, turn) && bntloc(3,0, turn))
                    //
                    )
                    {
                        return true;
                    }
                    break;
                case "5x5":
                    if((bntloc(0,0, turn) && bntloc(0,1, turn) && bntloc(0,2, turn))||(bntloc(0,1, turn) && bntloc(0,2, turn) && bntloc(0,3, turn))||(bntloc(0,2, turn) && bntloc(0,3, turn) && bntloc(0,4, turn))||
                       (bntloc(1,0, turn) && bntloc(1,1, turn) && bntloc(1,2, turn))||(bntloc(1,1, turn) && bntloc(1,2, turn) && bntloc(1,3, turn))||(bntloc(1,2, turn) && bntloc(1,3, turn) && bntloc(1,4, turn))||
                       (bntloc(2,0, turn) && bntloc(2,1, turn) && bntloc(2,2, turn))||(bntloc(2,1, turn) && bntloc(2,2, turn) && bntloc(2,3, turn))||(bntloc(2,2, turn) && bntloc(2,3, turn) && bntloc(2,4, turn))||
                       (bntloc(3,0, turn) && bntloc(3,1, turn) && bntloc(3,2, turn))||(bntloc(3,1, turn) && bntloc(3,2, turn) && bntloc(3,3, turn))||(bntloc(3,2, turn) && bntloc(3,3, turn) && bntloc(3,4, turn))||
                       (bntloc(4,0, turn) && bntloc(4,1, turn) && bntloc(4,2, turn))||(bntloc(4,1, turn) && bntloc(4,2, turn) && bntloc(4,3, turn))||(bntloc(4,2, turn) && bntloc(4,3, turn) && bntloc(4,4, turn))||
                       //
                       (bntloc(0,0, turn) && bntloc(1,0, turn) && bntloc(2,0, turn))||(bntloc(1,0, turn) && bntloc(2,0, turn) && bntloc(3,0, turn))||(bntloc(2,0, turn) && bntloc(3,0, turn) && bntloc(4,0, turn))||
                       (bntloc(0,1, turn) && bntloc(1,1, turn) && bntloc(2,1, turn))||(bntloc(1,1, turn) && bntloc(2,1, turn) && bntloc(3,1, turn))||(bntloc(2,1, turn) && bntloc(3,1, turn) && bntloc(4,1, turn))||
                       (bntloc(0,2, turn) && bntloc(1,2, turn) && bntloc(2,2, turn))||(bntloc(1,2, turn) && bntloc(2,2, turn) && bntloc(3,2, turn))||(bntloc(2,2, turn) && bntloc(3,2, turn) && bntloc(4,2, turn))||
                       (bntloc(0,3, turn) && bntloc(1,3, turn) && bntloc(2,3, turn))||(bntloc(1,3, turn) && bntloc(2,3, turn) && bntloc(3,3, turn))||(bntloc(2,3, turn) && bntloc(3,3, turn) && bntloc(4,3, turn))||
                       (bntloc(0,4, turn) && bntloc(1,4, turn) && bntloc(2,4, turn))||(bntloc(1,4, turn) && bntloc(2,4, turn) && bntloc(3,4, turn))||(bntloc(2,4, turn) && bntloc(3,4, turn) && bntloc(4,4, turn))||
                       //
                       (bntloc(0,0, turn) && bntloc(1,1, turn) && bntloc(2,2, turn))||(bntloc(1,1, turn) && bntloc(2,2, turn) && bntloc(3,3, turn))||(bntloc(2,2, turn) && bntloc(3,3, turn) && bntloc(4,4, turn))||
                       (bntloc(0,4, turn) && bntloc(1,3, turn) && bntloc(2,2, turn))||(bntloc(1,3, turn) && bntloc(2,2, turn) && bntloc(3,1, turn))||(bntloc(2,2, turn) && bntloc(3,1, turn) && bntloc(4,0, turn))
                    //
                    )
                    {
                        return true;
                    }
                    break;
                default:
                    break;
            }
            return false;
        }

    }
}
