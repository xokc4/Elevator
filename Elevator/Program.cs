using Elevator.BD_Elevator;
using Elevator.Entities;
using Elevator.ElevatorMethods;

internal class Program
{
    static public List<ElevatorHaus> elevatorsBd = ElevatorFloorBD.ElevatorCreatBD();
    private static void Main(string[] args)
    {
        ChoiceOptions();

    }
    /// <summary>
    /// работа лифта
    /// </summary>
    public static void StartProgramm()
    {
        int CountElevators = 0;
        Console.WriteLine("На каком вы этаже? Чтобы вызвать диспетчера нажмите 22");
        
        int FlooterNumbers = Convert.ToInt32(Console.ReadLine());
        try
        {

            switch (FlooterNumbers)
            {

                case > -2 and < 21:
                    foreach (var i in elevatorsBd)
                    {
                        if (i.ConditionElevator == "стоит с открытыми дверьми")
                        {
                            CountElevators++;
                        }
                    }
                    if (CountElevators <= 2)
                    {
                        Console.WriteLine($"{CountElevators} свободных лифта");//доступность лифта
                    }
                    else
                    {
                        Console.WriteLine("нет свободных лифтов");
                    }

                    Console.WriteLine("Выберите лифт 1 или 2");
                    int elevetarsId = Convert.ToInt32(Console.ReadLine());//переменная для выбора лифта
                    
                    Methods.ElevatorMovementFull(-1, elevetarsId, FlooterNumbers);
                    Thread myThread1 = new Thread(StartProgramm);
                    myThread1.Start();
                    break;

                case 22:
                    Console.WriteLine("вызв диспетчера");
                    Methods.Dispatcher();
                    Console.WriteLine("Временно не работает");
                    StartProgramm();
                    break;
                case < 0:
                    Console.WriteLine("такого этажа нет");
                    StartProgramm();
                    break;

                case > 21:
                    Console.WriteLine("такого этажа нет");
                    StartProgramm();
                    break;
                default:
                    break;
            }
        }
        catch
        {
            Console.Write("\nError, try again!\n");
        }
    }
    /// <summary>
    /// Выбор функционалых программ
    /// </summary>
    public static void ChoiceOptions()
    {
        Console.WriteLine("если хотите сами посмотреть на работу лифта то нажмите 1 если имитацию то 2");
        
        try
        {
            int Choice = Convert.ToInt32(Console.ReadLine());
            switch (Choice)
            {
                case 1:
                    StartProgramm();
                    break;
                case 2:
                    Imitation(1,14);
                    break;
                default:
                    break;
            }
        }
        catch { Console.WriteLine("Вы не написали цифру"); }
    }
    /// <summary>
    /// имитация работы программы
    /// </summary>
    public static void Imitation(int FlooterNumbers,int BotFlootr)
    {
        int CountElevators = 0;
        Console.WriteLine("На каком вы этаже?");
        Console.WriteLine($"{FlooterNumbers}");
        
        try
        {

            switch (FlooterNumbers)
            {

                case > -2 and < 21:
                    foreach (var i in elevatorsBd)
                    {
                        if (i.ConditionElevator == "стоит с открытыми дверьми")
                        {
                            CountElevators++;
                        }
                    }
                    if (CountElevators <= 2)
                    {
                        Console.WriteLine($"{CountElevators} свободных лифта");//доступность лифта
                    }
                    else
                    {
                        Console.WriteLine("нет свободных лифтов");
                    }

                    Console.WriteLine("Выберите лифт 1 или 2");
                    
                    int elevetarsId = 1;//переменная для выбора лифта
                    Console.WriteLine(elevetarsId);
                 


                    Methods.ElevatorMovementFull(BotFlootr,elevetarsId, FlooterNumbers);
                    if(BotFlootr==14)
                    {
                        Imitation(15, 1);
                    }
                    else
                    {
                        ChoiceOptions();
                    }
                    
                    break;
                case < 0:
                    Console.WriteLine("такого этажа нет");
                    break;

                case > 21:
                    Console.WriteLine("такого этажа нет");
                    break;
                default:
                    break;
            }
        }
        catch
        {
            Console.Write("\nКонец имитации\n");
        }
    }
}