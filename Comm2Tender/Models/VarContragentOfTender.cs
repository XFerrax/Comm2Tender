﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Comm2Tender.Models;

public partial class VarContragentOfTender
{
    public int? IdContragent { get; set; }

    public int? IdTenders { get; set; }

    public bool? IsTmk { get; set; }

    public bool? IsContragent { get; set; }

    public int? IdInterestRate { get; set; }

    public int? IdСustomsDuty { get; set; }

    public int IdEconomicEffect { get; set; }

    public double? ReliabilityAssessment { get; set; }

    [JsonPropertyName("CountPos")]
    public int? CountPos { get; set; }

    [JsonPropertyName("PositionPrice")]
    public double? PositionPrice { get; set; }

    [JsonPropertyName("DeliveryCost")]
    public double? DeliveryCost { get; set; }

    [JsonPropertyName("DeliveryCount")]
    public int? CountDayDelivery { get; set; }
}