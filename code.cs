using System;

public class ArrayQueue
{
    private char[] queueArray;
    private int capacity;
    private int size;
    private int front;
    private int rear;

    public ArrayQueue(int initialCapacity)
    {
        capacity = initialCapacity;
        queueArray = new char[capacity];
        size = 0;
        front = 0;
        rear = -1;
    }

    public void Add(char item)
    {
        if (size == capacity)
        {
            // Queue is full, let's resize it.
            Resize(capacity * 2);
        }

        rear = (rear + 1) % capacity;
        queueArray[rear] = item;
        size++;
    }

    public char Remove()
    {
        if (size == 0)
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        char removedItem = queueArray[front];
        front = (front + 1) % capacity;
        size--;

        return removedItem;
    }

    private void Resize(int newCapacity)
    {
        char[] newQueueArray = new char[newCapacity];
        for (int i = 0; i < size; i++)
        {
            newQueueArray[i] = queueArray[(front + i) % capacity];
        }

        queueArray = newQueueArray;
        front = 0;
        rear = size - 1;
        capacity = newCapacity;
    }

    public void PrintQueue()
    {
        Console.WriteLine("Current elements in the queue:");
        if (size == 0)
        {
            Console.WriteLine("The queue is empty.");
            return;
        }

        for (int i = 0; i < size; i++)
        {
            Console.Write(queueArray[(front + i) % capacity] + " ");
        }
        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the initial capacity of the queue:");
        int initialCapacity = int.Parse(Console.ReadLine());
        ArrayQueue queue = new ArrayQueue(initialCapacity);

        Console.WriteLine("Enter elements to add to the queue. Enter -1 to stop.");

        int input;
        while ((input = int.Parse(Console.ReadLine())) != -1)
        {
            char elementToAdd = (char)input;
            queue.Add(elementToAdd);
        }

        queue.PrintQueue();

        Console.WriteLine("Enter the new capacity: ");
        int newCapacity = int.Parse(Console.ReadLine());
        queue.Resize(newCapacity);
        queue.PrintQueue();

        Console.WriteLine("Enter elements to add to the queue. Enter -1 to stop.");

        while ((input = int.Parse(Console.ReadLine())) != -1)
        {
            char elementToAdd = (char)input;
            queue.Add(elementToAdd);
        }

        queue.PrintQueue();
    }
}
