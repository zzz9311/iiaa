using System.Threading.Tasks;

namespace IvritSchool.BLL.SendersLogic
{
    public interface ILessonSenderBLL
    {
        Task SendAsync();
        Task SendAsync(Entities.Message message);
        void AddLessonsToSend();
        void DeleteAllSentMessages();
    }
}
