using System.ComponentModel.DataAnnotations;
using TestApi.Models;

namespace TestApi.Dtos
{
    public class CommandPatchDto
    {
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }

        [Required]
        public string Line { get; set; }

        [Required]
        public string Platform { get; set; }

        public static Command FromDto(Command cmd, CommandPatchDto cmdUpdateDto)
        {
            cmd.Platform = cmdUpdateDto.Platform;
            cmd.Line = cmdUpdateDto.Line;
            cmd.HowTo = cmdUpdateDto.HowTo;

            return cmd;
        }
    }
}