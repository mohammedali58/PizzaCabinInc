using Pizza_Cabin_Inc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerService.Services.Interfaces
{
    public interface ISlotsManager
    {
        public void FindSlots(ScheduleResult scheduleResult, int standupQuorum);


    }
}
