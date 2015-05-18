using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarsCompare.Database.Models.Identity
{
    public partial class AspNetUsers : StringPrimaryKey
    {
        [Required, StringLength(128)]
        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public DateTime? LockoutEndDateUtc { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        [Required, StringLength(128)]
        public string UserName { get; set; }

        [JsonIgnore]
        public virtual ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }

        [JsonIgnore]
        public virtual ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }

        [JsonIgnore]
        public virtual ICollection<AspNetRoles> AspNetRoles { get; set; }
    }
}