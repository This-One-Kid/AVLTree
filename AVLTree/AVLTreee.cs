using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace AVLTree
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class Node<T>
    {
        public T Value;
        public Node<T> LeftChild;
        public Node<T> RightChild;
        public int Height()
        {
        //    get
        //    {
                int leftHeight = LeftChild == null ? 0 : LeftChild.Height();
                int rightHeight = RightChild == null ? 0 : RightChild.Height();

                return Math.Max(leftHeight, rightHeight) + 1;
                //if (ChildCount == 0)
                //{
                //    return 1;
                //}
                //if (LeftChild.Height > RightChild.Height)
                //{
                //    return LeftChild.Height + 1;
                //}
                //return RightChild.Height + 1;
          //  }
        }
        public int Balance
        {
            get
            {
                int leftHeight = LeftChild == null ? 0 : LeftChild.Height();
                int rightHeight = RightChild == null ? 0 : RightChild.Height();
                return rightHeight - leftHeight;
            }
        }
        public Node<T> First
        {
            get
            {
                if (LeftChild != null) return LeftChild;
                if (RightChild != null) return RightChild;
                return null;
            }
        }

        public int ChildCount
        {
            get
            {
                int count = 0;
                if (LeftChild != null)
                {
                    count++;
                }

                if (RightChild != null)
                {
                    count++;
                }

                return count;
            }
        }
        public Node(T val)
        {
            Value = val;
        }

        private string GetDebuggerDisplay()
        {
            return $"Val: {Value}, LC: {LeftChild?.Value.ToString() ?? "Null"}, RC: {RightChild?.Value.ToString() ?? "Null"}";
        }
    }
    public class AVLTreee<T> where T : IComparable<T>
    {
        Node<T> Root;
        int nodeAmount = 0;
        public int Count()
        {
            return nodeAmount;
        }
        /*public void Insert (T value)
        {

            else
            {
                Node<T> temp = Root;
                while (temp.childCount != 0)
                {
                    if (temp.value.CompareTo(value) < 0)
                    {
                        if (temp.leftChild != null)
                        {
                            temp = temp.leftChild;
                        }
                        else
                        {
                            temp.leftChild = new Node<T>(value);
                            temp.leftChild.Parent = temp;
                        }
                    }
                    else
                    {
                        if (temp.rightChild != null)
                        {
                            temp = temp.rightChild;
                        }
                        else
                        {
                            temp.rightChild = new Node<T>(value);
                            temp.rightChild.Parent = temp;
                        }
                    }
                }
                //fix height and balance, rotate if needed
            }
        }*/

        public void Add(T value)
        {
            Root = Insert(value, Root);
            nodeAmount++;
        }

        private Node<T> Insert(T value, Node<T> parent)
        {
            if (parent == null)
            {
                var newNode = new Node<T>(value);

                return newNode;
            }

            int comp = value.CompareTo(parent.Value);

            if (comp < 0)
            {
                parent.LeftChild = Insert(value, parent.LeftChild);
            }
            else
            {
                parent.RightChild = Insert(value, parent.RightChild);
            }
            UpdateHeight(parent);
            return BalanceNode(parent);
            //if (parent.LeftChild == null)
            //{
            //    parent.LeftChild = new Node<T>(value);
            //    parent.LeftChild.Parent = parent;

            //    return parent;
            //}

            //if (temp.ChildCount != 0 || nodeAmount == 1)
            //{
            //    if (temp.Value.CompareTo(value) > 0)
            //    {
            //        if (temp.LeftChild != null)
            //        {
            //            Insert(value, temp.LeftChild);
            //        }
            //        else
            //        {
            //            temp.LeftChild = new Node<T>(value);
            //            temp.LeftChild.Parent = temp;
            //            nodeAmount++;

            //            return;
            //        }
            //    }
            //    else
            //    {
            //        if (temp.RightChild != null)
            //        {
            //            Insert(value, temp.RightChild);
            //        }
            //        else
            //        {
            //            temp.RightChild = new Node<T>(value);
            //            temp.RightChild.Parent = temp;
            //            nodeAmount++;
            //            return;
            //        }
            //    }
            //    UpdateHeight(temp);
            //    BalanceTree(temp);
            //}
        }
        //public Node<T> GetParent(T value)
        //{
        //    Node<T> node = Root;
        //    if (Root.Value.CompareTo(value) == 0)
        //    {
        //        return null;
        //    }
        //    while ((node.LeftChild != null && node.LeftChild.Value.CompareTo(value) != 0) || (node.RightChild != null && node.RightChild.Value.CompareTo(value) != 0))
        //    {
        //        int comp = value.CompareTo(node.Value);
        //        if (node.LeftChild != null && comp < 0)
        //        {
        //            node = node.LeftChild;
        //        }
        //        else if (node.RightChild != null && comp > 0)
        //        {
        //            node = node.RightChild;
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    }
        //    if (node.ChildCount == 0 && node.Value.CompareTo(value) != 0)
        //    {
        //        return null;
        //    }
        //    return node;
        //}

        public Node<T> GetParent(T val)
        {
            var current = Root;

            // in case it is root
            if (current.Value.Equals(val))
            {
                return null;
            }

            return GetParentHelper(val, current);
        }

        private Node<T> GetParentHelper(T val, Node<T> node)
        {
            if (node == null)
            {
                return null;
            }
            if ((node.LeftChild != null && node.LeftChild.Value.CompareTo(val) == 0) || (node.RightChild != null && node.RightChild.Value.CompareTo(val) == 0))
            {
                return node;
            }

            if (val.CompareTo(node.Value) < 0)
            {
                node = node.LeftChild;
            }
            else
            {
                node = node.RightChild;
            }

            return GetParentHelper(val, node);
        }


        void UpdateHeight(Node<T> node)
        {
            int temp = node.Height();
        }
        Node<T> RotateLeft(Node<T> temp)
        {
            var pivot = temp.RightChild;
            temp.RightChild = pivot.LeftChild;
            pivot.LeftChild = temp;
            UpdateHeight(temp);
            return pivot;
        }
        Node<T> RotateRight(Node<T> temp)
        {
            var pivot = temp.LeftChild;
            temp.LeftChild = pivot.RightChild;
            pivot.RightChild = temp;
            UpdateHeight(temp);
            return pivot;
        }
        Node<T> BalanceNode(Node<T> node)
        {
            if (node.Balance < -1)
            {
                if (node.LeftChild.Balance > 0)
                {
                    node.LeftChild = RotateLeft(node.LeftChild);
                }
                node = RotateRight(node);
            }
            else if (node.Balance > 1)
            {
                if (node.RightChild.Balance < 0)
                {
                    node.RightChild = RotateRight(node.RightChild);
                }
                node = RotateLeft(node);
            }
            return node;
        }
        //public List<T> PreOrder (List<T> list)
        //{
        //    List<T> temp = new List<T>();
        //    Stack<Node<T>> stak = new Stack<T>();
        //    stak.Push(Root);
        //    while (stak.Count > 0)
        //    {
        //        T tempp = stak.Pop();

        //        if ()
        //    }
        //    return temp;
        //}
        public void Print()
        {
            printHelper(Root, Console.WindowWidth / 2, 0, 20);

        }

        private void printHelper(Node<T> node, int x, int y, int dx)
        {
            if (node == null)
            {
                return;
            }

            Console.SetCursorPosition(x, y);
            Console.WriteLine(node.Value);

            printHelper(node.LeftChild, x - dx, y + 1, dx - 6);
            printHelper(node.RightChild, x + dx, y + 1, dx - 6);
        }
        public bool Contains(T value)
        {
            return ContainsHelper(value, Root);
            //if (Root == null)
            //{
            //    return false;
            //}
            //bool result = ContainsHelper(value, Root);
            //return result;
        }
        private bool ContainsHelper(T value, Node<T> node)
        {
            if (node  == null)
            {
                return false;
            }

            if (node.Value.CompareTo(value) == 0)
            {
                return true;
            }
            else if (value.CompareTo(node.Value) < 0)
            {
                //ContainsHelper(value, node.LeftChild);
                node = node.LeftChild;
            }
            else
            {
                //ContainsHelper(value, node.RightChild);
                node = node.RightChild;
            }

            return ContainsHelper(value, node);
            //if (parent.ChildCount == 0)
            //{
            //    return false;
            //}
            //int comp = value.CompareTo(parent.Value);
            //if (comp < 0)
            //{
            //    ContainsHelper(value, parent.LeftChild);
            //}
            //else if (comp > 0)
            //{
            //    ContainsHelper(value, parent.RightChild);
            //}
            //return true;
        }
        public bool Remove(T value)
        {
            int oldCount = nodeAmount;
            Root = Remove(value, Root);
            return nodeAmount != oldCount;
        }
        private Node<T> Remove(T value, Node<T> parent)
        {
            if (parent == null || Contains(value) == false) return null;
            int comp = value.CompareTo(parent.Value);
            if (comp < 0)
            {
                parent.LeftChild = Remove(value, parent.LeftChild);
            }
            else if (comp > 0)
            {
                parent.RightChild = Remove(value, parent.RightChild);
            }
            else
            {
                if (parent.ChildCount == 2)
                {
                    Node<T> node = parent;
                    node = node.RightChild;
                    while (node.LeftChild != null)
                    {
                        node = node.LeftChild;
                    }
                    parent.Value = node.Value;
                    parent.RightChild = Remove(node.Value, parent.RightChild);
                }
                else
                {
                    nodeAmount--;
                    return parent.First;
                }
            }
            UpdateHeight(parent);
            return BalanceNode(parent);

        }

    }
}
