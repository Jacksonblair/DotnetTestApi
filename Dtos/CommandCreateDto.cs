using System.ComponentModel.DataAnnotations;
using TestApi.Models;

namespace TestApi.Dtos
{
    public class CommandCreateDto
    {
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }

        [Required]
        public string Line { get; set; }

        [Required]
        public string Platform { get; set; }

        public static CommandCreateDto ToDto(Command cmd)
        {
            return new CommandCreateDto
            {
                HowTo = cmd.HowTo,
                Line = cmd.Line,
                Platform = cmd.Platform
            };
        }

        public static Command FromDto(CommandCreateDto cmd)
        {
            return new Command
            {
                Id = 0,
                HowTo = cmd.HowTo,
                Line = cmd.Line,
                Platform = cmd.Platform
            };
        }
    }
}