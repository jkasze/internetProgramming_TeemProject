//获取学号
const num = window.localStorage.getItem("num");
//获取token验证字段
const key = "Bearer " + window.localStorage.getItem("key");
const password = window.localStorage.getItem("password");

//通过教工号获取个人信息
async function getTeacehr(){
    let res = await fetch(`api/institute/teacher/${num}`,{
        headers : {
            Authorization : key
        }
    });
    let data = res.json();
    return data;
}

//通过教师账号获取教师自己所带的课程
async function getCourse(){
    let res = await fetch(`api/course`,{
        headers : {
            Authorization : key
        }
    });
    let data = res.json();
    return data;
}

//根据课程id获取课程信息
async function getCourseInformation(id){
    let res = await fetch(`api/course/${id}`,{
        headers : {
            Authorization : key
        }
    });
    let data = res.json();
    return data;
}

//展示课程
async function displayCourse(){
    let teacherData = await getTeacehr();
    let course = await getCourse();
    const welcome = document.getElementById("welcome");
    const table = document.getElementById("courseTable");
    table.innerHTML = "";
    welcome.innerHTML = "";
    welcome.innerHTML = `welcome ${teacherData.teacherNum} ${teacherData.teacherName}`;
    const button = document.createElement("button");

    course.forEach( Element => {

        let tr = table.insertRow();
        
        let td1 = tr.insertCell(0);
        let courseName = document.createTextNode(Element.courseName);
        td1.appendChild(courseName);

        let td2 = tr.insertCell(1);
        let startTime = document.createTextNode(Element.startTime);
        td2.appendChild(startTime);

        let td3 = tr.insertCell(2);
        let theoryPeriod = document.createTextNode(Element.theoryPeriod);
        td3.appendChild(theoryPeriod);

        let td4 = tr.insertCell(3);
        let labPeriod = document.createTextNode(Element.labPeriod);
        td4.appendChild(labPeriod);

        let td5 = tr.insertCell(4);
        let information = document.createTextNode(Element.information);
        td5.appendChild(information);

        let td6 = tr.insertCell(5);
        let editButton = button.cloneNode(false);
        editButton.innerText = "编辑";
        editButton.addEventListener("click", (e) => {
            displayEditCourse(Element.id,Element.courseName,Element.theoryPeriod,Element.labPeriod,Element.information);
        });
        td6.appendChild(editButton);
    })
}


//展示课程编辑
function displayEditCourse(id,courseName,theoryPeriod,labPeriod,information){
    document.getElementById("courseId").value = id;
    document.getElementById("edit_courseName").value = courseName;
    document.getElementById("edit_theoryPeriod").value = theoryPeriod;
    document.getElementById("edit_labPeriod").value = labPeriod;
    document.getElementById("edit_information").value = information;

    document.getElementById("edit_course").style.display = "block";
}


//更改课程信息
async function updateCourse(){
    const courseId = document.getElementById("courseId");
    const edit_courseName = document.getElementById("edit_courseName");
    const edit_theoryPeriod = document.getElementById("edit_theoryPeriod");
    const edit_labPeriod = document.getElementById("edit_labPeriod");
    const edit_information = document.getElementById("edit_information");

    if(edit_courseName.value == null || edit_courseName.value == "" || edit_courseName.value == undefined){
        alert("课程名不能为空");
        return false;
    }
    else if(edit_theoryPeriod.value == null || edit_theoryPeriod.value == "" || edit_theoryPeriod.value == undefined){
        alert("理论课时不能为空");
        return false;
    }
    else if(edit_labPeriod.value == null || edit_labPeriod.value == "" || edit_labPeriod.value == undefined){
        alert("实验课时不能为空");
        return false;
    }
    else if(edit_information.value == null || edit_information.value == "" || edit_information.value == undefined){
        alert("课程简介不能为空");
        return false;
    }

    let item = [
        {
            "op": "replace",
            "path": "/CourseName",
            "value": edit_courseName.value,
        },
        {
            "op": "replace",
            "path": "/TheoryPeriod",
            "value": edit_theoryPeriod.value,
        },
        {
            "op": "replace",
            "path": "/LabPeriod",
            "value": edit_labPeriod.value,
        },
        {
            "op": "replace",
            "path": "/Information",
            "value": edit_information.value,
        }
    ]

    fetch(`api/course/${courseId.value}`,{
        method : "PATCH",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
            'Authorization' : key
          },
        body: JSON.stringify(item)
    })
    .then(() => displayCourse())
    .catch(error => console.log("Unable to update course",error));

}


//关闭编辑课程信息框
function closeEditInput(){
    document.getElementById("edit_course").style.display = "none";
}

//添加课程
async function addCourse(){
    const courseName = document.getElementById("courseName");
    const theoryPeriod = document.getElementById("theoryPeriod");
    const labPeriod = document.getElementById("labPeriod");
    const information = document.getElementById("information");

    if(courseName.value == null || courseName.value == "" || courseName.value == undefined){
        alert("请输入课程名");
        return false;
    }
    else if(theoryPeriod.value == null || theoryPeriod.value == "" || theoryPeriod.value == undefined){
        alert("请输入理论课时");
        return false;
    }
    else if(labPeriod.value == null || labPeriod.value == "" || labPeriod.value == undefined){
        alert("请输入实验课时");
        return false;
    }
    else if(information.value == null || information.value == "" || information.value == undefined){
        alert("请输入课程信息");
        return false;
    }

    let item = {
        "courseName": courseName.value.trim(),
        "teachers":  null,
        "courseTime": 0,
        "theoryPeriod": theoryPeriod.value,
        "labPeriod": labPeriod.value,
        "information": information.value
    }

    fetch(`api/course`, {
        method: "POST",
        headers:{
            'Accept': 'application/json',
            'Content-Type': 'application/json',
            'Authorization' : key
        },
        body : JSON.stringify(item)
    })
    .then((Response) => Response.json())
    .then(() =>{
        displayCourse();
        courseName.value = "";
        theoryPeriod.value = "";
        labPeriod.value ="";
        information.value = "";
    })
    .catch(error => console.error('Unable to add course.', error));
}

//展示改密码界面
function displayPasswprd(){
    document.getElementById("password").style.display = 'block';
}

//关闭修改密码界面
function closeInput(){
    document.getElementById("password").style.display = 'none';
}

//修改密码
async function updatePassword(){
    let password1 = document.getElementById("newpassword1");
    let password2 = document.getElementById("newpassword2");

    if(password1.value == null || password1.value == undefined || password1.value == ""){
        alert("密码不能为空！");
        return false;
    }
    else if(password2.value == null || password2.value == undefined || password2.value == ""){
        alert("密码不能为空！");
        return false;
    }
    //验证两次输入的密码是否一致
    else if(password1.value != password2.value){
        alert("请保持两次输入的密码一致" + password2.nodeValue);
        return false;
    }

    let item = [
        {
            "op": "replace",
            "path": "/Password",
            "value": password1.value.trim(),
        }
    ]
    fetch(`/api/account/${num}/${password}`,{
        method : "PATCH",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
            'Authorization' : key
          },
        body : JSON.stringify(item)
    })
    //根据返回值判断修改是否成功
    .then((Response) => {
        if(Response.status == 204){
            alert("修改成功");
        }
        else{
            alert("修改失败");
        }
    });
}


displayCourse();
