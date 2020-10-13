using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models {
    
    public class AlertMeeting {
        
        public int ID { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Need a name fool, can't have a event without a name? Not possible I tried.")]
        public string Title { get; set; }
        
        [DataType(DataType.EmailAddress),
         Required(AllowEmptyStrings = false, ErrorMessage = "Give me your email so I can spam you with shit.")]
        public string Email { get; set; }
        
        [DataType(DataType.Date),
         Required(ErrorMessage = "The date and time for your event is required.")]
        public DateTime EventStartDateTime { get; set; }
        
        [DataType(DataType.Duration)]
        public float EventDuration { get; set; }
        
        
    }
    
}