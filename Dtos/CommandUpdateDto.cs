using System.ComponentModel.DataAnnotations;
using TestApi.Models;

namespace TestApi.Dtos
{
    public class CommandUpdateDto
    {
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }

        [Required]
        public string Line { get; set; }

        [Required]
        public string Platform { get; set; }

        public static Command FromDto(Command cmd, CommandUpdateDto cmdUpdateDto)
        {
            cmd.Platform = cmdUpdateDto.Platform;
            cmd.Line = cmdUpdateDto.Line;
            cmd.HowTo = cmdUpdateDto.HowTo;

            return cmd;
        }

        public static CommandUpdateDto ToDto(Command cmd)
        {
            return new CommandUpdateDto
            {
                HowTo = cmd.HowTo,
                Line = cmd.Line,
                Platform = cmd.Platform
            };
        }
    }
}