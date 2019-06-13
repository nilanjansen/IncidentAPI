using DeltaEndpoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaEndpoint.Service
{
    public interface IIncidentService
    {
        Incident GetIncident(int IncidentId);
        IEnumerable<Incident> GetAllIncident();
        void PostIncident(Incident incident);
    }
    public class IncidentService : IIncidentService
    {
        private readonly deltastoreContext _dbContext;
        public IncidentService(deltastoreContext context)
        {
            _dbContext = context;
        }

        public IEnumerable<Incident> GetAllIncident()
        {
            var incidents = _dbContext.Incident.ToList();
            return incidents;
        }

        public Incident GetIncident(int Id)
        {
            var Incident = _dbContext.Incident.Where(x => x.IncidentId == Id).First();
            return Incident;
        }

        public void PostIncident(Incident incident)
        {
            _dbContext.Incident.Add(incident);
            _dbContext.SaveChanges();
        }
    }
}
