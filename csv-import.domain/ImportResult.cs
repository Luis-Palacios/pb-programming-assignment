using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace csv_import.domain
{
    public class ImportResult: BaseEntity
    {
        public ImportResult()
        {
            ImportedFiles = new List<File>();
        }
        public int TotalLines { get; set; }

        public int TotalLinesImported { get; set; }

        public int TotalLinesNotImported { get; set; }

        public double ExecutionTime { get; set; }

        public virtual ICollection<File> ImportedFiles { get; set; }
    }
}