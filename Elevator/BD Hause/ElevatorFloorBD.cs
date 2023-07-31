using Elevator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator.BD_Elevator
{
    public class ElevatorFloorBD
    {
        /// <summary>
        /// Метод по созданию базы данных где находятся 2 лифта 
        /// </summary>
        /// <returns></returns>
        public List<ElevatorHaus>  ElevatorCreatBD()
        {
            List<ElevatorHaus> elevators = new List<ElevatorHaus>();
            elevators.Add(new ElevatorHaus(1, "стоит с открытыми дверьми)"));
            elevators.Add(new ElevatorHaus(1, "стоит с открытыми дверьми)"));

            return elevators;
        }
        /// <summary>
        /// Метод по созданию этажей
        /// </summary>
        /// <returns></returns>
        public List<Floor> floorsBD()
        {
            List<Floor> floors = new List<Floor>();
            for(int i = 0; i<=20; i++)
            {
                floors.Add(new Floor(1,false,1,false,false));
            }
            return floors;
        }
    }
}
