using System;

namespace LinkedListLibray
{
    public class LinkedList
    {
        private Node _head;
        public LinkedList()
        {

        }
        public LinkedList(int value)
        {
            _head = new Node { Value = value };
        }
        public LinkedList(int[] array)
        {
            _head = new Node { Value = array[0] };
            Node tmp = _head;
            for (int i = 1; i < array.Length; i++)
            {
                tmp.Next = new Node { Value = array[i] };
                tmp = tmp.Next;
            }
        }
        public int GetLength()
        {
            Node current = _head;
            int length = 1;
            if (current == null)
            {
                return 0;
            }
            else
            {
                while (current.Next != null)
                {
                    current = current.Next;
                    length++;
                }
                return length;
            }
        }
        public int[] ToArray()
        {
            int length = GetLength();
            Node current = _head;
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = current.Value;
                current = current.Next;
            }
            return array;
        }
        public int GetFirst()
        {
            int firstValue = _head.Value;
            return firstValue;
        }
        public int GetLast()
        {
            Node current = _head;
            int lastValue = current.Value;
            while (current.Next != null)
            {
                current = current.Next;
                lastValue = current.Value;
            }

            return lastValue;
        }
        public int Get(int idx)
        {
            int length = GetLength();
            Node current = _head;
            int countIdx = 0;
            Node val;
            while (countIdx < length)
            {
                if (countIdx == idx)
                {
                    int valueIdx = current.Value;
                    val = new Node { Value = valueIdx };
                    return val.Value;
                }
                current = current.Next;
                countIdx++;
            }
            return - 1;
        }
        public bool Contains(int val)
        {
            int length = GetLength();
            int count = 0;
            Node current = _head;
            while (count < length)
            {
                if (current.Value == val)
                {
                    return true;
                }
                current = current.Next;
                count++;
            }
            return false;
        }
        public int IndexOf(int val)
        {
            Node current = _head;
            for (int i = 0; i < GetLength(); i++)
            {
                if (current.Value == val)
                    return i;
                current = current.Next;
            }
            throw new Exception();
        }
        public int Max()
        {
            int length = GetLength();
            Node current = _head;
            int max = current.Value;
            int count = 0;
            while (count < length)
            {
                if (max < current.Value)
                {
                    max = current.Value;
                }
                count++;
                current = current.Next;
            }
            return max;
        }
        public int Min()
        {
            int length = GetLength();
            Node current = _head;
            int min = current.Value;
            int count = 0;
            while (count < length)
            {
                if (min > current.Value)
                {
                    min = current.Value;
                }
                count++;
                current = current.Next;
            }
            return min;
        }
        public int IndexMin()
        {
            int length = GetLength();
            Node current = _head;
            int min = current.Value;
            int count = 0;
            int indexMin = 0;
            while (count < length)
            {
                if (min > current.Value)
                {
                    min = current.Value;
                    indexMin = count;
                }
                count++;
                current = current.Next;
            }
            return indexMin;
        }
        public int IndexMax()
        {
            int length = GetLength();
            Node current = _head;
            int max = current.Value;
            int count = 0;
            int indexMax = 0;
            while (count < length)
            {
                if (max < current.Value)
                {
                    max = current.Value;
                    indexMax = count;
                }
                count++;
                current = current.Next;
            }
            return indexMax;
        }
        public void AddFirst(int value)
        {
            Node tmp = _head;
            _head = new Node { Value = value };
            _head.Next = tmp;
        }
        public void AddFirst(LinkedList linkedList)
        {
            Node tmp = _head;
            Node headUser = linkedList._head;
            _head = headUser;
            int lengthUser = linkedList.GetLength();
            for (int i = 0; i < lengthUser -1; i++)
            {
                headUser = headUser.Next;
            }
            headUser.Next = tmp;
        }
        public void AddLast(int value)
        {
            int length = GetLength();
            if (length == 0)
            {
                _head = new Node { Value = value };
            }
                Node tmp = GetNode(length - 1);
                Node newNode = new Node { Value = value };
                tmp.Next = newNode;
        }
        public void AddLast(LinkedList linkedList)
        {
            Node current = _head;
            int length = GetLength();
            Node headUser = linkedList._head;
            for (int i = 0; i < length - 1; i++)
            {
                current = current.Next;
            }
            current.Next = headUser;
        }
        public void AddAt(int idx, int value)
        {
            if (idx == 0)
                AddFirst(value);
            else if (idx < GetLength())
            {
                Node newNode = new Node { Value = value };
                Node crnt = GetNode(idx - 1);
                newNode.Next = crnt.Next;
                crnt.Next = newNode;
            }
            else if (idx == GetLength())
                AddLast(value);
        }
        public void AddAt(int idx, LinkedList linkedList)
        {
            Node current = _head;
            Node headUser = linkedList._head;
            int count = 0;
            int length = GetLength();
            if (idx == 0)
                AddFirst(linkedList);
            while (count != idx - 1)
            {
                current = current.Next;
                count++;
            }
            Node tmp = current.Next;
            current.Next = headUser;
            int lengthUser = linkedList.GetLength();
            for (int i = 0; i < lengthUser - 1; i++)
            {
                headUser = headUser.Next;
            }
            headUser.Next = tmp;
        }
        public void RemoveFirst()
        {
            _head = GetNode(1);
        }
        public void RemoveFirstMultiple(int n)
        {
            for (int i = 0; i < n; i++)
            {
                RemoveFirst();
            }
        }
        public void RemoveLast()
        {
            int length = GetLength();
            GetNode(length - 1).Next = null;
        }
        public void RemoveLastMultiple(int n)
        {
            int length = GetLength();
            for (int i = 0; i < length - n - 1; i++)
            {
                RemoveLast();
            }
        }

