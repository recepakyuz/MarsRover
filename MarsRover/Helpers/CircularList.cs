using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Helpers
{
    public class CircularList<T> : List<T>
    {
        int Position = 0;
        public T Previous()
        {
            Position--;
            if (Position < 0) { Position = this.Count - 1; }

            return this[Position];
        }
        public T Next()
        {
            Position++;
            if (Position >= this.Count) { Position = 0; }

            return this[Position];
        }
        public CircularList<T> SetPosition(T obj)
        {
           Position= this.IndexOf(obj);
            return this;
        }
    }
}
