using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TRP_Management_System.DTOs
{
    public class ChannelDTO
    {

        [Required]
        public int ChannelId { get; set; }
        [Required]
        public string ChannelName { get; set; }
        [Required]
        public int EstablishedYear { get; set; }
        [Required]
        public string Country { get; set; }
    }
}