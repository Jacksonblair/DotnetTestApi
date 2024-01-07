using TestApi.Models;

namespace TestApi.Dtos
{
    public class CommandReadDto
    {
        public int Id { get; set; }

        public string HowTo { get; set; }

        public string Line { get; set; }

        public static CommandReadDto ToDto(Command cmd)
        {
            return new CommandReadDto
            {
                Id = cmd.Id,
                HowTo = cmd.HowTo,
                Line = cmd.Line
            };
        }
    }
}