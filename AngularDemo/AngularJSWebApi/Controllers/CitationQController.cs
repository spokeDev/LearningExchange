using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AngularJSWebApi.Models;
using AngularJSWebApi.Repository;

namespace AngularJSWebApi.Controllers
{
    public class CitationQController : ApiController
    {
        // GET: api/Citation
        public IHttpActionResult Get()
        {
            var citations = CitationRepository.GetCitations();            

            return Json(citations);
        }

        // GET: api/Citation/5
        public IHttpActionResult Get(int id)
        {
            var citation = CitationRepository.GetCitations().FirstOrDefault(a => a.ID == id);

            return Json(citation);
        }


        //POST api/Citation
        public IHttpActionResult Post([FromBody]SearchCriteria requestSearchCriteria)
       {
            List<Citation> filteredValues = null;
            List<Citation> values = CitationRepository.GetCitations();

            if (requestSearchCriteria != null)
            {
                filteredValues = values.Where(a => a.Driver.LastName.ToUpper() == requestSearchCriteria.LastName.ToUpper()).ToList(); 
            }

            if(filteredValues != null)
            {
                values = filteredValues;
            }           

            return Json(values);
        }


    }
}
