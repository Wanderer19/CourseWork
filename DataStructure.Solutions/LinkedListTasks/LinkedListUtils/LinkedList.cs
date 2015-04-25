﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructure.Solutions.LinkedListTasks.LinkedListUtils
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private LinkedListItem<T> head;
        private LinkedListItem<T> tail;
        private LinkedListItem<T> current;

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
                
                tail = new LinkedListItem<T>() { Value = value, Next = null };
                head = new LinkedListItem<T>() { Value = value, Next = null };
            }
            else
            {
                var tmp = head;
                while (tmp.Next != null)
                {
                    tmp = tmp.Next;
                }

                tmp.Next = new LinkedListItem<T>(){Value = value, Next = null};
                tail = tmp.Next;
            }
        }

        public void EmplaceFront(T value)
        {
            if (IsEmpty())
            {
                head = new LinkedListItem<T>() { Value = value, Next = null };
                tail = new LinkedListItem<T>() { Value = value, Next = null };
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