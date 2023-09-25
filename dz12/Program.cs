using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        const int listSize = 1000000;
        List<int> dataList = new List<int>(listSize);
        ArrayList nonGenericList = new ArrayList(listSize);
        Random random = new Random();

        for (int i = 0; i < listSize; i++)
        {
            int randomValue = random.Next();
            dataList.Add(randomValue);
            nonGenericList.Add(randomValue);
        }

       
        Stopwatch stopwatch = Stopwatch.StartNew();
        NonGenericSort(nonGenericList);
        stopwatch.Stop();
        double nonGenericTime = stopwatch.Elapsed.TotalSeconds;
        Console.WriteLine($"Non-Generic Method Time: {nonGenericTime} seconds");

        
        stopwatch.Restart();
        GenericSort<int>(dataList);
        stopwatch.Stop();
        double genericTime = stopwatch.Elapsed.TotalSeconds;
        Console.WriteLine($"Generic Method Time: {genericTime} seconds");

        
        if (nonGenericTime < genericTime)
        {
            Console.WriteLine($"Non-Generic method is faster by {genericTime - nonGenericTime} seconds");
        }
        else if (genericTime < nonGenericTime)
        {
            Console.WriteLine($"Generic method is faster by {nonGenericTime - genericTime} seconds");
        }
        else
        {
            Console.WriteLine("Both methods have similar execution time");
        }
    }

    static void NonGenericSort(ArrayList list)
    {
        list.Sort(); 
    }

    static void GenericSort<T>(List<T> list) where T : IComparable<T>
    {
        list.Sort(); 
    }
}
