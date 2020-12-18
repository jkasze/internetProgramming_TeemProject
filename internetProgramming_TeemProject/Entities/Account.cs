using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace internetProgramming_TeemProject.Entities
{
    public enum AccountType
    {
        teacher,admin
    }
    //定义账号数据表，使用枚举类型分别表示教师账号与管理员账号
    public class Account
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long AccountId { get; set; }
        public long Password { get; set; }
        public AccountType Type { get; set; }
    }
}
