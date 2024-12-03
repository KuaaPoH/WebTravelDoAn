using System;
using System.Collections.Generic;

namespace WebTravel.Models;

public partial class TbOrderDetail
{
    public int OrderDetailId { get; set; }

    public int? OrderId { get; set; }

    public int? TourId { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public virtual TbOrder? Order { get; set; }

    public virtual TbTour? Tour { get; set; }
}
