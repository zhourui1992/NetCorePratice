using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Jerry.Prateice.EF.DataBase.Entities
{
    public class T_Student
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(64)")]
        public string Name { get; set; }

        public int Sex { get; set; }

        public string Address { get; set; }

        public int ClassId { get; set; }
        //版本号
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
