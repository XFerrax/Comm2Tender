﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Comm2Tender.Models;

public partial class DictClaim
{
    public int Id { get; set; }

    public string NameClaim { get; set; }

    public double? WeightClaim { get; set; }

    public virtual ICollection<ListClaim> ListClaims { get; set; } = new List<ListClaim>();
}