#### internetProgramming

with javascript and dotnet core 3.1



# Restful接口目录

###### 非权限API

GET api/institute 用于获得学院列表

GET api/institute/{instituteId} 用于获得某一学院信息

GET api/institute/{instituteId}/teacher 用于获得某一学院所有老师的列表

GET api/institute/{instituteId}/teacher/{teacherId} 用于获得某一老师的信息

GET api/course?q=工号或Guid 用于获得某一老师的开课信息（未实现）

###### 教务API

GET api/institute/allteacher 用于获得教师账号列表	(未实现)

POST api/institute/ 参数为num,name,informtation 用于增加一个学院

PATCH api/

POST api/institute/{instituteId}/teacher/ 参数为teacherNum,teacherName,teacherIntroductionIntroduction 用于增加某个学院下的老师

PATCH api/institute/{instituteId}/teacher/{teacherId} 用于修改某个学院下某个老师的信息。其中op为操作，默认replace即可，path为操作的字段，需要加反斜线/，value为修改后的值。

demo如下：

```json
[
    {
    "op": "replace",
    "path": "/TeacherIntroduction",
    "value": "徐老师一生志在四方，足迹遍及今21个省、市、自治区，“达人所之未达，探人所之未知”，所到之处，探幽寻秘，并记有游记，记录观察到的各种现象、人文、地理、动植物等状况。"
    }
]
```

抛出204状态码代表已经修改，此时使用GET命令可以查看到信息的改变。

```json
{
    "id": "494710f6-6202-fbe9-d827-1dafde50daa2",
    "instituteId": "bbdee09c-089b-4d30-bece-44df5923716c",
    "teacherNum": 201403,
    "teacherName": "徐彩霞",
    "teacherIntroduction": "徐老师一生志在四方，足迹遍及今21个省、市、自治区，“达人所之未达，探人所之未知”，所到之处，探幽寻秘，并记有游记，记录观察到的各种现象、人文、地理、动植物等状况。"
}
```

