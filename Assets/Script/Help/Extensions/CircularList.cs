using System;
using System.Collections.Generic;

namespace Help.Script.Help.Extensions
{
    public class CircularList<T> : List<T>
    {
       
        public T GetElement(int index) {


            int remained= Math.Abs(index)%base.Count;

            if (index < 0) return base[base.Count-1-remained];


            return base[remained];
        
        }
        
        
        
        
    }
}
