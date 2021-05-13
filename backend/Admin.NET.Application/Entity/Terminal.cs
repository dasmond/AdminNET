using Admin.NET.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.NET.Application
{
    public class Terminal: DEntityBase
    {
        [Comment("账号")]
        [Required, MaxLength(20)]
        public string ShowName { get; set; }
    }
}
