using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface ITeeTimeDAO
    {
        IList<TeeTime> GetAvailableTeeTimes(int courseId, DateTime arrivalDate, DateTime departureDate);
    }
}
