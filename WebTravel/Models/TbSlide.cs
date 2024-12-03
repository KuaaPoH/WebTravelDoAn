using System;
using System.Collections.Generic;

namespace WebTravel.Models;

public partial class TbSlide
{
    public int SlideId { get; set; }

    public string? Title { get; set; }

    public string? Alias { get; set; }

    public string? Image { get; set; }

    public bool IsActive { get; set; }

}
