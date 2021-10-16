using System;
using Microsoft.AspNetCore.Http;
using ProiectMaster.Models.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProiectMaster.Models.DTOs.VM
{
    public class OrderProductVM
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int OrderId { get; set; }
    }
}
