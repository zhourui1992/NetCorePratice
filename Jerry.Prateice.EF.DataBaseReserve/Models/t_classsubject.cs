using System;
using System.Collections.Generic;

namespace Jerry.Prateice.EF.DataBaseReserve.Models
{
    public partial class t_classsubject
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
    }
}
