using System;
using System.Collections;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        CustomLinkedList<int> cll = new CustomLinkedList<int>();
        cll.Add(1);
        cll.Add(2);
        cll.Add(3);
        System.Console.WriteLine("Enumarating CustomLinkedList items with");
        System.Console.WriteLine("GetEnumerator:");
        foreach (var item in cll)
            System.Console.WriteLine(item);
        //
        System.Console.WriteLine("GetEnumerableDESC:");
        foreach (var item in cll.GetEnumerableDESC())
            System.Console.WriteLine(item);

    }
}
//
public class Node<T>
{
    public Node<T> previousN { get; set; }
    public Node<T> nextN { get; set; }
    public T node { get; set; }
}
//
public class CustomLinkedList<T>
{
    private Node<T>? current;
    private Node<T>? previous;
    public Node<T>? first;
    public Node<T>? last;
    //
    public CustomLinkedList()
    {
        previous = null;
    }
    //
    public void Add(T str)
    {
        last = new Node<T>();
        last.node = str;
        last.nextN = null;
        last.previousN = previous;
        //
        if (previous is null)
        first = last;
        else NextNode(last);
        previous = last;
    }
    //
    public void NextNode(Node<T> last)
    {
        current = first;
        while (current.nextN != null)
        {
            current = current.nextN;
        }
        current.nextN = last;
    }
    //
    public IEnumerator GetEnumerator()
    {
        current = first;
        while (current != null)
        {
            yield return current.node;
            current = current.nextN;
        }
    }
    //
    public IEnumerable GetEnumerableDESC()
    {
        current = last;
        while (current != null)
        {
            yield return current.node;
            current = current.previousN;
        }
    }
}