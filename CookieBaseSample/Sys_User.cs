using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CookieBaseSample
{
    public class Sys_User
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string RealName { get; set; }
        public string HeadIcon { get; set; }
        public int Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string WeChat { get; set; }
        public string DepartmentId { get; set; }
        public string RoleId { get; set; }
        public string DutyId { get; set; }

        public bool IsEnabled { get; set; }
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public string CreateUserId { get; set; }
        public DateTime? LastModifyTime { get; set; }
        public string LastModifyUserId { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
        public string DeleteUserId { get; set; }
    }
}