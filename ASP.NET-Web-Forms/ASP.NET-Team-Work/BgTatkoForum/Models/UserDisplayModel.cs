using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BgTatkoForum.Models
{
    public class UserDisplayModel
    {
        public string Id { get; set; }
        public int Score { get; set; }
        public string FullName { get; set; }

        public int Member { get; set; }

        public string DisplayName { get; set; }
        public byte[] Avatar { get; set; }

        public virtual User User { get; set; }

        public virtual UserDetail UserDetails { get; set; }

    }
}