using DB;
using DB.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Site.Api.Controllers
{
    /// <summary>
    /// Class ProjectController Have EndPoints For Project Entity
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly AppDbContext _db;
        /// <summary>
        /// This Method is constructor
        /// <paramref name="db"/>
        /// </summary>
        /// <param name="db">injection of DbContext in controller</param>
        public ProjectController(AppDbContext db)
        {
            this._db = db;
        }

        /// <summary>
        /// This Method is GetProjects EndPoint
        /// </summary>
        /// <returns>List Of Projects descending order by CreationDate Property of each Project Record</returns>
        [HttpGet]
        public IActionResult GetProjects()
        {
            var list = _db.Projects.OrderByDescending(e => e.CreationDate);
            if (list is not null)
            {
                return Ok(list);
            }
            return NoContent();
        }

        /// <summary>
        /// This Method is Delete EndPoint
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Return Ok if project deleting correctly else Return BadRequest</returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var currentProject = _db.Projects.Find(id);
            if (currentProject != null)
            {
                _db.Projects.Remove(currentProject);
                _db.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        /// <summary>
        /// This Method is PostProject EndPoint that insert new project record
        /// </summary>
        /// <param name="project">instance of project entity</param>
        /// <exception cref="NullReferenceException">if non-nullable value has not value null exception raise</exception>
        /// <returns>Return Ok if project succfully insert into Db else Return BadRequest</returns>
        [HttpPost]
        public IActionResult PostProject(Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                project.CreationDate = DateTime.Now;
                _db.Projects.Add(project);
                _db.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {

                return Content(ex.Message.ToString());
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   (An Action that handles HTTP PUT requests) puts a project. </summary>
        ///
        /// <remarks>   Hp, 7/6/2023. </remarks>
        ///
        /// <param name="project">  instance of project entity. </param>
        ///
        /// <returns>   A response to return to the caller. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPut]
        public IActionResult PutProject(Project project)
        {
            var currentProject = _db.Projects.Find(project.Id);
            if (currentProject != null)
            {
                if (ModelState.IsValid)
                {

                    try
                    {

                        _db.Projects.Update(currentProject);
                        _db.SaveChanges();
                        return Ok();
                    }
                    catch (Exception ex)
                    {

                        return Content(ex.Message.ToString());
                    }
                }
                return BadRequest();
            }
            return NoContent();
        }
        /// <summary>
        /// <see cref="GetProjects"/>
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public IActionResult ExampleActionLikeGetProject()
        {
            return Ok();
        }
    }
}
