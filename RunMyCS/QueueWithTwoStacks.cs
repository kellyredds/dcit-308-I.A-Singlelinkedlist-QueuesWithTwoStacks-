using System;
using System.Collections.Generic;

public class QueueWithTwoStacks<T>
{
    private Stack<T> stackIn;
    private Stack<T> stackOut;

    public QueueWithTwoStacks()
    {
        stackIn = new Stack<T>();
        stackOut = new Stack<T>();
    }

    public void Enqueue(T item)
    {
        stackIn.Push(item);
        Console.WriteLine($"Enqueued: {item}");
    }

    public T Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        if (stackOut.Count == 0)
        {
            while (stackIn.Count > 0)
            {
                stackOut.Push(stackIn.Pop());
            }
        }

        T dequeuedItem = stackOut.Pop();
        Console.WriteLine($"Dequeued: {dequeuedItem}");
        return dequeuedItem;
    }

    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty.");
        }
        
        if (stackOut.Count == 0)
        {
            while (stackIn.Count > 0)
            {
                stackOut.Push(stackIn.Pop());
            }
        }

        return stackOut.Peek();
    }

    public bool IsEmpty()
    {
        return stackIn.Count == 0 && stackOut.Count == 0;
    }

    public int Count
    {
        get { return stackIn.Count + stackOut.Count; }
    }
}

// Main program to demonstrate the QueueWithTwoStacks class
public class Program
{
    public static void Main()
    {
        QueueWithTwoStacks<int> queue = new QueueWithTwoStacks<int>();
        
        // Enqueue items
        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);
        
        // Dequeue items
        queue.Dequeue();
        queue.Dequeue();
        
        // Enqueue more items
        queue.Enqueue(40);
        queue.Enqueue(50);
        
        // Peek at the front item
        Console.WriteLine($"Front item: {queue.Peek()}");
        
        // Dequeue remaining items
        while (!queue.IsEmpty())
        {
            queue.Dequeue();
        }
        
        // Try to dequeue from an empty queue (will throw an exception)
        try
        {
            queue.Dequeue();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}