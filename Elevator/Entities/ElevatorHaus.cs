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
        public int Idele { get; set; }//айди лифта
        public  int FloorElevator { get; set; }// этаж где находится лифт
        public  string ConditionElevator { get; set; }// статус лифта
        public string ConditionDoor { get; set; }//статус дверей 

        public ElevatorHaus()
        {
            
        }
        //конструктор по созданию лифта
        public ElevatorHaus(int id,  int floorElevator, string conditionElevator, string conditionDoor)
        {
            Idele = id;
            FloorElevator = floorElevator;
            ConditionElevator = conditionElevator;
            ConditionDoor = conditionDoor;
            
        }
    }
   
}
