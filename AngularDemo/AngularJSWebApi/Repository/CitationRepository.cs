using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AngularJSWebApi.Models;

namespace AngularJSWebApi.Repository
{
    public class CitationRepository
    {
        private static List<Citation> citations;

        private static List<Citation> Citations
        {
            get
            {
                if(citations == null)
                {
                    citations = new List<Citation>()
                    {
                        new Citation() {ID = 1, CitationNumber = "ABCD1234", Driver = new Person() {LastName = "Smith", FirstName = "Joe" }, ViolationDateTime = DateTime.Now, Fine=124.54m },
                        new Citation() {ID = 2, CitationNumber = "REDSF1234", Driver = new Person() {LastName = "Jones", FirstName = "Kim" }, ViolationDateTime = DateTime.Now, Fine=124.54m },
                        new Citation() {ID = 3, CitationNumber = "FTRR1234", Driver = new Person() {LastName = "Smith", FirstName = "Paul" }, ViolationDateTime = DateTime.Now, Fine=124.54m },
                        new Citation() {ID = 4, CitationNumber = "OIUJR1234", Driver = new Person() {LastName = "Smith", FirstName = "Bob" }, ViolationDateTime = DateTime.Now, Fine=124.54m },
                        new Citation() {ID = 5, CitationNumber = "QADD1234", Driver = new Person() {LastName = "Tucker", FirstName = "Jeff" }, ViolationDateTime = DateTime.Now, Fine=124.54m },
                        new Citation() {ID = 6, CitationNumber = "ACDFL1234", Driver = new Person() {LastName = "Barr", FirstName = "Brandt" }, ViolationDateTime = DateTime.Now, Fine=124.54m }
                    };
                }
                return citations;
            }
        }

        public static List<Citation> GetCitations()
        {
            return Citations;
        }

        public static void AddCitation(Citation citation)
        {
            int maxCitationID = citations.Max(a => a.ID);
            citation.ID = maxCitationID + 1;
            citation.ViolationDateTime = DateTime.Now;
            citations.Add(citation);
        }

        public static void UpdateCitation(Citation requestCitation)
        {
            var citation = CitationRepository.GetCitations().FirstOrDefault(a => a.ID == requestCitation.ID);

            if (citation != null)
            {
                citation.CitationNumber = requestCitation.CitationNumber;
                citation.Driver.LastName = requestCitation.Driver.LastName;
                citation.Driver.FirstName = requestCitation.Driver.FirstName;
                citation.Driver.MiddleName = requestCitation.Driver.MiddleName;
                citation.Fine = requestCitation.Fine;                
            }

        }

    }
}