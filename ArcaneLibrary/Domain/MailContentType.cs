namespace ArcaneLibrary.Domain;

public record MailContentType(
    string Title,
    string CompanyName,
    string Location,
    string UnsubscribeLink,
    string WebsiteLink);