using Elevator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Elevator.ElevatorMethods
{

    public static class Methods
    {

        public static List<ElevatorHaus> ElevatorHausBd = Program.elevatorsBd;
        /// <summary>
        /// двери закрылись
        /// </summary>
        /// <param name="IdElevators"></param>
        /// <returns></returns>
        public static string CloseElevator(int IdElevators)
        {
            foreach (var i in ElevatorHausBd)
            {
                if (i.Idele == IdElevators)
                {
                    i.ConditionElevator = "закрывает двери";
                    i.ConditionDoor = "двери закрыты";
                }
            }
            return "Двери закрыты";
        }
        /// <summary>
        /// двери открылись
        /// </summary>
        /// <param name="IdElevators"></param>
        /// <returns></returns>
        public static string OpeningElevator(int IdElevators)
        {
            foreach (var i in ElevatorHausBd)
            {
                if (i.Idele == IdElevators)
                {
                    i.ConditionElevator = "открывает двери";
                    i.ConditionDoor = "двери открыты";
                }
            }
            return "Двери открылись";
        }
        /// <summary>
        /// движение лифта c человеком
        /// </summary>
        /// <param name="Count"></param>
        /// <param name="CountFloor"></param>
        /// <returns></returns>
        public static string ElevatorMovementPeople(int Count, int CountFloor, int IdElevators)
        {
            if (Count < CountFloor)
            {
                CloseElevator(IdElevators);
                Console.WriteLine("Дверь закрывается");
                int level = CountFloor-1;
                Console.WriteLine("Едет вниз");
                for (int i = CountFloor; i > Count; i--)
                {
                    Thread.Sleep(2000);

                    ElevatorHausBd = ElevatorHausBd.Select(n => { if (n.Idele == IdElevators) { n.ConditionElevator = "едет вниз"; } return n; }).ToList();

                    Console.WriteLine($"этаж {level}");
                    level--;
                }
                Console.WriteLine("Двери открывается");
                OpeningElevator(IdElevators);
                ElevatorHausBd = ElevatorHausBd.Select(n => { if (n.Idele == IdElevators) { n.ConditionElevator = "стоит с открытыми дверьми"; } return n; }).ToList();
                return "вы поднялись!";
            }
            else
            {
                CloseElevator(IdElevators);
                Console.WriteLine("Дверь закрывется");
                int Level = CountFloor + 1;
                Console.WriteLine("Едет вверх");
                for (int i = CountFloor; i < Count; i++)
                {
                    Thread.Sleep(2000);

                    ElevatorHausBd = ElevatorHausBd.Select(n => { if (n.Idele == IdElevators) { n.ConditionElevator = "едет вверх"; } return n; }).ToList();

                    Console.WriteLine($"этаж {Level}");

                    Level++;
                }
                Console.WriteLine("Дверь открывается");
                OpeningElevator(IdElevators);
                ElevatorHausBd = ElevatorHausBd.Select(n => { if (n.Idele == IdElevators) { n.ConditionElevator = "стоит с открытыми дверьми"; } return n; }).ToList();
                return "вы поднялись";
            }
        }
        /// <summary>
        /// дивежние лифта без человека
        /// </summary>
        /// <returns></returns>
        public static string ElevatorMovement( int CountFloor, int IdElevators)
        {
            ElevatorHaus elevator = new ElevatorHaus();
            foreach(var i in ElevatorHausBd)
            {
                if(i.Idele == IdElevators)
                {
                    elevator = i; break;
                }
            }
          
            if (elevator.FloorElevator < CountFloor)
            {
                Console.WriteLine("Дверь закрывается");
                Console.WriteLine("Едет вверх");
                CloseElevator(IdElevators);
                int Level=elevator.FloorElevator;
                for (int i = elevator.FloorElevator; i < CountFloor; i++)
                {
                    Thread.Sleep(2000);

                    ElevatorHausBd = ElevatorHausBd.Select(n => { if (n.Idele == IdElevators) { n.ConditionElevator = "едет вверх"; } return n; }).ToList();

                    Console.WriteLine($"этаж {Level}");

                    Level++;
                }

                Thread.Sleep(2000);
                Console.WriteLine($"этаж {Level}");
                ElevatorHausBd = ElevatorHausBd.Select(n => { if (n.Idele == IdElevators) { n.FloorElevator=Level; } return n; }).ToList();
                Console.WriteLine("Дверь открывается");
                OpeningElevator(IdElevators);
                return "";
            }
            else
            {
                Console.WriteLine("Дверь закрывается");
                Console.WriteLine("Едет вниз");
                CloseElevator(IdElevators);
                int Level = elevator.FloorElevator;
                for (int i = elevator.FloorElevator; i >= CountFloor; i--)
                {
                    
                    Thread.Sleep(2000);

                    ElevatorHausBd = ElevatorHausBd.Select(n => { if (n.Idele == IdElevators) { n.ConditionElevator = "едет вниз"; } return n; }).ToList();
                    Console.WriteLine($"этаж {Level}");
                    Level--;
                }
                Console.WriteLine("Дверь открывается");
                OpeningElevator(IdElevators);
                return "";
            }
        }
        /// <summary>
        /// вызов диспетчера
        /// </summary>
        public static void Dispatcher()
        {
            Thread.Sleep(4000);
           
        }
        /// <summary>
        /// метод по объединению двух методов(движения лифта)
        /// </summary>
        /// <param name="Choice"></param>
        /// <param name="elevetarsId"></param>
        /// <param name="FlooterNumbers"></param>
        public static void ElevatorMovementFull( int Choice,int elevetarsId, int FlooterNumbers)
        {
            ElevatorHaus elevator = new ElevatorHaus();
            foreach (var i in ElevatorHausBd)
            {
                if (i.Idele == elevetarsId)
                {
                    elevator = i; break;
                }
            }

            if (FlooterNumbers < elevator.FloorElevator)
            {
                string t = Methods.CloseElevator(elevator.FloorElevator);
                string r = Methods.ElevatorMovement(FlooterNumbers, elevetarsId);

                ElevatorMovementFull(Choice,elevetarsId, FlooterNumbers);
            }
            if (FlooterNumbers > elevator.FloorElevator)
            {
                string t = Methods.CloseElevator(elevator.FloorElevator);
                string r = Methods.ElevatorMovement(FlooterNumbers, elevetarsId);


                ElevatorMovementFull( Choice, elevetarsId, FlooterNumbers);
            }
            else
            {
                
                OpeningElevator(elevator.Idele);
                Console.WriteLine("Нажмите на этаж");
                if (Choice==-1)
                {
                    int  Count = Convert.ToInt32(Console.ReadLine());
                    string r = Methods.ElevatorMovementPeople(Count, FlooterNumbers, elevetarsId);
                }
                else
                {
                    Console.WriteLine($"{Choice}");
                    
                    
                    string r = Methods.ElevatorMovementPeople(Choice, FlooterNumbers, elevetarsId);
                }
                
               
                
            }
            
        }
        
    }
}
