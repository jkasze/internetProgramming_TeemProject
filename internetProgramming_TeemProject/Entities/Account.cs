using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace internetProgramming_TeemProject.Entities
{
    //定义账号数据表，使用枚举类型分别表示教师账号与管理员账号
    public enum AccountType
    {
        student,teacher,admin
    }
    
    public class Account
    {
        //接收用户输入主键，不需要数据库自生成
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long AccountId { get; set; }
        public string Password { get; set; }
        public AccountType Type { get; set; }

    }
}
