//获取学号
const num = window.localStorage.getItem("num");
//获取token验证字段
const key = "Bearer " + window.localStorage.getItem("key");
const password = window.localStorage.getItem("password");

//通过学号获取个人信息
async function getStudent(){
    let res = await fetch(`api/institute/student/${num}`,{
        headers : {
            Authorization : key
        }
    });
    let data = res.json();
    return data;
}

async function getCourse(id){
    let res = await fetch(`api/institute/student/${id}/courses`,{
        headers : {
            Authorization : key
        }
    });
    let data = res.json();
    return data;
}

//异步获取课程名
async function getCourseInformation(id){
    let res = await fetch(`api/course/${id}`,{
        headers : {
            Authorization : key
        }
    });
    let data = res.json();
    return data;
}


async function displayStudent(){
    let studentData = await getStudent();
    let course = await getCourse(studentData.id);
    const welcome = document.getElementById("welcome");
    const table = document.getElementById("courseTable");
    welcome.innerHTML = "";
    welcome.innerHTML = `welcome ${studentData.studentNum} ${studentData.studentName}`;
    
    
    course.forEach(async(Element) => {
        let courseData = await getCourseInformation(Element.courseId);

        let tr = table.insertRow();
        
        let td1 = tr.insertCell(0);
        let courseName = document.createTextNode(courseData.courseName);
        td1.appendChild(courseName);

        let td2 = tr.insertCell(1);
        let startTime = document.createTextNode(courseData.startTime);
        td2.appendChild(startTime);

        let td3 = tr.insertCell(2);
        let theoryPeriod = document.createTextNode(courseData.theoryPeriod);
        td3.appendChild(theoryPeriod);

        let td4 = tr.insertCell(3);
        let labPeriod = document.createTextNode(courseData.labPeriod);
        td4.appendChild(labPeriod);

        let td5 = tr.insertCell(4);
        let information = document.createTextNode(courseData.information);
        td5.appendChild(information);

        let td6 = tr.insertCell(5);
        let mainPoints = document.createTextNode(Element.mainPoints);
        td6.appendChild(mainPoints);

        let td7 = tr.insertCell(6);
        let labPoints = document.createTextNode(Element.labPoints);
        td7.appendChild(labPoints);
        
        let td8 = tr.insertCell(7);
        let exPoints = document.createTextNode(Element.exPoints);
        td8.appendChild(exPoints);


    })
    
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
    .then((Response) => {
        if(Response.status == 200){
            alert("修改成功");
        }
        else{
            alert("修改失败");
        }
    });
}

displayStudent();