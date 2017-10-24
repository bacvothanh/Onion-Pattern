using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data.Interfaces;
using Microsoft.AspNet.Identity;

namespace App.Data.Models
{
    public class Account : IAuditEntity, IUser<long>, IDeleteEntity, IEntity
    {
        public Account()
        {
        }

        public long Id { get; set; }
        public string UserName { get; set; }
        [MaxLength(250)]
        public string Email { get; set; }
        [MaxLength(250)]
        public string UniqueNumber { get; set; }
        public string DisplayName { get; set; }
        public string PasswordHash { get; set; }
        public string TokenResetPassword { get; set; }
        public DateTimeOffset LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public bool TwoFactorEnabled { get; set; }
        [MaxLength(100)]
        public string ContactNumber { get; set; }
        [MaxLength(1000)]
        public string Address { get; set; }
        public DateTime? TimeLastLoginOnUtc { get; set; }
        public long? ImageId { get; set; }
        public virtual ICollection<Role> Roles { get; set; }

        public string TimeZoneId { get; set; }
        public bool IsDeleted { get; set; }
        public long? DeleteBy { get; set; }
        public DateTime? TimeDeleteOnUtc { get; set; }
        public string ResonDelete { get; set; }
        public long? MainAccountId { get; set; }
        public string PaymentCardId { get; set; }
        public string PaymentCustomerId { get; set; }
        public DateTime TimeCreateOnUtc { get; set; }
        public DateTime TimeLastModifyOnUtc { get; set; }
        public long CreateBy { get; set; }
        public long ModifyBy { get; set; }
    }
}
