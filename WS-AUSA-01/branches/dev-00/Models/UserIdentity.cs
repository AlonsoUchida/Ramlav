using System.Security.Principal;

public class UserIdentity : IIdentity
{
    private System.Web.Security.FormsAuthenticationTicket ticket;

    public UserIdentity(System.Web.Security.FormsAuthenticationTicket _ticket)
    {
        ticket = _ticket;
    }

    public string AuthenticationType
    {
        get { return "User"; }
    }

    public bool IsAuthenticated
    {
        get { return true; }
    }

    public string Name
    {
        get { return ticket.Name; }
    }

    public string UserId
    {
        get { return ticket.UserData; }
    }
}