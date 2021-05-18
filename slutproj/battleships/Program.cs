using System;
using System.Collections.Generic;

namespace battleships
{
    class Program
    {
        Random generator = new Random();
        //Metoden som spelet körs i
        static void Main(string[] args)
        {
            int attack = 0;
            int pAttack = 0;
            playerBoard pBoard = new playerBoard();
            EnemyBoard eBoard = new EnemyBoard();
            
            //Första staten av spelet då man och fienden placerar skepp
            int gameState = 1;
            pBoard.PlaceBoard();
            eBoard.EnemyPlaceBoard();
            eBoard.Map();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            pBoard.Map();
            //resten av spelet
            while (gameState == 1)
            {
                
                Console.WriteLine();
                PlayerAttack(eBoard, pBoard, pAttack);
                EnemyAttack(eBoard, pBoard, attack);
                eBoard.Map();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                pBoard.Map();
                //En ifsats som alltid körs och kollar så att någon har vunnit
                if(eBoard.points == 26)
                {
                    Console.WriteLine("The Enemy Has Won");
                    Console.ReadLine();
                    gameState = 0;
                }
                else
                {

                }
                if(pBoard.points == 26)
                {
                    Console.WriteLine("The Player Has Won");
                    Console.ReadLine();
                    gameState = 0;
                }
                else
                {

                }
                //attack och pAttack är den runda som man är på, fiende och spelare
                attack++;
                pAttack++;
            }
            Console.ReadLine();
        }
        //Metod för fiendens attack
        static void EnemyAttack(EnemyBoard eBoard, playerBoard pBoard, int attack)
        {
            Random generator = new Random();
            int safeCheck = 1;
            
            while (safeCheck == 1)
            {
                //For loopen kollar alla positioner som fienden redan attackerat i och ser till att inte skjuta på samma position två gånger
                for(int i = 0; i < eBoard.pHitReg.Length; i++)
                {
                    //enemyBoard.playerHitRegistration[attackrunda]
                    eBoard.pHitReg[attack] = generator.Next(100);
                    //om den hittar nån position som är lika så skapar den ett nytt nummer och fortsätter tills den är i else satsen
                    if(eBoard.pHitReg[attack] == eBoard.pHitReg[i])
                    {

                    }
                    else
                    {
                        //i else satsen så avslutas loopen och en position har då valts
                        safeCheck = 0;
                    }
                }
            }
            //här kollar den efter spelarens skepps platser
            for(int i = 0; i < pBoard.pShipLocation.Length; i++)
            {
                //och om playerHitRegistration är detsamma som en playerShipLocation kommer den att träffa
                if(eBoard.pHitReg[attack] == pBoard.pShipLocation[i])
                {
                    //en plats på kartan kommer uppdateras (2an)
                    pBoard.pxy[eBoard.pHitReg[attack]] = 2;
                    Console.WriteLine("Enemy Has Hit Your Ship");
                    //och då får fienden ett poäng
                    eBoard.points++;
                }
                //annars blir det en miss
                else if(eBoard.pHitReg[attack] != pBoard.pShipLocation[i] && pBoard.pxy[eBoard.pHitReg[attack]] != 2)
                {   
                    //och kartan uppdateras (3an)
                    pBoard.pxy[eBoard.pHitReg[attack]] = 3;
                }
                else{}
            }
        }
        //här är metoden för spelarens attack
        static void PlayerAttack(EnemyBoard eBoard, playerBoard pBoard, int pAttack)
        {
            //samma sak med en loop
            int safeState = 1;
            while (safeState == 1)
            {
                Console.WriteLine("0-99, Write your attack coordinates");
                //en bool som kollar om man skrivit ett nummer eller inte
                string[] pCoordinates = new string[100]; 
                pCoordinates[pAttack] = Console.ReadLine();   
                bool success = int.TryParse(pCoordinates[pAttack], out pBoard.eHitReg[pAttack]);
                //om det är ett nummer så räknas skottet även om man skjutit på samma plats som man gjort innan, vilket är ett mistag spelaren kan göra
                if(pBoard.eHitReg[pAttack] < 100)
                {
                    bool hit = false;
                    //en for loop som kollar efter fiendens skepp och spelarens skotts koordinater
                    for(int i = 0; i < eBoard.eShipLocation.Length; i++)
                    {
                        if(pBoard.eHitReg[pAttack] == eBoard.eShipLocation[i])
                        {
                            //om den träffar så kommer fiendens karta att uppdatera(2an)
                            eBoard.exy[pBoard.eHitReg[pAttack]] = 2;
                            hit = true;
                            //och man får poäng
                            pBoard.points++;
                            break;
                        }
                        else if(pBoard.eHitReg[pAttack] != eBoard.eShipLocation[i] && eBoard.exy[pBoard.eHitReg[pAttack]] != 2)
                        {   
                            //annars uppdaterar fiendens karta med 1 och eftersom att bool hit inte ändras kommer det skriva miss i konsollen
                            eBoard.exy[pBoard.eHitReg[pAttack]] = 1;
                        }
                        else{}
                    }
                    Console.WriteLine(hit ? "HIT" : "MISS");
                    //och sist avslutas whileloopen
                    safeState = 0;
                }
                else
                {
                    Console.WriteLine("Not a correct Coordinate");
                }
            }
        }
    }
}