using System;

namespace IntegrationAPI.Exceptions
{
    public class BloodBankArgumentException: Exception {

        public BloodBankArgumentException(){}
        public BloodBankArgumentException(string message):base(message){}

        public BloodBankArgumentException(string message, Exception inner):base(message, inner){}

        public BloodBankArgumentException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context): base(info, context) {}
        

    }

    public class BloodBankNotFoundException: BloodBankArgumentException{

        public BloodBankNotFoundException(){}
        public BloodBankNotFoundException(string message):base(message){}
        public BloodBankNotFoundException(string message, Exception inner):base(message, inner){}
        public BloodBankNotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context): base(info, context) {}


    }
}