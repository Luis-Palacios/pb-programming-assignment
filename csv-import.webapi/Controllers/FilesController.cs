using csv_import.datalayer.Repositories;
using csv_import.domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Timers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace csv_import.webapi.Controllers
{
    //Not safe, but it will get the job done
    public class FilesController : ApiController
    {
        private readonly IGenericRepository<File> _fileRepository;
        private readonly IGenericRepository<ImportResult> _importResultRepository;

        public FilesController(IGenericRepository<File> fileRepository, IGenericRepository<ImportResult> importResultRepository)
        {
            _fileRepository = fileRepository;
            _importResultRepository = importResultRepository;
        }
        // GET: api/Files
        public IEnumerable<File> Get()
        {
            return _fileRepository.SelectAll();
        }

        // GET: api/Files/5
        public File Get(int id)
        {
            return _fileRepository.Find(id);
        }

        // POST: api/Files
        public void Post(IEnumerable<File> files)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            
            ImportResult newResult = InitResult(files);

            var existentEmails = _fileRepository.SelectAll().Select(f => f.Email);
            int duplicated = 0;
            int added = 0;
            
            AddFilesToResult(files, newResult, existentEmails, ref duplicated, ref added);
            
            UpdateResult(newResult, duplicated, added);
            SaveResult(newResult, timer);
            
        }

        private void SaveResult(ImportResult newResult, Stopwatch timer)
        {
            timer.Stop();
            newResult.ExecutionTime = timer.ElapsedMilliseconds/1000d;
            _importResultRepository.Update(newResult);
            _importResultRepository.Save();
        }

        private static void UpdateResult(ImportResult newResult, int duplicated, int added)
        {
            newResult.TotalLinesImported = added;
            newResult.TotalLinesNotImported = duplicated;
            newResult.ExecutionTime = 0;
        }

        private void AddFilesToResult(IEnumerable<File> files, ImportResult newResult, IEnumerable<string> existentEmails, ref int duplicated, ref int added)
        {
            _importResultRepository.Insert(newResult);
            _importResultRepository.Save();
            var newFiles = new List<File>();
            foreach (var file in files)
            {
                if (existentEmails.Any(e => e == file.Email))
                {
                    duplicated++;
                }
                else
                {
                    added++;
                    //this sucked ad performances when inserting the parent objects:/
                    //newResult.ImportedFiles.Add(file);
                    file.ImportResultId = newResult.Id;
                    newFiles.Add(file);
                }
            }
            _fileRepository.BulkInsert(newFiles);
            existentEmails = null;
        }

        private static ImportResult InitResult(IEnumerable<File> files)
        {
            ImportResult newResult = new ImportResult()
            {
                TotalLines = files.Count(),
            };
            return newResult;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _fileRepository.Dispose();
                _importResultRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
