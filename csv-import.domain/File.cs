using System;

namespace csv_import.domain
{
    public class File: BaseEntity
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string StateProvince { get; set; }

        public string ZipPostalCode { get; set; }

        public string Phone { get; set; }

        public DateTime BirthDate { get; set; }

        public string Gender { get; set; }

        public string Country { get; set; }

        public int ImportResultId { get; set; }

        public virtual ImportResult ImportResult { get; set; }
    }
}