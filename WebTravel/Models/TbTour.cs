using System;
using System.Collections.Generic;

namespace WebTravel.Models;

public partial class TbTour
{
    public int TourId { get; set; }

    public string? Title { get; set; }

    public string? Alias { get; set; }

    public int? CategoryTourId { get; set; }

    public string? Description { get; set; }

    public string? Detail { get; set; }

    public string? Image { get; set; }

    public int? Price { get; set; }

    public int? PriceSale { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public bool IsActive { get; set; }

    public int? Star { get; set; }

    public string? Location { get; set; }

    public int? TimeTravel { get; set; }

    public virtual TbTourCategory? CategoryTour { get; set; }

    public virtual ICollection<TbOrderDetail> TbOrderDetails { get; set; } = new List<TbOrderDetail>();

    public virtual ICollection<TbTourReview> TbTourReviews { get; set; } = new List<TbTourReview>();
}
