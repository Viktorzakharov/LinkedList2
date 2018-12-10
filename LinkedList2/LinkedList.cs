using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Node
    {
        public int value;
        public Node next, prev;

        public Node(int _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class LinkedList2
    {
        public Node head;
        public Node tail;
        public int length;

        public LinkedList2()
        {
            head = null;
            tail = null;
            length = 0;
        }

        public void AddInTail(Node _item)
        {
            if (head == null)
            {
                head = _item;
                _item.next = null;
                _item.prev = null;
            }
            else
            {
                tail.next = _item;
                _item.prev = tail;
                _item.next = null;
            }
            tail = _item;
            length++;
        }

        public Node Find(int _value)
        {
            var node = head;
            while (node != null)
            {
                if (node.value == _value) return node;
                node = node.next;
            }
            return null;
        }

        public List<Node> FindAll(int _value)
        {
            List<Node> nodes = new List<Node>();
            var node = head;
            while (node != null)
            {
                if (node.value == _value) nodes.Add(node);
                node = node.next;
            }
            return nodes;
        }

        public bool Remove(int _value)
        {
            var node = Find(_value);
            if (node == null) return false;
            RemoveOperations(node);
            return true;
        }

        public void RemoveAll(int _value)
        {
            var nodes = FindAll(_value);
            for (int i = 0; i < nodes.Count; i++)
                RemoveOperations(nodes[i]);
        }

        void RemoveOperations(Node node)
        {
            if (node.Equals(head))
            {
                if (head.Equals(tail)) Clear();
                else
                {
                    head = head.next;
                    head.prev = null;
                    length--;
                }
            }
            else if (node.Equals(tail))
            {
                node.prev.next = null;
                tail = node.prev;
                length--;
            }
            else
            {
                node.prev.next = node.next;
                node.next.prev = node.prev;
                length--;
            }
        }

        public void Clear()
        {
            head = null;
            tail = null;
            length = 0;
        }

        public int Count()
        {
            return length;
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            if (_nodeAfter == null) AddInTail(_nodeToInsert);
            else if (IsNodeInList(_nodeAfter))
            {
                _nodeToInsert.next = _nodeAfter.next;
                _nodeToInsert.prev = _nodeAfter;
                if (_nodeAfter.Equals(tail)) tail = _nodeToInsert;
                else _nodeAfter.next.prev = _nodeToInsert;
                _nodeAfter.next = _nodeToInsert;
                length++;
            }
        }

        public void AddNodeInHead(Node node)
        {
            if (head != null)
            {
                node.prev = null;
                node.next = head;
                head.prev = node;
                head = node;
                length++;
            }
            else AddInTail(node);
        }

        public bool IsNodeInList(Node checkNode)
        {
            var node = head;
            while (node != null)
            {
                if (checkNode.Equals(node)) return true;
                node = node.next;
            }
            return false;
        }
    }
}
