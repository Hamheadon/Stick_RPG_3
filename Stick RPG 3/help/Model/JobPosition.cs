namespace help.Model;
using System.Collections.Generic;

public class JobPosition{
    public string? Title{get; set;}

    public string? Description{get; set;}
    public int Pay{get; set;}

    public Dictionary<String, String>? Competence_requirement{get; set;}

}