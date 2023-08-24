using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSeguimientoDNT.Infrastructure.Commons.Bases.Request
{
    public class BasePaginationRequest
    {
        public int NumPage { get; set; } = 1;
        public int NumRecordPage { get; set; } = 10;
        private readonly int NumMaxRecordsPerPage = 50;
        public string Order { get; set; } = "asc";
        public string? Sort { get; set; } = null;
        public int Records
        {
            get => NumRecordPage;
            set
            {
                NumRecordPage = value > NumMaxRecordsPerPage ? NumMaxRecordsPerPage : value;
            }
        }
    }
}
