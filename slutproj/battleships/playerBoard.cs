using System;
using System.Collections.Generic;

namespace battleships
{
    public class playerBoard
    {
        //skapar 3 int arrayer, 1 string array och 1 int
        //den första inten pxy sparar information om kartan och uppdateringar (2-3 som vi såg i enemyAttack metoden)
        //den andra int arrayer är för spelarens skepp och sparar alla platser där de är
        //eHitReg är för de positioner man väljer att skjuta fienden och sparar alla positioner man valt
        //playerBoardInfo är för kart uppdateringar som syns för spelaren
        //och sist points som blir +1 för varje träff
        public int[] pxy = new int[100];
        public int[] pShipLocation = new int[26];
        public int[] eHitReg = new int [100];
        string[] playerBoardInfo = new string[100];
        public int points;
        //detta är metoden för att placera sinna skepp
        public void PlaceBoard()
        {
            
            for(int i = 0; i < pShipLocation.Length; i++)
            {
                pShipLocation[i] = -1;
            }
            int placeShip = 1;
            while (placeShip == 1)
            {
                //man kan placera 3st 2 långa, därför blir det +2 och <6
                for(int i = 0; i < 6; i += 2)
                {
                    int p = 1;   
                    while (p != 0)
                    {
                        Console.WriteLine("place your destroyers (0-99)");
                        Map();
                        string place = Console.ReadLine();
                        int placeLocation;
                        bool success = int.TryParse(place, out placeLocation);
                        if(placeLocation < 100 && success)
                        {
                            
                            Console.Clear();
                            Console.WriteLine("Select Rotation (W A S D)");
                            Map();
                            place = Console.ReadLine();
                            if((place == "w" || place == "W") && placeLocation > 9)
                            {
                                //alla dessa ifsatser är basically likadana, de kollar om platsen är upptagen, om det blir collision och om den kommer krocka in i väggen så säger den till att man inte kan lägga där
                                if(Collision(2, 0, placeLocation))
                                {
                                    continue;
                                }
                                else
                                {   
                                    pShipLocation[i] = placeLocation;
                                    pShipLocation[i + 1] = placeLocation - 10;
                                    p--;
                                }
                                
                            }
                            else if((place == "a" || place == "A") && placeLocation % 10 != 0)
                            {
                                if(Collision(2, 3, placeLocation))
                                {
                                    continue;
                                }
                                else
                                {
                                pShipLocation[i] = placeLocation;
                                pShipLocation[i + 1] = placeLocation - 1;
                                p--;
                                }
                            }
                            else if((place == "s" || place == "S") && placeLocation < 90)
                            {
                                if(Collision(2, 2, placeLocation))
                                {
                                    continue;
                                }
                                else
                                {
                                pShipLocation[i] = placeLocation;
                                pShipLocation[i + 1] = placeLocation + 10;
                                p--;
                                }
                            }
                            else if((place == "d" || place == "D") && placeLocation % 10 != 9)
                            {
                                if(Collision(2, 1, placeLocation))
                                {
                                    continue;
                                }
                                else
                                {
                                pShipLocation[i] = placeLocation;
                                pShipLocation[i + 1] = placeLocation + 1;
                                p--;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Could not place");
                            }
                            for(int z = 0; z < pShipLocation.Length; z++)
                            {
                                try
                                {
                                    pxy[pShipLocation[z]] = 1;
                                }
                                catch{}
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("not a correct answer");
                        }
                         
                    }
                }
                for(int i = 6; i < 12; i += 3)
                {
                    int p = 1;
                    while (p != 0)
                    {
                        Console.Clear();
                        Console.WriteLine("place your light cruisers (0-99)");
                        Map();
                        string place = Console.ReadLine();
                        int placeLocation;
                        bool success = int.TryParse(place, out placeLocation);
                        if(placeLocation < 100 && success)
                        {
                            Console.Clear();
                            Console.WriteLine("Select Rotation (W A S D)");
                            Map();
                            place = Console.ReadLine();
                            if((place == "w" || place == "W") && placeLocation > 19)
                            {
                                if(Collision(3, 0, placeLocation))
                                {
                                    continue;
                                }
                                else
                                {
                                    pShipLocation[i] = placeLocation;
                                    pShipLocation[i + 1] = placeLocation - 10;
                                    pShipLocation[i + 2] = placeLocation - 20;
                                    p--;
                                }
                            }
                            else if((place == "a" || place == "A") && placeLocation % 10 > 1)
                            {
                                if(Collision(3, 3, placeLocation))
                                {
                                    continue;
                                }
                                else
                                {
                                pShipLocation[i] = placeLocation;
                                pShipLocation[i + 1] = placeLocation - 1;
                                pShipLocation[i + 2] = placeLocation - 2;
                                p--;
                                }
                            }
                            else if((place == "s" || place == "S") && placeLocation < 80)
                            {
                                if(Collision(3, 2, placeLocation))
                                {
                                    continue;
                                }
                                else
                                {
                                pShipLocation[i] = placeLocation;
                                pShipLocation[i + 1] = placeLocation + 10;
                                pShipLocation[i + 2] = placeLocation + 20;
                                p--;
                                }
                            }
                            else if((place == "d" || place == "D") && placeLocation % 10 < 8)
                            {
                                if(Collision(3, 1, placeLocation))
                                {
                                    continue;
                                }
                                else
                                {
                                pShipLocation[i] = placeLocation;
                                pShipLocation[i + 1] = placeLocation + 1 ;
                                pShipLocation[i + 2] = placeLocation + 2;
                                p--;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Could not place");
                            }
     
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("not a correct answer");
                        }
                        for(int z = 0; z < pShipLocation.Length; z++)
                        {
                            try
                            {
                                pxy[pShipLocation[z]] = 1;
                            }
                            catch{}
                        }   
                    }
                }
                for(int i = 12; i < 20; i += 4)
                {
                    int p = 1;
                    while (p != 0)
                    {
                        Console.Clear();
                        Console.WriteLine("place your heavy cruisers (0-99)");
                        Map();
                        string place = Console.ReadLine();
                        int placeLocation;
                        bool success = int.TryParse(place, out placeLocation);
                        if(placeLocation < 100 && success)
                        {
                            Console.Clear();
                            Console.WriteLine("Select Rotation (W A S D)");
                            Map();
                            place = Console.ReadLine();
                            if((place == "w" || place == "W") && placeLocation > 29)
                            {
                                if(Collision(4, 0, placeLocation))
                                {
                                    continue;
                                }
                                else
                                {
                                    pShipLocation[i] = placeLocation;
                                    pShipLocation[i + 1] = placeLocation - 10;
                                    pShipLocation[i + 2] = placeLocation - 20;
                                    pShipLocation[i + 3] = placeLocation - 30;
                                    p--;
                                }
                            }
                            else if((place == "a" || place == "A") && placeLocation % 10 > 2)
                            {
                                if(Collision(4, 3, placeLocation))
                                {
                                    continue;
                                }
                                else
                                {
                                pShipLocation[i] = placeLocation;
                                pShipLocation[i + 1] = placeLocation - 1;
                                pShipLocation[i + 2] = placeLocation - 2;
                                pShipLocation[i + 3] = placeLocation - 3;
                                p--;
                                }
                            }
                            else if((place == "s" || place == "S") && placeLocation < 70)
                            {
                                if(Collision(4, 2, placeLocation))
                                {
                                    continue;
                                }
                                else
                                {
                                pShipLocation[i] = placeLocation;
                                pShipLocation[i + 1] = placeLocation + 10;
                                pShipLocation[i + 2] = placeLocation + 20;
                                pShipLocation[i + 3] = placeLocation + 30;
                                p--;
                                }
                            }
                            else if((place == "d" || place == "D") && placeLocation % 10 < 7)
                            {
                                if(Collision(4, 1, placeLocation))
                                {
                                    continue;
                                }
                                else
                                {
                                pShipLocation[i] = placeLocation;
                                pShipLocation[i + 1] = placeLocation + 1;
                                pShipLocation[i + 2] = placeLocation + 2;
                                pShipLocation[i + 3] = placeLocation + 3;
                                p--;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Could not place");
                            }
     
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("not a correct answer");
                        } 
                        for(int z = 0; z < pShipLocation.Length; z++)
                        {
                            try
                            {
                                pxy[pShipLocation[z]] = 1;
                            }
                            catch{}
                        } 
                    }
                }
                for(int i = 20; i < 26; i += 6)
                {
                    int p = 1;
                    while (p != 0)
                    {
                        Console.Clear();
                        Console.WriteLine("place your carrier (0-99)");
                        Map();
                        string place = Console.ReadLine();
                        int placeLocation;
                        bool success = int.TryParse(place, out placeLocation);
                        if(placeLocation < 100 && success)
                        {
                            Console.Clear();
                            Console.WriteLine("Select Rotation (W A S D)");
                            Map();
                            place = Console.ReadLine();
                            if((place == "w" || place == "W") && placeLocation > 49)
                            {
                                if(Collision(6, 0, placeLocation))
                                {
                                    continue;
                                }
                                else
                                {
                                    pShipLocation[i] = placeLocation;
                                    pShipLocation[i + 1] = placeLocation - 10;
                                    pShipLocation[i + 2] = placeLocation - 20;
                                    pShipLocation[i + 3] = placeLocation - 30;
                                    pShipLocation[i + 4] = placeLocation - 40;
                                    pShipLocation[i + 5] = placeLocation - 50;
                                    p--;
                                }
                            }
                            else if((place == "a" || place == "A") && placeLocation % 10 > 4)
                            {
                                if(Collision(6, 3, placeLocation))
                                {
                                    continue;
                                }
                                else
                                {
                                pShipLocation[i] = placeLocation;
                                pShipLocation[i + 1] = placeLocation - 1;
                                pShipLocation[i + 2] = placeLocation - 2;
                                pShipLocation[i + 3] = placeLocation - 3;
                                pShipLocation[i + 4] = placeLocation - 4;
                                pShipLocation[i + 5] = placeLocation - 5;
                                p--;
                                }
                            }
                            else if((place == "s" || place == "S") && placeLocation < 50)
                            {
                                if(Collision(6, 2, placeLocation))
                                {
                                    continue;
                                }
                                else
                                {
                                pShipLocation[i] = placeLocation;
                                pShipLocation[i + 1] = placeLocation + 10;
                                pShipLocation[i + 2] = placeLocation + 20;
                                pShipLocation[i + 3] = placeLocation + 30;
                                pShipLocation[i + 4] = placeLocation + 40;
                                pShipLocation[i + 5] = placeLocation + 50;
                                p--;
                                }
                            }
                            else if((place == "d" || place == "D") && placeLocation % 10 < 5)
                            {
                                if(Collision(6, 1, placeLocation))
                                {
                                    continue;
                                }
                                else
                                {
                                pShipLocation[i] = placeLocation;
                                pShipLocation[i + 1] = placeLocation++;
                                pShipLocation[i + 2] = placeLocation + 2;
                                pShipLocation[i + 3] = placeLocation + 3;
                                pShipLocation[i + 4] = placeLocation + 4;
                                pShipLocation[i + 5] = placeLocation + 5;
                                p--;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Could not place");
                            }
     
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("not a correct answer");
                        }
                        for(int z = 0; z < pShipLocation.Length; z++)
                        {
                            try
                            {
                                pxy[pShipLocation[z]] = 1;
                            }
                            catch{}
                        }   
                    }
                }
            placeShip = 0;
            
            }
            
        }
        //här är det som kollar collision, den tar in längd, hållet den är riktad mot och positionen
        //den kollar sedan om de positioner är upptagna om de är så breakar den och man får true
        //annars ger den fasle och man kan fortsätta.
        private bool Collision(int length, int direction, int position)
        {   
            bool exists;
            exists = false;
            for (int i = 0; i < pShipLocation.Length; i++)
                {
                    for (int k = 0; k < length; k++) 
                    {
                        switch(direction) 
                        {
                            case 1:
                            if (pShipLocation[i] == position + k)
                            {
                                exists = true;
                                break;
                            }
                            break;
                            case 2:
                            if (pShipLocation[i] == position + k*10)
                            {
                                exists = true;
                                break;
                            }
                            break;
                            case 0:
                            if (pShipLocation[i] == position - k*10)
                            {
                                exists = true;
                                break;
                            }
                            break;
                                default:
                                if (pShipLocation[i] == position - k)
                            {
                                exists = true;
                                break;
                            }
                            break;
                        }
                        if(exists)
                        {
                            break;
                        }  
                    }
                    if(exists)
                    {
                        break;
                    }
                }
                return exists;
        }
        
        public void Map()
        {
            for(int i = 0; i < pxy.Length; i++)
            {
                if(pxy[i] == 0)
                {
                    playerBoardInfo[i] = " ";
                }
                else if(pxy[i] == 1)
                {
                    playerBoardInfo[i] = "S";
                }
                else if(pxy[i] == 3)
                {
                    playerBoardInfo[i] = "O";
                }
                else if(pxy[i] == 2)
                {
                    playerBoardInfo[i] = "X";
                }
                else
                {
                    playerBoardInfo[i] = "Error";
                }
            }
            Console.WriteLine("   Player Map:");
            Console.WriteLine("     0   1   2   3   4   5   6   7   8   9  ");
            Console.WriteLine("   _________________________________________");
            Console.WriteLine(" 0 | " + playerBoardInfo[0] + " | " + playerBoardInfo[1] + " | " + playerBoardInfo[2] + " | " + playerBoardInfo[3] + " | " + playerBoardInfo[4] + " | " + playerBoardInfo[5] + " | " + playerBoardInfo[6] + " | " + playerBoardInfo[7] + " | " + playerBoardInfo[8] + " | " + playerBoardInfo[9] + " |");
            for(int i = 10; i < 100; i += 10)
            {
                Console.WriteLine("   =========================================");
                Console.WriteLine(i + " | " + playerBoardInfo[i] + " | " + playerBoardInfo[i+1] + " | " + playerBoardInfo[i+2] + " | " + playerBoardInfo[i+3] + " | " + playerBoardInfo[i+4] + " | " + playerBoardInfo[i+5] + " | " + playerBoardInfo[i+6] + " | " + playerBoardInfo[i+7] + " | " + playerBoardInfo[i+8] + " | " + playerBoardInfo[i+9] + " | "); 
            }

            Console.WriteLine("   =========================================");
            Console.WriteLine("    90  91  92  93  94  95  96  97  98  99 ");
        }
    }
}
