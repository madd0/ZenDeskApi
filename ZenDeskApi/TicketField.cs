using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZenDeskApi.Model;

namespace ZenDeskApi
{
    public partial class ZenDeskClient
    {
        public List<TicketField> GetTicketFields()
        {
            return GetCollection<TicketField>("ticket_fields");
        }
    }
}
