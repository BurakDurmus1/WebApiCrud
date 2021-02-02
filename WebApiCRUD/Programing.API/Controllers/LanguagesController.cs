using Programing.API.Attributes;
using Programing.API.Security;
using Programing.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Programing.API.Controllers
{
    public class LanguagesController : ApiController
    {
        LanguagesDAL languagesDAL = new LanguagesDAL();

        public IHttpActionResult GetSearchByName(string name)
        {
            return Ok("Name: " + name);
        }
        public IHttpActionResult GetSearchBySurName(string surname)
        {
            return Ok("Surname: " + surname);
        }
        [ResponseType(typeof(IEnumerable<Languages>))]
        //[NonAction]  dendiğinde metoda dışarıdan erişilemez
        public IHttpActionResult Get()
        {
            var languages = languagesDAL.GetAllLanguages();
            return Ok(languages);
        }

        [ResponseType(typeof(Languages))]
       [APIAuthorize(Roles ="Admin")]
        public IHttpActionResult Get(int id)
        {   var language = languagesDAL.GetLanguagesById(id);
            if(language==null)
            {
                return NotFound();
            }
            return Ok(language);
        }

        [ResponseType(typeof(Languages))]
        public IHttpActionResult Post(Languages language)
        {
            if(ModelState.IsValid)

            {
                var createdlanguage = languagesDAL.CreateLanguage(language);
                return CreatedAtRoute("DefaultApi",new { id = createdlanguage.ID },createdlanguage);
            }

            else
            {
                return BadRequest(ModelState);
            }
        }
        
        [ResponseType(typeof(Languages))]
        public IHttpActionResult Put(int id , Languages language)
        {
            
            //id ye ait kayıt yok ise
            if (languagesDAL.IsThereAnyLanguage(id)==false)
            {
                return NotFound();
            }
            //language modeli doğru girilmediyse
            else if (ModelState.IsValid==false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(languagesDAL.UpdateLanguage(id, language));
            }
        }
        public IHttpActionResult Delete(int id)
        {
            if(languagesDAL.IsThereAnyLanguage(id)==false)
            {
                return NotFound();
            }

            else
            {
                languagesDAL.DeleteLanguage(id);
                return Ok();
            }
            
            
        }
    }
}
