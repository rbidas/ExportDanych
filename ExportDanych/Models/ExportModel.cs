using System;
using System.ComponentModel.DataAnnotations;
using ExportDanych.App_GlobalResources;

namespace ExportDanych.Models
{
    public class ExportModel
    {
        [Required(ErrorMessage = "From date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "FromDate", ResourceType = typeof(StringDefinitions))]
        public DateTime FromDate { get; set; }

        [Required(ErrorMessage = "To date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "ToDate", ResourceType = typeof(StringDefinitions))]
        public DateTime ToDate { get; set; }

        public ExportModel()
        {
            FromDate = DateTime.UtcNow;
            ToDate = DateTime.UtcNow;
        }
    }
}