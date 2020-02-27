using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseHandlerStandard
{
    public class Constants
    {
        public static readonly List<string> roomStatuses = new List<string>() { "Clean", "Needs Cleaning", "Needs Maintenance", "Maintenance in progress", "Cleaning in progress" };
        public static readonly List<string> roomQualities = new List<string>() { "Low", "Medium", "High", "Economy", "Suite" };
    }
}
