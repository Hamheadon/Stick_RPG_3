namespace help.Model;
using System.Collections.Generic;

public class Job{
    public string? Title{get; set;}
    public List<JobPosition>? company_positions;

    public bool? IsMaxed{get; set;}

    public int? CurrentPositionIndex{get; set;}


}
