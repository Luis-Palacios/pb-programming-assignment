using csv_import.datalayer.Repositories;
using csv_import.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace csv_import.webapi.Controllers
{
    //Not safe, but it will get the job done
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
        public File Get(int id)
        {
            return _repository.Find(id);
        }

        // POST: api/Files
        public void Post(IEnumerable<File> files)
        {
            foreach (var file in files)
            {
                _repository.Insert(file);
            }
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
