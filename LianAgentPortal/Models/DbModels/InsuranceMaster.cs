﻿using LianAgentPortal.Commons.Constants;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace LianAgentPortal.Models.DbModels
{
    [Index("UserCreate", IsUnique = false)]
    [Index("DateCreate", IsUnique = false)]
    [Index("Type", IsUnique = false)]
    [Index("IsDeleted", IsUnique = false)]
    public class InsuranceMaster
    {
        public long Id { get; set; }
        public string UserCreate { get; set; }
        public DateTime DateCreate { get; set; }
        public string LastUserUpdate { get; set; }
        public DateTime? LastDateUpdate { get; set; }

        public string FilePath { get; set; }
        public string FileName { get; set; }

        public int TotalRows { get; set; }
        public int TotalIssuedRows { get; set; }
        public decimal TotalPremium { get; set; }
        public decimal TotalInsuranceAmount { get; set; }
        public InsuranceTypeEnum Type { get; set; }
        public bool IsDeleted { get; set; }
    }
}
