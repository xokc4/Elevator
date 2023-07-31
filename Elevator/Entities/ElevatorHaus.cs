using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator.Entities
{
    /// <summary>
    /// класс лифта 
    /// </summary>
    public  class ElevatorHaus
    {
        public static int FloorElevator { get; set; }// этаж где находится лифт
        public static string ConditionElevator { get; set; }// статус лифта

        public ElevatorHaus()
        {
            
        }
        //конструктор по созданию лифта
        public ElevatorHaus(int floorElevator, string conditionElevator)
        {
            FloorElevator = floorElevator;
            ConditionElevator = conditionElevator;
        }
    }
   
}
