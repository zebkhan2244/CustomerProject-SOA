using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Shared.Common.Dtos
{
    public class AuditedDto
    {
        public int Id { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
