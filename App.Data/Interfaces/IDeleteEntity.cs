using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Interfaces
{
    public interface IDeleteEntity
    {
        bool IsDeleted { get; set; }
        long? DeleteBy { get; set; }
        DateTime? TimeDeleteOnUtc { get; set; }
        [MaxLength(500)]
        string ResonDelete { get; set; }
    }
}
