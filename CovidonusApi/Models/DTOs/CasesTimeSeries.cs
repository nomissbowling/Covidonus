﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CovidonusApi.Models
{
    public class CasesTimeSeries
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int DailyConfirmed { get; set; }
        public int DailyDeceased { get; set; }
        public int DailyRecovered { get; set; }
        [StringLength(20)]
        public string Date { get; set; }
        public int TotalConfirmed { get; set; }
        public int TotalDeceased { get; set; }
        public int TotalRecovered { get; set; }
        public DateTime DateFull { get; set; }
    }
}