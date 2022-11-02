using System;

namespace IntegrationAPI.Exceptions
{
    public class BloodBankNotFoundException: Exception{

        public BloodBankNotFoundException(){}


        public BloodBankNotFoundException(string message):base(message){}

        public BloodBankNotFoundException(string message, Exception inner):base(message, inner){}
//konstruktor sa 
        public BloodBankNotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context): base(info, context) {}


    }
}