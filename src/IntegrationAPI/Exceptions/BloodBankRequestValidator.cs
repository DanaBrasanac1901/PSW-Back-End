using System.Text.RegularExpressions;
using IntegrationLibrary.BloodBank;

namespace IntegrationAPI.Exceptions
{
    public static class BloodBankRequestValidator{

       public static void Validate(BloodBank bloodbankrequest){
            if(bloodbankrequest==null)
            {
                throw new BloodBankArgumentException($"{nameof(bloodbankrequest)} is null");

            }
            else if (bloodbankrequest.Username.Length < 7)
            {
                throw new BloodBankArgumentException("Username is too short");
            }

       }

    }
}