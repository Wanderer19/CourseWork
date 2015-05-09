using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructure.Solutions.LinkedListTasks.LinkedListUtils
{
    public class LinkedList<T> : IEnumerable<T>
    {
        //надо хранить начало и конец списка
        private LinkedListItem<T> head;
        private LinkedListItem<T> tail;

        //автоматическое свойство, для которого не надо заводить переменную, так как здесь только get-ер
        public LinkedListItem<T> First { get { return head; } }
        public T GetFirstItem()
        {
            if (!IsEmpty())
            {
                return head.Value;
            }

            throw new InvalidOperationException();

        }

        public T GetLastItem()
        {
            if (!IsEmpty())
            {
                return tail.Value;
            }
            throw new InvalidOperationException();

        }

        public void Remove(LinkedListItem<T> item)
        {
            if (item == head)
            {
                head = item.Next;
                return;
            }
            else
            {

                //для того, чтобы удалить элемент из списка, надо найти предыдущий
                // el1 -> el2 -> el3 -> el4
                //если мы хотим удалить el3
                //то новый список будет выглядить так
                //el1 -> el2 -> el4
                var tmp = head;
                var prev = head;
                while (tmp != item)
                {
                    prev = tmp;
                    tmp = tmp.Next;
                }

                prev.Next = tmp.Next;
            }
        }
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
                //один из способов проинициализировать значения создаваемого объекта, если они публичные
                //эквивалентно head.Value = value; head.Next = null;
                head = new LinkedListItem<T>() { Value = value, Next = null };
                tail = head;
            }
            else
            {
                var tmp = new LinkedListItem<T>() { Value = value, Next = null };
                tail.Next = tmp;
                tail = tmp;
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
                var el = new LinkedListItem<T>() { Value = value, Next = head };
                head = el;
            }
        }

        public void Clear()
        {
            head = tail = null;
        }


        //метод GetEnumerator позволяет нам пробегаться по нашему списку foreach - ем
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
