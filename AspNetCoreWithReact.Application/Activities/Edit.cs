using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreWithReact.Domain;
using AspNetCoreWithReact.Persistence.Context;
using MediatR;

namespace AspNetCoreWithReact.Application.Activities
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Create.Command>
        {
            private ApplicationDbContext _context;

            public Handler(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Create.Command request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.Activity.Id);
                if (activity != null)
                {
                    activity.Title = request.Activity.Title ?? activity.Title;
                    await _context.SaveChangesAsync();
                }
               
                return Unit.Value;
            }
        }
    }
}
