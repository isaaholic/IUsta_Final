using Application.Repositories;
using Application.Services;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class WorkRequestRepository : Repository<WorkRequest>, IWorkRequestRepository
    {
        public WorkRequestRepository(AppDbContext context,ILogger logger) : base(context, logger)
        {
        }
    }
}
