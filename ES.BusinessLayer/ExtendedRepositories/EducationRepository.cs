using ES.BusinessLayer.Interfaces;
using ES.Entities;
using System.Collections.Generic;

namespace ES.BusinessLayer
{
    public partial class EducationRepository : IEducationRepository
    {
        public IEnumerable<Education> FindByUserID(int UserID)
        {
            return FindByQuery(" UserID = " + UserID);
        }
    }
}
