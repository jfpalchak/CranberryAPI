using System.Net.Mail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CranberryAPI.Models;
using CranberryAPI.Services;

namespace CranberryAPI.Controllers;

[Route("api")]
[ApiController]
public class MailController : ControllerBase
{
  private readonly IEmailService _emailService;
  private readonly ILogger<MailController> _logger;

  public MailController(IEmailService emailService, ILogger<MailController> logger)
  {
    _emailService = emailService;
    _logger = logger;
  }

  // POST: api/sendmail
  [HttpPost("sendmail")]
  [Authorize]
  public async Task<IActionResult> SendMail([FromBody] SendMailDto mail)
  {
    try
    {
      await _emailService.SendAsync(mail.Receiver, mail.Header, mail.Body);
      return Ok(new { status = "Success", message = $"Email sent to {mail.Receiver}." });
    }
    catch (InvalidOperationException ex)
    {
      _logger.LogError(ex, "Email is not configured");
      return StatusCode(500, new { status = "Error", message = ex.Message });
    }
    catch (SmtpException ex)
    {
      _logger.LogError(ex, "Failed to send email to {Receiver}", mail.Receiver);
      return StatusCode(502, new { status = "Error", message = $"SMTP error: {ex.StatusCode} - {ex.Message}" });
    }
  }
}
