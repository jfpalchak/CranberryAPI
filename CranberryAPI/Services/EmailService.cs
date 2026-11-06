using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;

namespace CranberryAPI.Services;

public class EmailSettings
{
  public string Host { get; set; } = "smtp.gmail.com";
  public int Port { get; set; } = 587;
  public string Username { get; set; }   // địa chỉ Gmail gửi đi
  public string Password { get; set; }   // Gmail App Password (16 ký tự)
  public string SenderName { get; set; } = "Cranberry API";
}

public interface IEmailService
{
  Task SendAsync(string to, string subject, string body);
}

public class EmailService : IEmailService
{
  private readonly EmailSettings _settings;

  public EmailService(IOptions<EmailSettings> options)
  {
    _settings = options.Value;
  }

  public async Task SendAsync(string to, string subject, string body)
  {
    if (string.IsNullOrWhiteSpace(_settings.Username) || string.IsNullOrWhiteSpace(_settings.Password))
    {
      throw new InvalidOperationException("Email settings are missing (Email__Username / Email__Password).");
    }

    using var message = new MailMessage
    {
      From = new MailAddress(_settings.Username, _settings.SenderName),
      Subject = subject,
      Body = body,
      IsBodyHtml = false
    };
    message.To.Add(to);

    using var client = new SmtpClient(_settings.Host, _settings.Port)
    {
      EnableSsl = true, // STARTTLS trên port 587
      DeliveryMethod = SmtpDeliveryMethod.Network,
      UseDefaultCredentials = false,
      Credentials = new NetworkCredential(_settings.Username, _settings.Password),
      Timeout = 20000
    };

    await client.SendMailAsync(message);
  }
}
