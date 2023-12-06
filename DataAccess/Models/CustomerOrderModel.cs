﻿using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models;

public class CustomerOrderModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }
    public Guid ProductId { get; init; }
    public int Quantity { get; set; }
    public Guid OrderId { get; set; }
    public OrderModel Order { get; set; }

    public CustomerOrderModel(Guid productId, int quantity)
    {
        Id = Guid.NewGuid();
        ProductId = productId;
        Quantity = quantity;
    }
}