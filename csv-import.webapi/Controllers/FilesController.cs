using csv_import.datalayer.Repositories;
using csv_import.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace csv_import.webapi.Controllers
{
    public class FilesController : ApiController
    {
        private readonly IGenericRepository<File> _repository;

        public FilesController(IGenericRepository<File> repository)
        {
            _repository = repository;
        }
        // GET: api/Files
        public IEnumerable<File> Get()
        {
            return _repository.SelectAll();
        }

        // GET: api/Files/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Files
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Files/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Files/5
        public void Delete(int id)
        {
        }
    }
}
