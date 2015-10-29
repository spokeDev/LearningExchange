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
                        new Citation() {ID = 1, CitationNumber = "ABCD1234", Driver = new Person() {LastName = "Smith", FirstName = "Joe" }, ViolationDateTime = DateTime.Now, Fine=124.54m, PlateNumber = "BR123", ViolationCode = "801a", Make = "Ford", Model = "Ranger" },
                        new Citation() {ID = 2, CitationNumber = "REDSF1234", Driver = new Person() {LastName = "Jones", FirstName = "Kim" }, ViolationDateTime = DateTime.Now, Fine=124.54m, PlateNumber = "AP123", ViolationCode = "522b", Make = "Subaru", Model = "Outback" }
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