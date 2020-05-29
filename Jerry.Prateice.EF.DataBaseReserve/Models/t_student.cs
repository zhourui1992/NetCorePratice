using System;
using System.Collections.Generic;

namespace Jerry.Prateice.EF.DataBaseReserve.Models
{
    public partial class t_student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Sex { get; set; }
        public int ClassId { get; set; }
        public string Address { get; set; }
    }
}
