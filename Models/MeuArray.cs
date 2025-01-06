using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class MeuArray<T>
    {
        private T[] array = new T[10];

        public void AddArray(T item) {
            if(array.Length < 10) {
                array[array.Length] = item;
            }
        }

        public T this[int index] {
            get{ return array[index]; }
            set{ array[index] = value; }
        }
    }
}