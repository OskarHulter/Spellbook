using ArcaneLibrary.Domain;

namespace ArcaneLibrary.Template;

public class DefaultMailContent(
    string title,
    string companyName,
    string location,
    string unsubscribeLink,
    string websiteLink)
{
    private const string Title = "Email Title";
    private const string CompanyName = "HTMLemail.io";
    private const string Location = "Company Inc, 7-11 Commercial Ct, Belfast BT1 2NB";
    private const string UnsubscribeLink = "http://htmlemail.io/blog";
    private const string WebsiteLink = "http://htmlemail.io";

    public MailContentType MailContent = new(
        title ?? Title,
        companyName ?? CompanyName,
        location ?? Location,
        unsubscribeLink ?? UnsubscribeLink,
        websiteLink ?? WebsiteLink);

    public MailContentType GetContent()
    {
        return MailContent;
    }
}