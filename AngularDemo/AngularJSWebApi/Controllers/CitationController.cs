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
    public class CitationController : ApiController
    {

        //POST api/Citation
        public IHttpActionResult Post([FromBody]Citation requestCitation)
        {
            CitationRepository.AddCitation(requestCitation);

            return Ok();
        }

        //PUT api/Citation
        public IHttpActionResult Put([FromBody]Citation requestCitation)
        {
            CitationRepository.UpdateCitation(requestCitation);

            return Ok();
        }


    }
}
