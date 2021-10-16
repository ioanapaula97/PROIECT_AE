using System;
using Microsoft.AspNetCore.Http;
using ProiectMaster.Models.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProiectMaster.Models.DTOs.VM
{
    public class OrderVM
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(256)]
        public string CustomerName { get; set; }
        [Required]
        [Phone]
        public string CustomerPhoneNumber { get; set; }
        [Required]
        [MaxLength(100)]
        public string CustomerEmail { get; set; }
        [Required]
        [MaxLength(256)]
        public string CustomerAddress { get; set; }
        public DateTime OrderDate { get; set; }
        public List<string> ProductNames { get; set; }

    }
}
