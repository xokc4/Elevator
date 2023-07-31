using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator.Entities
{
    /// <summary>
    /// класс этажа
    /// </summary>
    public class Floor
    {
        public static int CurrentFloorOne { get; set; }// Текущий этаж кабины 1
        public static bool CurrentStatusOne { get; set; }//Текущий статус кабины 1
        public static int CurrentFloorTwo { get; set; }//Текущий этаж кабины 2
        public static bool CurrentStatusTwo { get; set; }// Текущий статус кабины 2
        public static bool ElevatorStatus { get; set; }// Статус кнопки вызова лифта

        public Floor()
        { 
        }
        /// <summary>
        /// конструктор по созданию этажа 
        /// </summary>
        /// <param name="currentFloorOne"></param>
        /// <param name="currentStatusOne"></param>
        /// <param name="currentFloorTwo"></param>
        /// <param name="currentStatusTwo"></param>
        /// <param name="elevatorStatus"></param>
        public Floor(int currentFloorOne, bool currentStatusOne, int currentFloorTwo, bool currentStatusTwo, bool elevatorStatus)
        {
            CurrentFloorOne = currentFloorOne;
            CurrentStatusOne = currentStatusOne;
            CurrentFloorTwo = currentFloorTwo;
            CurrentStatusTwo = currentStatusTwo;
            ElevatorStatus = elevatorStatus;
        }
    }
}
