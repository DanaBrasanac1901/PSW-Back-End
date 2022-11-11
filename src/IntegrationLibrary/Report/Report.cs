using System;

namespace IntegrationLibrary.Report
{
    public class Report
    {
        public Guid Id { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DateTime ConfigurationDate { get; set; } //u create staviti Today
        public int GeneratingPeriod { get; set; } //na koliko dana da se generise 
        public int BloodBankId { get; set; } 
        
        
    }
    
    
    //metoda koja enum pretvara u period ili mzd ima neka njihova biblioteka nez 
    //metoda koja sabira consumption, mzd polje da se doda? ili metoda koja na osnovu pocetnog i krajnjeg datuma
    //i na osnovu banke id dobavlja za svaki dan od te banke potrosnju i sabere 
}