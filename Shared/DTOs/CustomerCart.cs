﻿namespace Shared.DTOs;

public class CustomerCart
{
    public int CustomerId { get; set; }

    public List<int> ProductIds { get; set; }
}