using ES.Entities;
using System.Collections.Generic;

namespace ES.BusinessLayer.Interfaces
{
    public interface IEducationRepository
    {
        IEnumerable<Education> FindByUserID(int UserID);
    }
}
