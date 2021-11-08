using System;
using LinkedListLibray;

namespace EntryPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList linkedList = new LinkedList(new int[] { 3, 1, 2, 2, 7, 4, 5 });
            LinkedList linkedList1 = new LinkedList(new int[] { 5, 4, 3, 2, 1 });
            linkedList.Sort();
        }
    }
}
