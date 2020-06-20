﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CovidonusApi.Models
{
    public class StateWiseData : Auditor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string State { get; set; }
        [Required]
        [StringLength(5)]
        public string StateCode { get; set; }
        public int Active { get; set; }
        public int Confirmed { get; set; }
        public int Deaths { get; set; }
        public int Recovered { get; set; }

        public int DeltaActive { get; set; }
        public int DeltaConfirmed { get; set; }
        public int DeltaDeaths { get; set; }
        public int DeltaRecovered { get; set; }
        public string StateNotes { get; set; }
        public DateTime? LastUpdatedtime { get; set; }
        [StringLength(50)]
        public string StateLogo { get; set; }
        public ICollection<DistrictWiseData> DistrictData { get; set; }
    }
}