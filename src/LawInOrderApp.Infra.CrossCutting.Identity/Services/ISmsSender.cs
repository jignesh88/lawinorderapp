using System.Threading.Tasks;
namespace LawInOrderApp.Infra.CrossCutting.Identity.Services
{
    public interface ISmsSender
    {
        Task SendSmsAync(string number, string message);
    }
}
