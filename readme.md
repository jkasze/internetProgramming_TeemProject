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

GET api/institute/allteacher 用于获得教师账号列表。

POST api/institute/ 参数为num,name,informtation 用于增加一个学院。

PATCH api/institute/{instituteId} 用于增加某个学院下的老师，DEMO看下面的。

DELETE api/institute/{instituteId} 

POST api/institute/{instituteId}/teacher/ 参数为teacherNum,teacherName,

teacherIntroduction 用于增加某个学院下的老师

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

DELETE api/institute/{instituteId}/teacher/{teacherId} 用于删除某个学院下某个老师的信息。

POST api/institute/{instituteId}/teacher/ 参数为studentNum,studentName 用于增加某个学院下的学生。

GET api/institute/{instituteId}/student 用于获得某个学院下的学生目录。

GET api/institute/{instituteId}/student/{studentId} 用于获得某个学院下某个学生的信息。

PATCH api/institute/{instituteId}/student/{studentId} 用于修改某个学院下某个学生的信息。其中op为操作，默认replace即可，path为操作的字段，需要加反斜线/，value为修改后的值。

DELETE api/institute/{instituteId}/student/{studentId} 用于删除某个学院下某个学生的信息。

###### 学生API

GET api/student?q=学号  用于通过学号获得学生所有信息。（未实现）

###### 教师API

课程：

GET api/course 用于获得全体课程列表

GET api/course/{courseId} 用于获得某个特定课程的基本信息

POST api/course/{courseId} 用于添加某个特定课程的基本信息

PATCH api/course/{courseId} 用于修改某个课程的信息。其中op为操作，默认replace即可，path为操作的字段，需要加反斜线/，value为修改后的值。

DELETE api/course/{courseId} 用于删除某个特定课程的信息。

GET api/course/{courseId}/lab 用于获得某个特定课程的实验信息

PATCH api/course/{courseId}/lab

删除：

```
[
    {
    "op": "remove",
    "path": "/TeacherIntroduction",
    "value": "徐老师一生志在四方，足迹遍及今21个省、市、自治区，“达人所之未达，探人所之未知”，所到之处，探幽寻秘，并记有游记，记录观察到的各种现象、人文、地理、动植物等状况。"
    }
]
```

更改：

```
[
    {
    "op": "replace",
    "path": "/TeacherIntroduction",
    "value": "徐老师一生志在四方，足迹遍及今21个省、市、自治区，“达人所之未达，探人所之未知”，所到之处，探幽寻秘，并记有游记，记录观察到的各种现象、人文、地理、动植物等状况。"
    }
]
```

增加：

```
[
    {
    "op": "add",
    "path": "/TeacherIntroduction",
    "value": "徐老师一生志在四方，足迹遍及今21个省、市、自治区，“达人所之未达，探人所之未知”，所到之处，探幽寻秘，并记有游记，记录观察到的各种现象、人文、地理、动植物等状况。"
    }
]
```



api/course/{courseId}/ex

api/course/{courseId}/PPT 同理