using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserAPIServices.Models
{
    public class BookingPersonsModel
    {
        public Guid? Id { get; set; }
        
        public Guid? FlightBookingId { get; set; }//uniqueidentifier    
        
        public int? SeatNo { get; set; }
        
        public string Name { get; set; }
        public int Age { get; set; }
        
        public string Gender { get; set; }
       
    }
}
