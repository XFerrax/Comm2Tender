﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Comm2Tender.Models;
using Microsoft.EntityFrameworkCore;

namespace Comm2Tender.Contexts;

public class Comm2TenderDataBaseContext : DbContext
{
    public Comm2TenderDataBaseContext(DbContextOptions<Comm2TenderDataBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdditionalСondition> AdditionalСonditions { get; set; }

    public virtual DbSet<DictClaim> DictClaims { get; set; }

    public virtual DbSet<DictContragent> DictContragents { get; set; }

    public virtual DbSet<EconomicEffect> EconomicEffects { get; set; }

    public virtual DbSet<EconomicEffectVar> EconomicEffectVars { get; set; }

    public virtual DbSet<InterestRate> InterestRates { get; set; }

    public virtual DbSet<ListClaim> ListClaims { get; set; }

    public virtual DbSet<LogTender> LogTenders { get; set; }

    public virtual DbSet<PosTender> PosTenders { get; set; }

    public virtual DbSet<VarContragentOfTender> VarContragentOfTenders { get; set; }

    public virtual DbSet<СustomsDuty> СustomsDuties { get; set; }
}