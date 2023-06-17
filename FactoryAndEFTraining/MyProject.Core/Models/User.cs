using System.Security.AccessControl;

namespace MyProject.Core.Models;

public class User : BaseEntity
{
    public string UserName { get; set; }
    public string Passsword { get; set; }
    public UserType UserType { get; set; }
    public Guid PersonId { get; set; }
    public Person Person { get; set; }
}



[Flags]
public enum UserType
{
    Undefiend = 0,
    User = 1,
    SupportUser = 2,
    Administrator = 4
}