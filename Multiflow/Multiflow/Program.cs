using System;
using System.Threading;

class Program
{
    static int[] array;
    static int minValue, maxValue;

    static void Main(string[] args)
    {
        Console.WriteLine("Введiть елементи масиву через пробiл (для завершення натиснiть enter):");

        string input = Console.ReadLine();
        string[] elements = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        array = new int[elements.Length];

        for (int i = 0; i < elements.Length; i++)
        {
            array[i] = int.Parse(elements[i]);
        }

        Thread minThread = new Thread(FindMin);
        Thread maxThread = new Thread(FindMax);

        minThread.Start();
        maxThread.Start();

        minThread.Join();
        maxThread.Join();

        Console.WriteLine($"Мiнiмум: {minValue}");
        Console.WriteLine($"Максимум: {maxValue}");
    }

    static void FindMin()
    {
        minValue = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < minValue)
            {
                minValue = array[i];
            }
        }
    }

    static void FindMax()
    {
        maxValue = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > maxValue)
            {
                maxValue = array[i];
            }
        }
    }
}
