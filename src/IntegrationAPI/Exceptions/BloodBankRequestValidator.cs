using System.Text.RegularExpressions;
using IntegrationAPI.DTO;
using IntegrationLibrary.BloodBank;

namespace IntegrationAPI.Exceptions
{
    public static class BloodBankRequestValidator{

       public static void Validate(BloodBank bloodbankrequest){
            if(bloodbankrequest==null)

            {
                throw new BloodBankArgumentException($"{nameof(bloodbankrequest)} is null");

            }
            else if (string.IsNullOrWhiteSpace(bloodbankrequest.Username))
            {
                throw new BloodBankArgumentException($"{nameof(bloodbankrequest.Username)} is null/empty/whitespace");
                
            }
            else if(bloodbankrequest.Email.Length > 0)
            {
                Regex emailRegex = new Regex (@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                              @"\.[0-9]{1,3}\.[0,9]{1,3}\.)|(([a-zA-Z0-9\-]+\"+
                                              @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
                if (emailRegex.IsMatch(bloodbankrequest.Email))

                {
                    throw new BloodBankArgumentException($"{nameof(bloodbankrequest.Email)} is invalid");

                }

            }

        }

    }
}