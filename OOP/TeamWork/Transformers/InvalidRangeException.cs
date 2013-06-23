using System;

namespace Transformers
{
    public class InvalidRangeException<T> : ApplicationException
        where T : IComparable, IComparable<T>, IFormattable, IConvertible, IEquatable<T>
    {       
        #region Constructors
        
        public InvalidRangeException(T start, T end) : this(null, start, end, null)
        {
        }
        
        public InvalidRangeException(string message, T start, T end) : this(message, start, end, null)
        {
        }
        
        public InvalidRangeException(string message, T start, T end, System.Exception inner) : base(message, inner)
        {
            this.Start = start;
            this.End = end;
        }
        
        // A constructor is needed for serialization when an 
        // exception propagates from a remoting server to the client.  
        protected InvalidRangeException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }

        #endregion
        
        #region Properties
        
        public T End { get; set; }
    
        public T Start { get; set; }

        #endregion
    }
}