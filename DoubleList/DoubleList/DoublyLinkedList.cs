
namespace DoubleList;

public class DoublyLinkedList<T>
{
    private DoubleNode<T>? _head;
    private DoubleNode<T>? _tail;
    private bool _isDescending = false;


    public DoublyLinkedList()
    {
        _tail = null; // end
        _head = null; // start
        _isDescending = false;
    }

    public void InsertAtBeginning(T data)
    {
        var newNode = new DoubleNode<T>(data);
        if (_head == null)
        {
            _head = _tail = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }
    }

    public void InsertAtEnd(T data)
    {
        var newNode = new DoubleNode<T>(data);
        if (_tail == null)
        {
            _head = _tail = newNode;
        }
        else
        {
            newNode.Prev = _tail;
            _tail.Next = newNode;
            _tail = newNode;
        }
    }

    //01
    public void InsertOrdered(T data)
    {
        var newNode = new DoubleNode<T>(data);
        if (_head == null)
        {
            _head = _tail = newNode;
            return;
        }

        var cmp = Comparer<T>.Default;
        var current = _head;

        if (_isDescending)
        {
            if (cmp.Compare(data, _head.Data) > 0)
            {
                newNode.Next = _head;
                _head.Prev = newNode;
                _head = newNode;
                return;
            }

            while (current.Next != null && cmp.Compare(data, current.Next.Data) <= 0)
                current = current.Next;
        }
        else
        {
            if (cmp.Compare(data, _head.Data) < 0)
            {
                newNode.Next = _head;
                _head.Prev = newNode;
                _head = newNode;
                return;
            }

            while (current.Next != null && cmp.Compare(data, current.Next.Data) >= 0)
                current = current.Next;
        }

        newNode.Next = current.Next;
        newNode.Prev = current;
        if (current.Next != null)
            current.Next.Prev = newNode;
        else
            _tail = newNode;
        current.Next = newNode;
    }


    //02 Print the list forward 
    public string GetForward()
    {
        var Output = string.Empty;
        var current = _head;
        while (current != null)
        {
            Output += $"{current.Data} <=> ";
            current = current.Next;
        }
        return Output.Substring(0, Output.Length - 4);
    }

    // 03 Show reverse
    public string GettBackward()
    {
        var Output = string.Empty;
        var current = _tail;
        while (current != null)
        {
            Output += $"{current.Data} <=> ";
            current = current.Prev;
        }
        return Output.Substring(0, Output.Length - 4);
    }

    // 4.
    public void Reverse()
    {
        var current = _head;
        DoubleNode<T> temp = null;

        while (current != null)
        {
            temp = current.Prev;
            current.Prev = current.Next;
            current.Next = temp;
            current = current.Prev;
        }
        if (temp != null) //  _head => _tail - _tail => _head
        {
            _head = temp.Prev;
        }
    }

    // 5. 
    public List<T> ShowMode()
    {
        var count = new Dictionary<T, int>(); // dictionary => counter
        int max = 0; 
        for (var n = _head; n != null; n = n.Next)
        {
            if (n.Data == null) continue;
            {
                count[n.Data] = count.ContainsKey(n.Data) ? count[n.Data] + 1 : 1;
            }
            if (count[n.Data] > max) max = count[n.Data];
        }
        var modes = new List<T>(); // save the modes

        foreach (var kv in count)
        {
            if (kv.Value == max)
                modes.Add(kv.Key);
        }
        return modes;
    }

    // 6.
    public bool Exists(T data)
    {
        var current = _head;

        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                return true; //If found, returns true
            }
            current = current.Next; 
        }
        return false; 
    }

    // 7. 
    public void ShowGraph()
    {
        if (_head == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }
        var count = new Dictionary<T, int>(); // dictionary => counter

        var current = _head;
        while (current != null)
        {
            var key = current.Data!;
            if (count.ContainsKey(key))
                count[key]++;
            else
                count[key] = 1;

            current = current.Next;
        }
        Console.WriteLine("Gráfico de ocurrencias:"); // viw graph
        foreach (var kv in count)
        {
            Console.WriteLine($"{kv.Key} {new string('*', kv.Value)}");
        }
    }



    // 8.
    public bool Remove(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                if (current.Prev != null)
                {
                    current.Prev.Next = current.Next;
                }
                else
                {
                    _head = current.Next;
                } 
                if (current.Next != null)
                {
                    current.Next.Prev = current.Prev;
                }
                else
                {
                    _tail = current.Prev;
                }
                return true;
            }
            current = current.Next;
        }
        return false;
    }



    // 9. 
    public void RemoveAll(T data)
    {
        var current = _head;

        while (current != null)
        {
            var next = current.Next;

            if (current.Data!.Equals(data))
            {
                if (current.Prev != null)
                {
                    current.Prev.Next = current.Next;
                }
                else
                {
                    _head = current.Next;
                }

                if (current.Next != null)
                {
                    current.Next.Prev = current.Prev;
                }
                else
                {
                    _tail = current.Prev;
                }
            }

            current = next;
        }
        return;
    }
}


    

           