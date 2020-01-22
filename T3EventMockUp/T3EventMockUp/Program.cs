using System;

namespace T3EventMockUp
{
    class Program
    {
        static void Main(string[] args)
        {
            // create 3 tanks
            // 50 times
            // random 1..3 - create a layer in a 1..3 tank
            // 50 times move a layer from 1..3 to 1..3
            Random rnd = new Random();
            Tank[] tanks = new Tank[3];
            //Reporter reporter = new Reporter();
            Reporter.RegisterListeners();

            // iterations
            int newLayersNumber = 10;
            int reassignmentsnumber = 10;

            // create 3 tanks
            Console.WriteLine("\n>> Create 3 Tanks");
            for (int count = 0; count < 3; count++)
            {
                tanks[count] = Factory.ProduceTank();
            }

            // add 50 layers to random tank
            Console.WriteLine($"\n{newLayersNumber} random layers");
            for (int count = 0; count < newLayersNumber; count++)
            {
                int nextIndex = rnd.Next(0, 3);
                tanks[nextIndex].AddNewLayer();
            }

            // 50 layers moved around
            Console.WriteLine($"\n{reassignmentsnumber} ramdon layer reassignments");
            for (int count = 0; count < reassignmentsnumber; count++)
            {
                int firstTankForUpdate = rnd.Next(3);
                Layer layerToBeMoved = tanks[firstTankForUpdate].RemoveLayer();
                if (layerToBeMoved != null)
                {
                    int secondTankForUpdate = 0;
                    while (secondTankForUpdate == firstTankForUpdate)
                    {
                     secondTankForUpdate= rnd.Next(3);
                    }
                    tanks[secondTankForUpdate].AddLayer(layerToBeMoved);
                    Console.WriteLine();
                }
            }

            Console.ReadLine();

        }
    }
}
