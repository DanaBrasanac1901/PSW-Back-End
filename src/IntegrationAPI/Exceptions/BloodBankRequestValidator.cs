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
            else if (string.IsNullOrWhiteSpace(bloodbankrequest.Password))
            {
                throw new BloodBankArgumentException($"{nameof(bloodbankrequest.Username)} is null/empty/whitespace");
            }

       }

    }
}