        public void RemoveAt(int idx)
        {
            if (idx == 0)
                RemoveFirst();
            else if (idx < GetLength() - 1)
            {
                Node crnt = GetNode(idx - 1);
                crnt.Next = GetNode(idx + 1);
            }
            else
                RemoveLast();
        }
        public void RemoveAtMultiple(int idx, int n)
        {
            for (int i = 0; i < idx - 1; i++)
            {
                RemoveAt(idx);
            }
        }
        public int RemoveFirst(int val)
        {
            int idx = IndexOf(val);
            RemoveAt(idx);
            return idx;
        }
        public int RemoveAll(int val)
        {
            int count = 0;
            int length = GetLength();
            for (int i = 0; i < length - 1; i++)
            {
                if (Get(i) == val)
                {
                    RemoveFirst(val);
                    count++;
                    i--;
                } 
            }
            return count;

        }
        public void Set(int idx, int value)
        {
            Node current = _head;
            for (int count = 0; count < idx ; count++)
            {
                current = current.Next;
            }
            current.Value = value;
        }
        public void Reverse()
        {
            int length = GetLength();
            Node currentHead = GetNode(length - 1);
            Node current = currentHead;
            for (int k = length - 2; k >= 0; k--)
            {
                current.Next = GetNode(k);
                current = current.Next;
            }
            _head = currentHead;
        }
        public void Sort()
        {
            Node t = _head;
            int min;
            int length = GetLength();
            for (int i = 0; i < length - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < length ; j++)
                {
                    if (this[j] < this[min])
                    {
                        min = j;
                    }
                }
                Swap(i, min);
            }
            RemoveLast();
        }
        public void SortDesc()
        {
            int length = GetLength();
            int idx = 0;
            Node current = _head;
            while(length !=0)
            {
                int min = current.Value;
                for (int k = length - 1; k >= 0; k--)
                {
                    Node tmpVal = GetNode(k);
                    if (min >= tmpVal.Value)
                    {
                        min = tmpVal.Value;
                        idx = k;
                    }
                }
                Node tmp = GetNode(length - 1);
                Set(idx, tmp.Value);
                Set(length - 1, min);
                length--;
            }
        }
        public void Swap(int firstIndex, int secondIndex)
        {
            AddAt(secondIndex, this[firstIndex]);
            AddAt(firstIndex, this[secondIndex + 1]);
            RemoveAt(firstIndex + 1);
            RemoveAt(secondIndex + 1);
        }
        private Node GetNode(int index)
        {
            Node tmp = _head;
            for (int i = 0; i < index; i++)
            {
                tmp = tmp.Next;
            }
            return tmp;
        }
        public int this[int index]
        {
            
            get
            {
                int length = GetLength();
                if (index < 0 || index > length)
                {
                    throw new IndexOutOfRangeException();
                }
                Node tmp = GetNode(index);
                return tmp.Value;
            }
            set
            {
                int length = GetLength();
                if (index < 0 || index > length)
                {
                    throw new IndexOutOfRangeException();
                }
                if (index == length)
                {
                    AddLast(value);
                }
                Node tmp = GetNode(index);
                tmp.Value = value;
            }
        }
        public override bool Equals(object obj)
        {
            LinkedList linkedList = (LinkedList)obj;

            if (GetLength() != linkedList.GetLength())
                return false;
            for (int i = 0; i < GetLength(); i++)
            {
                if (this[i] != linkedList[i])
                    return false;
            }
            return true;
        }
    }
}
