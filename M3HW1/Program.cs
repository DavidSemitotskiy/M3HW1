using M3HW1;
public class Program
{
    public static void Main(string[] args)
    {
        MyList<int> list = new MyList<int>(new int[] { 1, 2, 3, 4, 56, 12, 3, 5, 1, 0, 1 });
        Console.WriteLine("Изночальный массив:");
        foreach (int item in list)
        {
            Console.Write(item);
            Console.Write(" ");
        }

        list.Add(212);
        Console.WriteLine("Добавление элемента:");
        foreach (int item in list)
        {
            Console.Write(item);
            Console.Write(" ");
        }

        list.AddRange(new List<int>() { 22, 32, 12 });
        Console.WriteLine("Добавление коллекции или массива:");
        foreach (int item in list)
        {
            Console.Write(item);
            Console.Write(" ");
        }

        list.Remove(56);
        Console.WriteLine("Удаление элемента по значению:");
        foreach (int item in list)
        {
            Console.Write(item);
            Console.Write(" ");
        }

        list.RemoveAt(1);
        Console.WriteLine("Удаление элемента по индексу:");
        foreach (int item in list)
        {
            Console.Write(item);
            Console.Write(" ");
        }

        list.Sort(isDescending: true);
        Console.WriteLine("Сортировка массива:");
        foreach (int item in list)
        {
            Console.Write(item);
            Console.Write(" ");
        }

        Console.WriteLine($"Получение значения по индексу: {list[3]}");
    }
}