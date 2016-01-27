using ES.BusinessLayer.Interfaces;
using ES.Entities;
using System.Collections.Generic;

namespace ES.BusinessLayer
{
    public partial class ExperienceRepository : IExperienceRepository
    {

        public IEnumerable<Experience> FindByUserID(int UserID)
        {
            return FindByQuery(" UserID = " + UserID);
        }
    }
}
