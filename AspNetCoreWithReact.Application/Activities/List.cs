using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreWithReact.Domain;
using AspNetCoreWithReact.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWithReact.Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>> { }

        public class Hanlder : IRequestHandler<Query, List<Activity>>
        {
            private ApplicationDbContext _context;
            public Hanlder(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<List<Activity>> Handle(Query query, CancellationToken cancellationToken)
            {
                return await _context.Activities.ToListAsync();
            }
        }
    }
}
