using System;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using SecretSantaApp.BusinessLogic.Services.Interfaces;
using SecretSantaApp.EfCore.Enitities;
using SecretSantaApp.EfCore.Interfaces;

namespace SecretSantaApp.BusinessLogic.Services
{
    public class InviteService : IInviteService
    {
        private readonly IInviteRepository _inviteRepository;

        public InviteService(IInviteRepository inviteRepository)
        {
            _inviteRepository = inviteRepository;
        }

        public void Create(Invite invite)
        {
            var stringToHash = $"{invite.GroupId}.{invite.EmailAddress}.{DateTime.Now}";
            var hash = CalculateMd5Hash(stringToHash);
            invite.Hash = hash;
            _inviteRepository.Create(invite);
            _inviteRepository.SaveChanges();
            Send(invite.Id);
        }

        public void Send(long id)
        {
            var invite = _inviteRepository.First(x => x.Id == id);
            var message = new MailMessage();
            message.From = new MailAddress("secretsantacpt200@gmail.com");
            message.To.Add(invite.EmailAddress);
            message.Body =
                $"You have been invited to a Secret Santa group! http://localhost:4200/invite?email={invite.EmailAddress}&hash={invite.Hash}";
            message.IsBodyHtml = true;
            message.Subject = "Secret Santa Group Invitation";
            using (var client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("secretsantacpt200@gmail.com", "");
                client.EnableSsl = true;
                client.Send(message);
            }
        }

        public Invite GetByEmailAndHash(string emailAddress, string hash)
        {
            return _inviteRepository.First(x => x.EmailAddress == emailAddress && x.Hash == hash);
        }

        public void Delete(long id)
        {
            var entity = _inviteRepository.First(x => x.Id == id);
            _inviteRepository.Delete(entity);
            _inviteRepository.SaveChanges();
        }

        private string CalculateMd5Hash(string input)
        {
            var md5 = MD5.Create();
            var inputBytes = Encoding.ASCII.GetBytes(input);
            var hash = md5.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}