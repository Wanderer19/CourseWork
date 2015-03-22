using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork.Algorithms
{
    public class BinaryTreeItem<T> where T : IComparable
    {
        public T Value;
        public BinaryTreeItem<T> LeftChild, RightChild;
    }

    public class BinaryTree<T> where T : IComparable
    {
        private BinaryTreeItem<T> root;

        public BinaryTree()
        {
            root = null;
        }

        public void AddToTree(T value)
        {
            AddToTree(ref root, value);
        }

        public bool Find(T key)
        {
            return Find(root, key);
        }

        public IEnumerable<T> InfixTraverse()
        {
            return InfixTraverse(root);
        }

        private IEnumerable<T> InfixTraverse(BinaryTreeItem<T> node)
        {
            if (node == null)
            {
                yield break;
            }
            else
            {
                foreach (var el in InfixTraverse(node.LeftChild))
                {
                    yield return el;
                }
                yield return node.Value;
                foreach (var el in InfixTraverse(node.RightChild))
                {
                    yield return el;
                }
            }
        }

        public IEnumerable<T> PrefixTraverse()
        {
            return PrefixTraverse(root);
        }

        private IEnumerable<T> PrefixTraverse(BinaryTreeItem<T> node)
        {
            if (node == null)
            {
                yield break;
            }
            else
            {

                yield return node.Value;
                foreach (var el in InfixTraverse(node.LeftChild))
                {
                    yield return el;
                }
                foreach (var el in InfixTraverse(node.RightChild))
                {
                    yield return el;
                }
            }
        }

        public IEnumerable<T> PostfixTraverse()
        {
            return PostfixTraverse(root);
        }

        private IEnumerable<T> PostfixTraverse(BinaryTreeItem<T> node)
        {
            if (node == null)
            {
                yield break;
            }
            else
            {
                foreach (var el in InfixTraverse(node.LeftChild))
                {
                    yield return el;
                }
                foreach (var el in InfixTraverse(node.RightChild))
                {
                    yield return el;
                }
                yield return node.Value;
            }
        }

        private bool Find(BinaryTreeItem<T> node, T key)
        {
            if (node == null)
            {
                return false;
            }
            else
            {
                if (node.Value.CompareTo(key) == 0)
                {
                    return true;
                }
                else if (node.Value.CompareTo(key) == 1)
                {
                    return Find(node.LeftChild, key);
                }
                else
                {
                    return Find(node.RightChild, key);
                }
            }
        }

        private void AddToTree(ref BinaryTreeItem<T> node, T value)
        {
            if (node == null)
            {
                node = new BinaryTreeItem<T>() { Value = value };
                return;
            }
            else
            {
                if (node.Value.CompareTo(value) == 1)
                {
                    AddToTree(ref node.LeftChild, value);
                }
                else
                {
                    AddToTree(ref node.RightChild, value);
                }
            }
        }
    }
}
