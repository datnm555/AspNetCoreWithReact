using AspNetCoreWithReact.Application.Activities;
using AspNetCoreWithReact.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWithReact.Api.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        public ActivitiesController()
        {
        }

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivityById(Guid id)
        {
            return await Mediator.Send(new Details.Query { Id = id });
        }


        [HttpPost]
        public async Task<ActionResult> CreateActivity([FromBody] Activity activity)
        {
            return Ok(await Mediator.Send(new Create.Command() { Activity = activity }));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> CreateActivity(Guid id, [FromBody] Activity activity)
        {
            activity.Id = id;
            return Ok(await Mediator.Send(new Edit.Command() { Activity = activity }));
        }

    }
}
