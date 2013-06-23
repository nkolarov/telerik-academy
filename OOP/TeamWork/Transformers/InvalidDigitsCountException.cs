using System;

namespace Transformers
{
    public class InvalidDigitsCountException : ApplicationException
    {        
        #region Constructors
        
        public InvalidDigitsCountException(int count) : this(null, count, null)
        {
        }
        
        public InvalidDigitsCountException(string message, int count) : this(message, count, null)
        {
        }
        
        public InvalidDigitsCountException(string message, int count, System.Exception inner) : base(message, inner)
        {
            this.Count = count;
        }
        
        // A constructor is needed for serialization when an 
        // exception propagates from a remoting server to the client.  
        protected InvalidDigitsCountException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }
        
        #endregion
        
        #region Properties
        
        public int Count { get; set; }

        #endregion
    }
}