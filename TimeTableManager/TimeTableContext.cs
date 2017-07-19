using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTableManager
{
    public class TimeTableContext : DbContext 
    {   
        public TimeTableContext():base("DbConnection")
        {
        }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Shedule> Shedules { get; set; }
    }
}
