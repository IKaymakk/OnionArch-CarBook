﻿namespace Domain.Entities;

public class CarPricing
{
    public int CarPricingId { get; set; }
    public Car Car { get; set; }
    public int CarId { get; set; }
    public Pricing Pricing { get; set; }
    public int PricingId { get; set; }
    public decimal Amount { get; set; }
}