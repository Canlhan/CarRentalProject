using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class RentalDetailDto:IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string  ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }

        public string CompanyName { get; set; }

        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
