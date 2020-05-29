using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Jerry.Prateice.EF.DataBase.Entities
{
    public class T_Class
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(64)")]
        public string ClassName { get; set; }
    }
}
