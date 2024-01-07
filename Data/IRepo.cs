using TestApi.Models;

namespace TestApi.Interfaces
{
    public interface IRepo
    {
        bool SaveChanges();

        IEnumerable<Command> GetAllCommands();
        Command? GetCommandById(int id);
        void CreateCommand(Command cmd);
        void UpdateCommand(Command cmd);
        void DeleteCommand(Command cmd);
    }
}