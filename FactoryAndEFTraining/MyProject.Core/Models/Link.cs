namespace MyProject.Core.Models;

public class Link : BaseEntity
{
    public string Destination { get; set; }
    public string SubDomain { get; set; }
    public LinkType LinkType { get; set; }
}

public enum LinkType
{
    Undefiend = 0,
    Email = 1,
    Mobile = 2
}