using System.Net.WebSockets;
using System.CodeDom.Compiler;
using System;
using System.Collections.Generic;

namespace battleships
{
    public class EnemyBoard
    {
        //skapar alla olika ints och strings som behövs för att skapa ai som kan skjuta och placera skepp helt själv
        Random generator = new Random();
        public int[] exy = new int[100];
        public int[] eShipLocation = new int[26];
        public int[] pHitReg = new int [100];
        public string[] boardUpdate = new string [100];
        public int[] twoLong = new int [6];
        public int[] threeLong = new int[6];
        public int[] fourLong = new int[8];       
        public int[] sixLong = new int[6];
        public int points;
        
        //denna gör alla till -1 så att det inte förstör collision då 0 är en plats på rutan.
        public void EnemyPlaceBoard()
        {
            for(int i = 0; i < twoLong.Length; i++)
            {
                twoLong[i] = -1;
            }
            for(int i = 0; i < threeLong.Length; i++)
            {
                threeLong[i] = -1;
            }
            for(int i = 0; i < fourLong.Length; i++)
            {
                fourLong[i] = -1;
            }
            for(int i = 0; i < sixLong.Length; i++)
            {
                sixLong[i] = -1;
            }
           
            //detta är för att placera alla två långa genom att randomisera positioner och kolla om det är upptaget likt collision i spelar placeringen
            //om platsen är upptagen kommer den att skapa ett nytt nummer och testa tills det är en ledig plats
            for (int i = 0; i < twoLong.Length; i += 2)
            {
                //positionen skapas från 0-3 0=höger 1=ner 2=upp 3=vänster
                int pos = generator.Next(0,3);
                twoLong[i] = generateTwoLongNumber(twoLong, threeLong, fourLong, sixLong, pos, 2);

                //dessa kollar så att båten kan placeras där, eftersom att den är två lång kan den inte gå åt höger om den är på 9,19,29ect positionerna
                if(twoLong[i] % 10 != 9) 
                {
                    
                    if(pos == 0)
                    {
                        twoLong[i + 1] = twoLong[i] + 1; 
                    }
                    else if(pos == 1 && twoLong[i] < 90)
                    {
                        twoLong[i + 1] = twoLong[i] + 10;
                    }
                    else if(pos == 2 && twoLong[i] > 9)
                    {
                        twoLong[i + 1] = twoLong[i] - 10;
                    }
                    else
                    {
                        twoLong[i + 1] = twoLong[i] + 1;
                    }
                }
                //samma sak med denna, fast denna gör så att den åker åt vänster om den är vid 9-99. Alla position randomziers funkar så jag kommer
                //inte skriva något mer om det.
                else 
                {
                    if(pos == 0 && twoLong[i] % 10 != 9)
                    {
                        twoLong[i + 1] = twoLong[i] + 1;
                    }
                    else if(pos == 1 && twoLong[i] < 90)
                    {
                        twoLong[i +1] = twoLong[i] + 10;
                    }
                    else if(pos == 2 && twoLong[i] > 9)
                    {
                        twoLong[i + 1] = twoLong[i] - 10;
                    }
                    else
                    {
                        twoLong[i + 1] = twoLong[i] - 1;
                    }
                }
            }
            
            for (int i = 0; i < threeLong.Length; i += 3)
            {
                int pos = generator.Next(0,3);
                threeLong[i] = generateTwoLongNumber(twoLong, threeLong, fourLong, sixLong, pos, 3);
                //8 18 28 38 48 58 68 78 88 98
                if(threeLong[i] % 10 < 8) 
                {
                    if(pos == 0)
                    {
                        threeLong[i + 1] = threeLong[i] + 1; 
                        threeLong[i + 2] = threeLong[i] + 2; 
                    }
                    else if(pos == 1 && threeLong[i] < 80)
                    {
                        threeLong[i + 1] = threeLong[i] + 10;
                        threeLong[i + 2] = threeLong[i] + 20;
                    }
                    else if(pos == 2 && threeLong[i] > 19)
                    {
                        threeLong[i + 1] = threeLong[i] - 10;
                        threeLong[i + 2] = threeLong[i] - 20;
                    }
                    else
                    {
                        threeLong[i + 1] = threeLong[i] + 1;
                        threeLong[i + 2] = threeLong[i] + 2;
                    }
                }
                else 
                {
                    if(pos == 0 && threeLong[i] % 10 < 8)
                    {
                        threeLong[i + 1] = threeLong[i] + 1;
                        threeLong[i + 2] = threeLong[i] + 2;
                    }
                    else if(pos == 1 && threeLong[i] < 80)
                    {
                        threeLong[i + 1] = threeLong[i] + 10;
                        threeLong[i + 2] = threeLong[i] + 20;
                    }
                    else if(pos == 2 && threeLong[i] > 19)
                    {
                        threeLong[i + 1] = threeLong[i] - 10;
                        threeLong[i + 2] = threeLong[i] - 20;
                    }
                    else
                    {
                        threeLong[i + 1] = threeLong[i] - 1;
                        threeLong[i + 2] = threeLong[i] - 2;
                    }
                }
            }
            for (int i = 0; i < fourLong.Length; i += 4)
            {
                int pos = generator.Next(0,3);
                fourLong[i] = generateTwoLongNumber(twoLong, threeLong, fourLong, sixLong, pos, 4);
                //8 18 28 38 48 58 68 78 88 98
                if(fourLong[i] % 10 < 7) 
                {
                    if(pos == 0)
                    {
                        fourLong[i + 1] = fourLong[i] + 1; 
                        fourLong[i + 2] = fourLong[i] + 2; 
                        fourLong[i + 3] = fourLong[i] + 3; 
                    }
                    else if(pos == 1 && fourLong[i] < 70)
                    {
                        fourLong[i + 1] = fourLong[i] + 10;
                        fourLong[i + 2] = fourLong[i] + 20;
                        fourLong[i + 3] = fourLong[i] + 30;
                    }
                    else if(pos == 2 && fourLong[i] > 29)
                    {
                        fourLong[i + 1] = fourLong[i] - 10;
                        fourLong[i + 2] = fourLong[i] - 20;
                        fourLong[i + 3] = fourLong[i] - 30;
                    }
                    else
                    {
                        fourLong[i + 1] = fourLong[i] + 1; 
                        fourLong[i + 2] = fourLong[i] + 2; 
                        fourLong[i + 3] = fourLong[i] + 3; 
                    }
                }
                else 
                {
                    if(pos == 0 && fourLong[i] % 10 < 7)
                    {
                        fourLong[i + 1] = fourLong[i] + 1; 
                        fourLong[i + 2] = fourLong[i] + 2; 
                        fourLong[i + 3] = fourLong[i] + 3; 
                    }
                    else if(pos == 1 && fourLong[i] < 70)
                    {
                        fourLong[i + 1] = fourLong[i] + 10;
                        fourLong[i + 2] = fourLong[i] + 20;
                        fourLong[i + 3] = fourLong[i] + 30;
                    }
                    else if(pos == 2 && fourLong[i] > 29)
                    {
                        fourLong[i + 1] = fourLong[i] - 10;
                        fourLong[i + 2] = fourLong[i] - 20;
                        fourLong[i + 3] = fourLong[i] - 30;
                    }
                    else
                    {
                        fourLong[i + 1] = fourLong[i] - 1; 
                        fourLong[i + 2] = fourLong[i] - 2; 
                        fourLong[i + 3] = fourLong[i] - 3; 
                    }
                }
            }
            for (int i = 0; i < sixLong.Length; i += 6)
            {
                int pos = generator.Next(0,3);
                sixLong[i] = generateTwoLongNumber(twoLong, threeLong, fourLong, sixLong, pos,6);
                //8 18 28 38 48 58 68 78 88 98
                if(sixLong[i] % 10 < 5) 
                {
                    if(pos == 0)
                    {
                        sixLong[i + 1] = sixLong[i] + 1; 
                        sixLong[i + 2] = sixLong[i] + 2; 
                        sixLong[i + 3] = sixLong[i] + 3; 
                        sixLong[i + 4] = sixLong[i] + 4; 
                        sixLong[i + 5] = sixLong[i] + 5; 
                    }
                    else if(pos == 1 && sixLong[i] < 50)
                    {
                        sixLong[i + 1] = sixLong[i] + 10;
                        sixLong[i + 2] = sixLong[i] + 20;
                        sixLong[i + 3] = sixLong[i] + 30;
                        sixLong[i + 4] = sixLong[i] + 40;
                        sixLong[i + 5] = sixLong[i] + 50;
                    }
                    else if(pos == 2 && sixLong[i] > 49)
                    {
                        sixLong[i + 1] = sixLong[i] - 10;
                        sixLong[i + 2] = sixLong[i] - 20;
                        sixLong[i + 3] = sixLong[i] - 30;
                        sixLong[i + 4] = sixLong[i] - 40;
                        sixLong[i + 5] = sixLong[i] - 50;
                    }
                    else
                    {
                        sixLong[i + 1] = sixLong[i] + 1; 
                        sixLong[i + 2] = sixLong[i] + 2; 
                        sixLong[i + 3] = sixLong[i] + 3; 
                        sixLong[i + 4] = sixLong[i] + 4; 
                        sixLong[i + 5] = sixLong[i] + 5; 
                    }
                }
                else 
                {
                    if(pos == 0 && sixLong[i] % 10 < 5)
                    {
                        sixLong[i + 1] = sixLong[i] + 1; 
                        sixLong[i + 2] = sixLong[i] + 2; 
                        sixLong[i + 3] = sixLong[i] + 3; 
                        sixLong[i + 4] = sixLong[i] + 4; 
                        sixLong[i + 5] = sixLong[i] + 5; 
                    }
                    else if(pos == 1 && fourLong[i] < 50)
                    {
                        sixLong[i + 1] = sixLong[i] + 10;
                        sixLong[i + 2] = sixLong[i] + 20;
                        sixLong[i + 3] = sixLong[i] + 30;
                        sixLong[i + 4] = sixLong[i] + 40;
                        sixLong[i + 5] = sixLong[i] + 50;
                    }
                    else if(pos == 2 && fourLong[i] > 49)
                    {
                        sixLong[i + 1] = sixLong[i] - 10;
                        sixLong[i + 2] = sixLong[i] - 20;
                        sixLong[i + 3] = sixLong[i] - 30;
                        sixLong[i + 4] = sixLong[i] - 40;
                        sixLong[i + 5] = sixLong[i] - 50;
                    }
                    else
                    {
                        sixLong[i + 1] = sixLong[i] - 1; 
                        sixLong[i + 2] = sixLong[i] - 2; 
                        sixLong[i + 3] = sixLong[i] - 3; 
                        sixLong[i + 4] = sixLong[i] - 4; 
                        sixLong[i + 5] = sixLong[i] - 5; 
                    }
                }
            }
            //här sammlar man all data, eftersom att alla skepp är olika långa och många är det svårt att göra allt detta i eShipLocation
            //då man måste veta hur många/långa de är och variera platser i arrayen efter det.
            //så då måste man sammla dem i eShipLocation tillslut så att man kan få dem på kartan
            for(int i = 0; i < twoLong.Length; i ++)
            {
                eShipLocation[i] = twoLong[i];
            }
            for(int i = 0; i < threeLong.Length; i ++)
            {
                eShipLocation[i + twoLong.Length] = threeLong[i];
            }
            for(int i = 0; i < fourLong.Length; i ++)
            {
                eShipLocation[i + twoLong.Length + threeLong.Length] = fourLong[i];
            }
            for(int i = 0; i < sixLong.Length; i ++)
            {
                eShipLocation[i + twoLong.Length + threeLong.Length + fourLong.Length] = sixLong[i];
            }
        }
            //här är collision för AI.
            private int generateTwoLongNumber(int[] twoLong, int[] threeLong, int[] fourLong, int[] sixLong, int direction, int length)
{
            Random generator = new Random();
            int number;
            bool exists;
            //den fungerar på samma sätt som spelaren bara att denhära randomizar nummer åt AI istället för att spelaren väljer, så den bestämmer en position
            //och kollar om den fungerar av sigsjälv. Detta gör den genom att kolla riktningen som skeppet har, dess längd som då simuleras och kollar
            //om den har fritt rum på alla platser. 
            do 
            {
                exists = false;
                number = generator.Next(100);
                if(direction == 0 && number % 10 > 10-length)
                {
                    direction = -1;
                }
                for (int i = 0; i < twoLong.Length; i++)
                {
                    for (int k = 0; k < length; k++) 
                    {
                        switch(direction) 
                        {
                            case 0:
                            if (twoLong[i] == number + k)
                            {
                                exists = true;
                                break;
                            }
                            break;
                            case 1:
                            if (twoLong[i] == number + k*10)
                            {
                                exists = true;
                                break;
                            }
                            break;
                            case 2:
                            if (twoLong[i] == number - k*10)
                            {
                                exists = true;
                                break;
                            }
                            break;
                                default:
                                if (twoLong[i] == number - k)
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
                for (int i = 0; i < threeLong.Length; i++)
                {
                    for (int k = 0; k < length; k++) 
                    {
                        switch(direction) 
                        {
                            case 0:
                            if (threeLong[i] == number + k)
                            {
                                exists = true;
                                break;
                            }
                            break;
                            case 1:
                            if (threeLong[i] == number + k*10)
                            {
                                exists = true;
                                break;
                            }
                            break;
                            case 2:
                            if (threeLong[i] == number - k*10)
                            {
                                exists = true;
                                break;
                            }
                            break;
                                default:
                                if (threeLong[i] == number - k)
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
                for (int i = 0; i < fourLong.Length; i++)
                {
                    for (int k = 0; k < length; k++) 
                    {
                        switch(direction) 
                        {
                            case 0:
                            if (fourLong[i] == number + k)
                            {
                                exists = true;
                                break;
                            }
                            break;
                            case 1:
                            if (fourLong[i] == number + k*10)
                            {
                                exists = true;
                                break;
                            }
                            break;
                            case 2:
                            if (fourLong[i] == number - k*10)
                            {
                                exists = true;
                                break;
                            }
                            break;
                                default:
                                if (fourLong[i] == number - k)
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
                for (int i = 0; i < sixLong.Length; i++)
                {
                    for (int k = 0; k < length; k++) 
                    {
                        switch(direction) 
                        {
                            case 0:
                            if (sixLong[i] == number + k)
                            {
                                exists = true;
                                break;
                            }
                            break;
                            case 1:
                            if (sixLong[i] == number + k*10)
                            {
                                exists = true;
                                break;
                            }
                            break;
                            case 2:
                            if (sixLong[i] == number - k*10)
                            {
                                exists = true;
                                break;
                            }
                            break;
                                default:
                                if (sixLong[i] == number - k)
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
            }
            while (exists);
            return number;
        }
        //sist har vi fiendens Karta
        public void Map()
        {
            //Den tar positions data från exy som ändras av spelarens skott, alla positioner är 0, om man träffar blir den 2 och miss är 1.
             for(int i = 0;i < exy.Length; i++)
            {

                if (exy[i] == 0)
                {
                    boardUpdate[i] = " ";
                }
                else if(exy[i] == 1)
                {
                    boardUpdate[i] = "O";
                }
                else if(exy[i] == 2)
                {
                    boardUpdate[i] = "X";
                }
                else
                {
                    boardUpdate[i] = "error";
                }
            }
            //detta ritas sedan upp på rutnätet.
            Console.WriteLine("   Enemy Map:");
            Console.WriteLine("     0   1   2   3   4   5   6   7   8   9  ");
            Console.WriteLine("   _________________________________________");
            Console.WriteLine(" 0 | " + boardUpdate[0] + " | " + boardUpdate[1] + " | " + boardUpdate[2] + " | " + boardUpdate[3] + " | " + boardUpdate[4] + " | " + boardUpdate[5] + " | " + boardUpdate[6] + " | " + boardUpdate[7] + " | " + boardUpdate[8] + " | " + boardUpdate[9] + " |");
            for(int i = 10; i < 100; i += 10)
            {
                Console.WriteLine("   =========================================");
                Console.WriteLine(i + " | " + boardUpdate[i] + " | " + boardUpdate[i+1] + " | " + boardUpdate[i+2] + " | " + boardUpdate[i+3] + " | " + boardUpdate[i+4] + " | " + boardUpdate[i+5] + " | " + boardUpdate[i+6] + " | " + boardUpdate[i+7] + " | " + boardUpdate[i+8] + " | " + boardUpdate[i+9] + " |");
            }
            Console.WriteLine("   =========================================");
            Console.WriteLine("    90  91  92  93  94  95  96  97  98  99 ");
        }
    }
}
