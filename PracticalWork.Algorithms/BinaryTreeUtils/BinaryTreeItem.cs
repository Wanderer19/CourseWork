using System;

namespace PracticalWork.Algorithms.BinaryTreeUtils
{
    public class BinaryTreeItem<T> where T : IComparable
    {
        public T Value;
        public BinaryTreeItem<T> LeftChild, RightChild;
    }
}
