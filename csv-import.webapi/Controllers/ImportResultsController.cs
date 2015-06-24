﻿using csv_import.datalayer.Repositories;
using csv_import.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace csv_import.webapi.Controllers
{
    public class ImportResultsController : ApiController
    {
        private readonly IGenericRepository<ImportResult> _repository;

        public ImportResultsController(IGenericRepository<ImportResult> repository)
        {
            _repository = repository;
        }
        public IEnumerable<ImportResult> Get()
        {
            return _repository.SelectAll();
        }

        // GET: api/ImportResults/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ImportResults
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ImportResults/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ImportResults/5
        public void Delete(int id)
        {
        }
    }
}