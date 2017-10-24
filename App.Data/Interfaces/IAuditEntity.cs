using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Interfaces
{
    public interface IAuditEntity
    {
        DateTime TimeCreateOnUtc { get; set; }
        DateTime TimeLastModifyOnUtc { get; set; }
        long CreateBy { get; set; }
        long ModifyBy { get; set; }
    }
}
