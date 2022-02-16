using System;
using System.Collections.Generic;

namespace Core
{
    public class HeapQueue<T> where T : IComparable<T>
    {
        private List<T> items;

        public HeapQueue()
        {
            items = new List<T>();
        }

        public T Peek() => items[0];
        public int Count
        {
            get { return items.Count; }
        }

        public void Push(T item)
        {
            items.Add(item);
            ShiftDown(0, items.Count - 1);
        }

        public T Pop()
        {
            T item;
            var last = items[items.Count - 1];
            items.RemoveAt(items.Count - 1);
            if (items.Count > 0)
            {
                item = items[0];
                items[0] = last;
                ShiftUp();
            }
            else
            {
                item = last;
            }

            return item;
        }

        private int Compare(T a, T b) => a.CompareTo(b);

        private void ShiftDown(int startPos, int pos)
        {
            var item = items[pos];
            while (pos > startPos)
            {
                var parentPos = (pos - 1) >> 1;
                var parent = items[parentPos];

                if (Compare(parent, item) <= 0)
                    break;

                items[pos] = parent;
                pos = parentPos;
            }

            items[pos] = item;
        }

        private void ShiftUp()
        {
            var startPos = items.Count;
            var endPos = 0;

            var item = items[0];
            var childPos = 1;
            var pos = 0;

            while (childPos < endPos)
            {
                var rightPos = childPos + 1;
                if (rightPos < endPos && Compare(items[rightPos], items[childPos]) <= 0)
                    childPos = rightPos;

                items[pos] = items[childPos];
                pos = childPos;

                childPos = 2 * pos + 1;
            }

            items[pos] = item;
            ShiftDown(startPos, pos);
        }
    }
}