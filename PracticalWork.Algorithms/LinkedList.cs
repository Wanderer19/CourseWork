using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork.Algorithms
{
    public class LinkedListItem<T>
    {
        public T Value;
        public LinkedListItem<T> Next;
    }

    public class LinkedList<T> : IEnumerable<T>
    {
        private LinkedListItem<T> head;
        private LinkedListItem<T> tail;

        public LinkedList()
        {
            head = null;
            tail = null;
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        public void EmplaceBack(T value)
        {
            if (IsEmpty())
            {
                head = new LinkedListItem<T>() {Value = value, Next = null};
                tail = head;
            }
            else
            {
                tail.Next = new LinkedListItem<T>(){Value = value, Next = null};
            }
        }

        public void EmplaceFront(T value)
        {
            if (IsEmpty())
            {
                head = new LinkedListItem<T>() { Value = value, Next = null };
                tail = head;
            }
            else
            {
                var el = new LinkedListItem<T>() {Value = value, Next = head};
                head = el;
            }
        }

        public void Clear()
        {
            head = tail = null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var tmp = head;
            while (tmp != null)
            {
                yield return tmp.Value;
                tmp = tmp.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
