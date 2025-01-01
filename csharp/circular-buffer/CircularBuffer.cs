using System;
using System.Collections.Generic;
using System.Linq;



public class CircularBuffer<T>
{
    private readonly Queue<T> _buffer;
    private readonly int _capacity;

    public CircularBuffer(int capacity)
    {
        if (capacity <= 0)
            throw new InvalidOperationException(nameof(capacity));
        _buffer = new Queue<T>(capacity);
        _capacity = capacity;
    }

    public T Read()
    {
        if (_buffer.Count <= 0)
            throw new InvalidOperationException();
        return _buffer.Dequeue();
    }

    public void Write(T value)
    {
        if (_buffer.Count >= _capacity)
            throw new InvalidOperationException();
        _buffer.Enqueue(value);
    }

    public void Overwrite(T value)
    {
        if (_buffer.Count < _capacity)
            Write(value);
        else
        {
            _buffer.Dequeue();
            _buffer.Enqueue(value);
        }
    }

    public void Clear()
    {
        _buffer.Clear();
    }
}