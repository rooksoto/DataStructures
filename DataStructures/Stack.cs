using System;

namespace DataStructures
{
    public class Stack<T>
    {
        private T[] _backingArray;
        private int _nextAvailableIndex;
        private const int InitialBackingArraySize = 10;

        public Stack()
        {
            _backingArray = new T[InitialBackingArraySize];
            _nextAvailableIndex = 0;
        }

        public int Size()
        {
            return _nextAvailableIndex;
        }

        public void Push(T data)
        {
            ManageSize();
            _backingArray[_nextAvailableIndex] = data;
            _nextAvailableIndex++;
        }

        public T Peek()
        {
            if (_nextAvailableIndex == 0)
            {
                throw new IndexOutOfRangeException("Empty stack. Nothing to peek.");
            }
            return _backingArray[_nextAvailableIndex - 1];
        }

        public T Pop()
        {
            if (_nextAvailableIndex == 0)
            {
                throw new IndexOutOfRangeException("Empty stack. Nothing to pop.");
            }
            var result = _backingArray[_nextAvailableIndex - 1];
            _nextAvailableIndex--;
            ManageSize();
            return result;
        }

        public void Clear()
        {
            _backingArray = new T[InitialBackingArraySize];
            _nextAvailableIndex = 0;
        }

        // *************************
        //      Private Methods
        // *************************

        private void ManageSize()
        {
            if (_backingArray.Length - _nextAvailableIndex == 2)
            {
                Upsize();
                return;
            }

            if (_backingArray.Length / 2 - _nextAvailableIndex > 2)
            {
                Downsize();
            }
        }

        private void Upsize()
        {
            var newSize = _backingArray.Length * 2;
            var result = new T[newSize];
            _backingArray.CopyTo(result, 0);
            _backingArray = result;
        }

        private void Downsize()
        {
            if (_backingArray.Length == InitialBackingArraySize) return;
            var newSize = _backingArray.Length / 2;
            var result = new T[newSize];
            _backingArray.CopyTo(result, 0);
            _backingArray = result;
        }
    }
}
