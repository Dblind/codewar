using System;
using System.Collections;
using System.Collections.Generic;

namespace codewar
{
    public class queue
    {
        public class QueueItem<T>
        {
            public T Value { get; set; }
            public QueueItem<T> Next { get; set; }
        }



        public class Queue<T> : IEnumerable<T>
        {
            QueueItem<T> head;
            QueueItem<T> tail;
            public bool IsEmpty { get { return head == null; } }

            public void Enqueue(T value)
            {
                if (IsEmpty)
                    tail = head = new QueueItem<T> { Value = value, Next = null };
                else
                {
                    var item = new QueueItem<T> { Value = value, Next = null };
                    tail.Next = item;
                    tail = item;
                }
            }

            public T Dequeue()
            {
                if (head == null) throw new InvalidOperationException();
                var result = head.Value;
                head = head.Next;
                if (head == null)
                    tail = null;
                return result;
            }

            public IEnumerator<T> GetEnumerator()
            {
                return new QueueEnumerator<T>(this);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            class QueueEnumerator<R> : IEnumerator<R>
            {
                Queue<R> queue;
                QueueItem<R> item;
                public QueueEnumerator(Queue<R> queue)
                {
                    this.queue = queue;
                    item = null;
                }
                public R Current
                {
                    get { return item.Value; }
                }
                object IEnumerator.Current { get { return Current; } }
                public bool MoveNext()
                {
                    if (item == null)
                        item = queue.head;
                    else
                        item = item.Next;
                    return item != null;
                }

                #region 
                public void Dispose()
                {
                    //throw new NotImplementedException();
                }
                public void Reset()
                {
                    //throw new NotImplementedException();
                }
                #endregion
            }
        }
        class Program
        {
            public static void Main22()
            {
                var queue = new Queue<int>();
                queue.Enqueue(1);
                queue.Enqueue(2);
                queue.Enqueue(3);

                foreach (var e in queue)
                    System.Console.WriteLine(e);
            }
        }
    }
}
