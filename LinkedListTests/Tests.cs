using LinkedListLibray;
using NUnit.Framework;

namespace LinkedListTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        [TestCase(new int[] { }, new int[] { 1 }, 1)]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 6, 1, 2, 3, 4 }, 6)]
        public void AddFirstTests(int[] array, int[] expectedArray, int value)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(array);
            actual.AddFirst(value);
            LinkedList.Equals(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 5, 6, 1, 2, 3, 4 }, new int[] { 5, 6 })]
        [TestCase(new int[] { }, new int[] { 5, 6 }, new int[] { 5, 6 })]
        public void AddFirsrLinkedListTests(int[] array, int[] expectedArray, int[] addArray)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(array);
            LinkedList add = new LinkedList(addArray);
            actual.AddFirst(add);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 6, 3, 4 }, 2, 6)]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 6, 1, 2, 3, 4 }, 0, 6)]
        public void AddAtTests(int[] array, int[] expectedArray, int index, int value)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(array);
            actual.AddAt(index, value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 7, 8, 6, 3, 4 }, 2, new int[] { 7, 8, 6 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 6, 7, 8, 1, 2, 3, 4 }, 0, new int[] { 6, 7, 8 })]
        public void AddAtLinkedListTest(int[] array, int[] expectedArray, int index, int[] addArray)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(array);
            LinkedList add = new LinkedList(addArray);
            actual.AddAt(index, add);
            LinkedList.Equals(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 6 }, 6)]
        [TestCase(new int[] { }, new int[] { 1 }, 1)]
        public void AddLastTests(int[] array, int[] expectedArray, int value)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(array);
            actual.AddLast(value);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 5, 6 })]
        [TestCase(new int[] { }, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        public void AddLastLinkedListTests(int[] array, int[] expectedArray, int[] addArray)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(array);
            LinkedList add = new LinkedList(addArray);
            actual.AddLast(add);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 }, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 4, 5 }, 3)]
        public void RemoveFirstTests(int[] array, int[] expectedArray, int quantity)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(array);
            actual.RemoveFirst(quantity);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 4, 5, 6 }, new int[] { 1, 2, 4, 6 }, 3)]
        [TestCase(new int[] { 1, 2, 4, 5, 6 }, new int[] { 2, 4, 5, 6 }, 0)]
        [TestCase(new int[] { 1, 2, 4, 5, 6 }, new int[] { 1, 2, 4, 5 }, 4)]
        public void RemoveAtTests(int[] array, int[] expectedArray, int index)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(array);
            actual.RemoveAt(index);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 4, 5, 6 }, new int[] { 1, 2, 4 }, 3, 2)]
        [TestCase(new int[] { 1, 2, 4, 5, 6 }, new int[] { 5, 6 }, 0, 3)]
        public void RemoveAtMultiplyTests(int[] array, int[] expectedArray, int index, int n)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(array);
            actual.RemoveAtMultiple(index, n);
            LinkedList.Equals(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 4, 5, 6 }, new int[] { 1, 2 }, 3)]
        [TestCase(new int[] { 1, 2, 4, 5, 6 }, new int[] { 1, 2, 4, 5, 6 }, 0)]
        [TestCase(new int[] { 1, 2, 4, 5, 6 }, new int[] { }, 5)]
        public void RemoveLastTests(int[] array, int[] expectedArray)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(array);
            actual.RemoveLast();
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 34, 3, 12, 435, 123, 32 }, 435)]
        [TestCase(new int[] { 34, 435, 12, 435, 123, 32 }, 435)]
        public void MaxTests(int[] array, int expected)
        {
            LinkedList Array = new LinkedList(array);
            int actual = Array.Max();
            Assert.AreEqual(actual, expected);
        }
        [TestCase(new int[] { 34, 3, 12, 435, 123, 32 }, 3)]
        [TestCase(new int[] { 34, 3, -12, 435, 123, 32 }, -12)]
        [TestCase(new int[] { 34, 3, 12, 435, 123, 0 }, 0)]
        public void MinTests(int[] array, int expected)
        {
            LinkedList Array = new LinkedList(array);
            int actual = Array.Min();
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[] { 34, 3, 12, 435, 123, 32 }, 3)]
        [TestCase(new int[] { 34, 3, -12, 5, 123, 32 }, 4)]
        [TestCase(new int[] { 34, 3, 12, 0 }, 0)]
        public void IndexMaxTests(int[] array, int expected)
        {
            LinkedList Array = new LinkedList(array);
            int actual = Array.IndexMax();
            Assert.AreEqual(actual, expected);
        }
        [TestCase(new int[] { 34, 3, 12, 435, 123, 32 }, 1)]
        [TestCase(new int[] { 34, 3, -12, 5, 123, 32 }, 2)]
        [TestCase(new int[] { 34, 3, 12, 0 }, 3)]
        public void IndexMinTests(int[] array, int expected)
        {
            LinkedList Array = new LinkedList(array);
            int actual = Array.IndexMin();
            Assert.AreEqual(actual, expected);
        }
        [TestCase(new int[] { 34, 3, 12, 12, 123, 32 }, 12, 2)]
        [TestCase(new int[] { 34, 3, -12, 5, 123, 32 }, 123, 4)]
        [TestCase(new int[] { 34, 3, 12, 0 }, 0, 3)]
        public void IndexOfTests(int[] array, int val, int expected)
        {
            LinkedList Array = new LinkedList(array);
            int actual = Array.IndexOf(val);
            Assert.AreEqual(actual, expected);
        }
        [TestCase(new int[] { 34, 3, 12, 435, 123, 32 }, 1, 3)]
        [TestCase(new int[] { 34, 3, -12, 435, 123, 32 }, 2, -12)]
        [TestCase(new int[] { 34, 3, 12, 435, 123, 0 }, 5, 0)]
        public void GetTests(int[] array, int idx, int expected)
        {
            LinkedList Array = new LinkedList(array);
            int actual = Array.Get(idx);
            Assert.AreEqual(actual, expected);
        }
        [TestCase(new int[] { 34, 3, 12, 435, 123, 32 }, 32)]
        [TestCase(new int[] { 34, 3, 12, 435, 123, 0 }, 0)]
        public void GetLastTests(int[] array, int expected)
        {
            LinkedList Array = new LinkedList(array);
            int actual = Array.GetLast();
            Assert.AreEqual(actual, expected);
        }
        [TestCase(new int[] { 34, 3, 12, 435, 123, 32 }, 34)]
        [TestCase(new int[] { 9, 3, 12, 435, 123, 0 }, 9)]
        public void GetFirstTests(int[] array, int expected)
        {
            LinkedList Array = new LinkedList(array);
            int actual = Array.GetFirst();
            Assert.AreEqual(actual, expected);
        }
        [TestCase(new int[] { 34, 3, 12, 12, 123, 32 }, 12, true)]
        [TestCase(new int[] { 34, 3, -12, 5, 123, 32 }, 13, false)]
        public void ContainsTests(int[] array, int val, bool expected)
        {
            LinkedList Array = new LinkedList(array);
            bool actual = Array.Contains(val);
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[] { 1, 10, 4, 5, 6 }, new int[] { 10, 6, 5, 4, 1 })]
        public void SortDescTest(int[] array, int[] expectedArray)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(array);
            actual.SortDesc();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 8, 5, 6 }, new int[] { 1, 2, 5, 6, 8 })]
        public void SortTest(int[] array, int[] expectedArray)
        {
            LinkedList expected = new LinkedList(expectedArray);
            LinkedList actual = new LinkedList(array);
            actual.Sort();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 1, 5, 3, 4, 5 }, new int[] { 5, 4, 3, 5, 1 })]
        [TestCase(new int[] { 1, 5 }, new int[] { 5, 1 })]
        public void ReverseTests(int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);
            actual.Reverse();
            LinkedList.Equals(actual, expected);
        
        }
    }
}