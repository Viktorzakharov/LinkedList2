using System;

namespace AlgorithmsDataStructures
{
    public class Program
    {
        static void Main()
        {
            var list = GenerateLinkedListElements(new LinkedList2(), 7);
            Write(list);
        }

        public static LinkedList2 GenerateLinkedListElements(LinkedList2 list, int count)
        {
            var n = new Random();
            while (count > 0)
            {
                list.AddInTail(new Node(n.Next(255)));
                count--;
            }
            return list;
        }

        public static void Write(LinkedList2 list)
        {
            var node = list.head;
            while (node != null)
            {
                Console.Write("{0} ", node.value);
                node = node.next;
            }
            Console.WriteLine();
        }
    }
}
