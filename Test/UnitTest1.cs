using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsDataStructures;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        static readonly int ElementsCount = 7;
        static readonly int TestValue = 9;

        [TestMethod]
        public void TestRemove()
        {
            var list = Program.GenerateLinkedListElements(new LinkedList2(), ElementsCount);
            list.AddInTail(new Node(TestValue));
            list.AddInTail(new Node(TestValue));
            Program.GenerateLinkedListElements(list, ElementsCount);

            var node = list.Find(TestValue);
            Assert.IsTrue(list.Remove(TestValue));
            Assert.AreNotEqual(node, list.Find(TestValue));

            var list1 = new LinkedList2();
            Assert.IsFalse(list1.Remove(TestValue));
        }

        [TestMethod]
        public void TestRemoveAll()
        {
            var list = Program.GenerateLinkedListElements(new LinkedList2(), ElementsCount);
            list.AddInTail(new Node(TestValue));
            Program.GenerateLinkedListElements(list, ElementsCount);
            list.AddInTail(new Node(TestValue));

            Assert.IsNotNull(list.Find(TestValue));
            list.RemoveAll(TestValue);
            Assert.IsNull(list.Find(TestValue));
        }

        [TestMethod]
        public void TestClear()
        {
            var list = Program.GenerateLinkedListElements(new LinkedList2(), ElementsCount);
            list.Clear();
            Assert.IsNull(list.head);
            Assert.IsNull(list.tail);
            Assert.AreEqual(0, list.length);
        }

        [TestMethod]
        public void TestFindAll()
        {
            var testBigValue = 1000;
            var list = new LinkedList2();
            list.AddInTail(new Node(testBigValue));
            Program.GenerateLinkedListElements(list, ElementsCount);
            list.AddInTail(new Node(testBigValue));
            Program.GenerateLinkedListElements(list, ElementsCount);
            list.AddInTail(new Node(testBigValue));

            var resultList = list.FindAll(testBigValue);
            Assert.AreEqual(3, resultList.Count);
            foreach (var e in resultList)
                Assert.AreEqual(testBigValue, e.value);
        }

        [TestMethod]
        public void TestCount()
        {
            var list = Program.GenerateLinkedListElements(new LinkedList2(), ElementsCount);

            var count = 0;
            var node = list.head;
            while (node != null)
            {
                count++;
                node = node.next;
            }
            Assert.AreEqual(list.length, count);
        }

        [TestMethod]
        public void TestInsertAfter()
        {
            var list = Program.GenerateLinkedListElements(new LinkedList2(), ElementsCount);
            var node = new Node(TestValue);
            list.AddInTail(node);
            Program.GenerateLinkedListElements(list, ElementsCount);
            var insertNode = new Node(TestValue + 1);

            var startLength = list.length;
            list.InsertAfter(node, insertNode);
            Assert.AreEqual(startLength + 1, list.length);
            Assert.IsTrue(list.IsNodeInList(insertNode));
            Assert.IsTrue(node.next.Equals(insertNode));
        }
    }
}
