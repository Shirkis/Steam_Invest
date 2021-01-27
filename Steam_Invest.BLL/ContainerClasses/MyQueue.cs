using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Steam_Invest.BLL.ContainerClasses
{
    public class MyQueueStatic<T> : IEnumerable<T>
    {
        protected const int DefaultSize = 3;

        protected T[] items;
        protected int count;

        public MyQueueStatic()
        {
            items = new T[DefaultSize];
        }


        /// <summary>
        /// Пустая ли очередь
        /// </summary>
        public bool IsEmpty { get { return count == 0; } }

        /// <summary>
        /// Количетсво элементов в очереди
        /// </summary>
        public int Count { get { return count; } }

        /// <summary>
        /// Заполненна ли очередь
        /// </summary>
        public bool IsFull { get { return count == items.Length; } }
        public MyQueueStatic(int lenght)
        {
            items = new T[lenght];
        }

        protected void ToLeftItems()
        {
            var temp = new T[items.Length];

            for (var i = 0; i < count; i++)
            {
                temp[i] = items[i + 1];
            }

            for (var i = count; i < items.Length; i++)
            {
                temp[i] = default;
            }

            items = temp;
        }

        /// <summary>
        /// Добавление нового элемента
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(T item)
        {
            if (count == items.Length)
            {
                Console.WriteLine("Очередь переполненна!");
                return;
            }

            items[count++] = item;
        }

        /// <summary>
        /// Удаление первого элемента
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (IsEmpty)
                return default;

            T item = items[0];

            items[0] = default;

            count--;

            ToLeftItems();

            return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            try
            {
                return ((IEnumerable)this).GetEnumerator();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }
    }
}
