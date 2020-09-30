using System;
using System.Collections;
using System.Collections.Generic;

namespace codewar
{
    public class queueYield
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
                    var current = head;
                    while (current != null)
                    {
                        yield return current.Value;
                        current = current.Next;
                    }
                }

                IEnumerator IEnumerable.GetEnumerator()
                {
                    return GetEnumerator();
                }

                
            }
            
        }
        class Program
                {
                    public static void Main22()
                    {
                        var queue = new Queue<string>();
                        queue.Enqueue("1");
                        queue.Enqueue("12");
                        queue.Enqueue("123");

                        foreach (var e in queue)
                            System.Console.WriteLine(e);
                    }
                }
    }
}