using DigitasChallenge.BLL.Helpers;
using DigitasChallenge.BLL.Models;
using DigitasChallenge.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DigitasChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _tasksService;

        public TasksController(ITasksService tasksService)
        {
           _tasksService = tasksService;
        }

        /// <summary>
        /// Method that add all records in the database (MOCK)
        /// </summary>        
        /// <returns></returns>
        [HttpPost]
        [Route("AddAll")]
        public IActionResult AddAll()
        {
            try
            {
                _tasksService.AddAll();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ErrorsHelper.ErrorsMessage(ex));
            }
        }

        /// <summary>
        /// Method that remove all records in the database (MOCK)
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("RemoveAll")]
        public IActionResult RemoveAll()
        {
            try
            {
                _tasksService.RemoveAll();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ErrorsHelper.ErrorsMessage(ex));
            }
        }

        /// <summary>
        /// Method that returns all tasks
        /// </summary>
        /// <returns>A list of all tasks stored</returns>
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var tasks = _tasksService.GetAll();

                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return BadRequest(ErrorsHelper.ErrorsMessage(ex));
            }
        }

        /// <summary>
        /// Method that returns a specific task based on the id
        /// </summary>
        /// <param name="id">Parameter that represent the id must be recovered</param>
        /// <returns>A specific task</returns>
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById([FromQuery, Required, NotNull] int id)
        {
            try
            {
                var task = _tasksService.GetById(id);

                return Ok(task);
            }
            catch (Exception ex)
            {
                return BadRequest(ErrorsHelper.ErrorsMessage(ex));
            }
        }

        /// <summary>
        /// Method that add a task
        /// </summary>
        /// <param name="task">Parameter that represents a task must be inserted</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Add")]
        public IActionResult Add([FromBody] SimpleTasksModel task)
        {
            try
            {
                _tasksService.Add(task);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ErrorsHelper.ErrorsMessage(ex));
            }
        }

        /// <summary>
        /// Method that update a task
        /// </summary>
        /// <param name="task">Parameter that represents a task must be updated</param>
        /// <returns></returns>
        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] CompleteTasksModel task)
        {
            try
            {
                _tasksService.Update(task);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ErrorsHelper.ErrorsMessage(ex));
            }
        }

        /// <summary>
        /// Method that remove a task
        /// </summary>
        /// <param name="id">Parameter that represent the id must be removed</param>
        /// <returns></returns>
        [HttpPut]
        [Route("Remove")]
        public IActionResult Remove([FromQuery, Required, NotNull] int id)
        {
            try
            {
                _tasksService.Remove(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ErrorsHelper.ErrorsMessage(ex));
            }
        }       
    }
}