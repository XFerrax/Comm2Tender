﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Comm2Tender.Models;

public class VarContragentOfTender
{
    public int? IdContragent { get; set; }

    public int? IdTenders { get; set; }

    public bool? IsTmk { get; set; }

    public bool? IsContragent { get; set; }

    public int? IdInterestRate { get; set; }

    public int? IdСustomsDuty { get; set; }

    public int IdEconomicEffect { get; set; }

    public double? ReliabilityAssessment { get; set; }

    [JsonProperty(PropertyName = "CountPos")]
    public int? CountPos { get; set; }

    [JsonProperty(PropertyName = "PositionPrice")]
    public double? PositionPrice { get; set; }

    [JsonProperty(PropertyName = "DeliveryCost")]
    public double? DeliveryCost { get; set; }

    [JsonProperty(PropertyName = "DeliveryCount")]
    public int? CountDayDelivery { get; set; }

    public EconomicEffectVar EconomicEffectVar { get; set; }
}