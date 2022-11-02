using System;

namespace IntegrationAPI.Exceptions
{
    public class BloodBankArgumentException: Exception {

        public BloodBankArgumentException(){}
        public BloodBankArgumentException(string message):base(message){}

        public BloodBankArgumentException(string message, Exception inner):base(message, inner){}
//konstruktor sa 
        public BloodBankArgumentException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context): base(info, context) {}



    }

}