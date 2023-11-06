using System;
using System.Collections.Generic;

public class Repository<T>
{
    private List<T> elements = new List<T>();

    public delegate bool Criteria<T>(T item);

    public void Add(T item)
    {
        elements.Add(item);
    }

    public List<T> Find(Criteria<T> criteria)
    {
        List<T> result = new List<T>();
        foreach (T item in elements)
        {
            if (criteria(item))
            {
                result.Add(item);
            }
        }
        return result;
    }
}

class Program
{
    static void Main()
    {
        Repository<int> intRepository = new Repository<int>();
        intRepository.Add(1);
        intRepository.Add(2);
        intRepository.Add(3);
        intRepository.Add(4);
        intRepository.Add(5);

        Repository<string> stringRepository = new Repository<string>();
        stringRepository.Add("apple");
        stringRepository.Add("banana");
        stringRepository.Add("cherry");
        stringRepository.Add("date");
        stringRepository.Add("fig");
        
        Repository<int>.Criteria<int> isEven = (int item) => item % 2 == 0;

        List<int> evenNumbers = intRepository.Find(isEven);
        Console.WriteLine("Even numbers:");
        foreach (int num in evenNumbers)
        {
            Console.WriteLine(num);
        }
        
        Repository<string>.Criteria<string> startsWithA = (string item) => item.StartsWith("a", StringComparison.OrdinalIgnoreCase);

        List<string> startsWithAStrings = stringRepository.Find(startsWithA);
        Console.WriteLine("\nStrings starting with 'a':");
        foreach (string str in startsWithAStrings)
        {
            Console.WriteLine(str);
        }
    }
}