using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class InvoiceLogDto
    {
        public int Id { get; private set; }

        public int InvoiceId { get; private set; }

        public DateTime Date { get; private set; }

        public string? Description { get; private set; }
    }
}
