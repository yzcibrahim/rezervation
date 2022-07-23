using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Rezervation
    {
        public int Id { get; set; }
        public int PlaceId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public int Status { get; set; }//0 reserved,1done,2 canceled 
    }


    public enum RezstatusEnum
    {
        RESERVED=0,
        DONE=1,
        CANCELED=2
    }
}
