using SendEmailProject.Models;
using System.Threading.Tasks;

namespace SendEmailProject.Services
{
    public interface ISendEmailService
    {
        Task sendEmail(MailOptionsModel mailOptionsModel);
    }
}