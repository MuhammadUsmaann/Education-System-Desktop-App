using ES.Entities;
using System.Collections.Generic;

namespace ES.BusinessLayer.Interfaces
{
    public interface IExperienceRepository
    {
        IEnumerable<Experience> FindByUserID(int UserID);
    }
}
