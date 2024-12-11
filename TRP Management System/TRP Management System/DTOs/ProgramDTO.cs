using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TRP_Management_System.DTOs
{
    public class ProgramDTO
    {
        [Required] 
        public int ProgramId { get; set; }
        [Required]
        public string ProgramName { get; set; }
        [Required]
        public decimal TRPScore { get; set; }
        [Required]
        public int ChannelId { get; set; }
        [Required]
        public System.DateTime AirTime { get; set; }
    }
}