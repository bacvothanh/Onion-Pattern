using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Infrastructure;

namespace App.ViewModel
{
    public abstract class BaseBindingModel
    {
        public virtual ApplicationResult Validation()
        {
            return ApplicationResult.Ok();
        }
    }

    public abstract class BaseSearchModel
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }

    public abstract class BaseAuditViewModel
    {
        public DateTime TimeCreateOnUtc { get; set; }
        public DateTime TimeLastModifyOnUtc { get; set; }
        public long CreateBy { get; set; }
        public long ModifyBy { get; set; }
    }
}
