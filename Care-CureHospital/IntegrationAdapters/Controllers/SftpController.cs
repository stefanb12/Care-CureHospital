﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Renci.SshNet;
using System.Text;
using System.Net.Mail;

namespace IntegrationAdapters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SftpController : ControllerBase
    {
        [HttpGet]
        public IActionResult SendFile()
        {
            try
            {
                using (SftpClient client = new SftpClient(new PasswordConnectionInfo("192.168.0.19", "user", "password")))
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append("Report:");
                    String medRep = builder.ToString();
                    var test = @"D:\testFiles\report.txt";
                    System.IO.File.WriteAllText(test, medRep);

                    client.Connect();
                    client.UploadFile(System.IO.File.OpenRead(test), @"\public\" + Path.GetFileName(test), x => { Console.WriteLine(x); });

                    SendNotificationEPrescription();
                    
                    client.Disconnect();
                }
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message + "Failed");
            }
        }

        public void SendNotificationEPrescription()
        {
            try
            {
                Console.WriteLine("E-mail Report se salje!");
                MailMessage email = new MailMessage();
                SmtpClient smpt = new SmtpClient("smtp.gmail.com");

                email.From = new MailAddress("hospitalssystem@gmail.com");
                email.To.Add("pharmacysistem@gmail.com");
                email.Subject = ("Nofication about send report file");
                email.Body = "We sent you new report!";

                smpt.Port = 587;
                smpt.Credentials = new System.Net.NetworkCredential("hospitalssystem@gmail.com", "bolnica123");
                smpt.EnableSsl = true;
                smpt.Send(email);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine("E-mail Report se ne salje!");
            }
        }
    }
}
