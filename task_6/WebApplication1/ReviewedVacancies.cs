using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class ReviewedVacancies
    {
        public int Id { get; set; }
        public int VacancyId { get; set; }
        public int SummaryId { get; set; }
        public bool Viewed { get; set; }
        public DateTime Date { get; set; }
    }
}
