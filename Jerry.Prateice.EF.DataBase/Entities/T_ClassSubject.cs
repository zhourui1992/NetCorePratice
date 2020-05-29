using System;
using System.Collections.Generic;
using System.Text;

namespace Jerry.Prateice.EF.DataBase.Entities
{
    public class T_ClassSubject
    {
        public int Id { get; set; }

        public int ClassId { get; set; }

        public int SubjectId { get; set; }

        public int TeacherId { get; set; }
    }
}
