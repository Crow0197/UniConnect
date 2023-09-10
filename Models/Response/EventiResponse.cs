using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Response
{
    public class EventiResponse
    {
        public List<EventoResponse> EventiAssociati { get; set; }
        public List<EventoResponse> EventiCreati { get; set; }
        public List<EventoResponse> AltriEventi { get; set; }
    }


    public class EventoResponse
    {

        public string EventName { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public string Location { get; set; }
    }

}
