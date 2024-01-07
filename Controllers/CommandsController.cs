using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TestApi.Dtos;
using TestApi.Interfaces;

namespace TestApi.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly IRepo _repository;

        public CommandsController(IRepo repo)
        {
            _repository = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            var commandReadDtos =
                from i in commandItems
                select CommandReadDto.ToDto(i);
            return Ok(commandReadDtos);
        }

        [HttpGet("{Id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int Id)
        {
            var commandItem = _repository.GetCommandById(Id);
            if (commandItem != null)
            {
                return Ok(CommandReadDto.ToDto(commandItem));
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = CommandCreateDto.FromDto(commandCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();
            var commandReadDto = CommandReadDto.ToDto(commandModel);
            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromrepo = _repository.GetCommandById(id);
            if (commandModelFromrepo == null)
            {
                return NotFound();
            }
            commandModelFromrepo = CommandUpdateDto.FromDto(commandModelFromrepo, commandUpdateDto);
            _repository.UpdateCommand(commandModelFromrepo);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialUpdateCommand(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commandModelFromrepo = _repository.GetCommandById(id);
            if (commandModelFromrepo == null)
            {
                return NotFound();
            }
            var commandToPatch = CommandUpdateDto.ToDto(commandModelFromrepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            commandModelFromrepo = CommandUpdateDto.FromDto(commandModelFromrepo, commandToPatch);
            _repository.UpdateCommand(commandModelFromrepo);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromrepo = _repository.GetCommandById(id);
            if (commandModelFromrepo == null)
            {
                return NotFound();
            }
            _repository.DeleteCommand(commandModelFromrepo);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}