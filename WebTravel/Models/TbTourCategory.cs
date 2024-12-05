using System;
using System.Collections.Generic;

namespace WebTravel.Models;

public partial class TbTourCategory
{
    public int CategoryTourId { get; set; }

    public string? Title { get; set; }

    public string? Alias { get; set; }

    public string? Description { get; set; }

    

    public int? Position { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public bool IsActive { get; set; }

    

    public virtual ICollection<TbTour> TbTours { get; set; } = new List<TbTour>();
}
