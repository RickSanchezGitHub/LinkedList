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
            int lastValue = Get(GetLength() - 1);


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
            int idx = IndexOf(Min());
            return idx;
        }
        public int IndexMax()
        {
            int idx = IndexOf(Max());
            return idx;
        }
        public void AddFirst(int value)
        {
            Node tmp = _head;
            _head = new Node { Value = value };
            _head.Next = tmp;
        }
        public void AddFirst(LinkedList linkedList)
        {
            if (GetLength() == 0)
                throw new Exception();
            Node tmp = _head;
            _head = linkedList._head;
            Node t = GetNode(GetLength() - 1);
            t.Next = tmp;
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
            Node current = GetNode(GetLength() - 1);
            Node headUser = linkedList._head;            
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
            if (idx == 0)
                AddFirst(linkedList);
            else if (idx == GetLength() - 1)
                AddLast(linkedList);
            else
            {
                Node tmpIdx = GetNode(idx);
                Node tmpNext = GetNode(idx + 1);
                int length = linkedList.GetLength();
                Node headUser = linkedList._head;
                for (int i = idx; i < length - 1 ; i++)
                {
                    tmpIdx.Next = headUser;
                    headUser = headUser.Next;
                }
                headUser.Next = tmpNext;
            }
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
            int length = GetLength() - 1;
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
            else if(idx == GetLength() - 1)
                RemoveLast();
            else
            {
                Node crnt = GetNode(idx - 1);
                crnt.Next = GetNode(idx + 1);
            }
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
            for (int i = 0; i < length / 2 ; i++)
            {
                for (int k = length - 1; k > length / 2; k--)
                {
                    Node tmp = GetNode(i);
                    AddAt(i, Get(k));
                    AddAt(k, Get(i));
                    RemoveAt(i + 1);
                    RemoveAt(k + 1);
                }
            }
        }
        public void Sort()
        {
            int length = GetLength();
            int idx = 0;
            Node current = _head;
            while (length != 0)
            {
                int nax = current.Value;
                for (int k = length - 1; k >= 0; k--)
                {
                    Node tmpVal = GetNode(k);
                    if (nax <= tmpVal.Value)
                    {
                        nax = tmpVal.Value;
                        idx = k;
                    }
                }
                Node tmp = GetNode(length - 1);
                Set(idx, tmp.Value);
                Set(length - 1, nax);
                length--;
            }
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
        public Node GetNode(int index)
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

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
