const instituteUrl = "/api/institute";
const teacehrUrl = "/api/institute/allteacher";
const studentUrl = "/api/institute/allstudent";
let key = "Bearer " + window.localStorage.getItem("key");


//从后台获取学院介绍信息
async function getInsitute() {
    const res = await fetch(instituteUrl);
    const data = await res.json();
    return data;
}


//从后台获取教师信息
async function getTeacehr(){
    const res = await fetch(teacehrUrl,{
        headers : {
            Authorization : key
        }
    });
    const data = res.json();
    return data;
}

//从后台获取学生信息
async function getStudent(){
const res = await fetch(studentUrl,{
    headers : {
        Authorization : key
    }
    });
    const data = res.json();
    return data;
}


//使用post添加学院
async function updateInstituce(){
    const instituteNum = document.getElementById("instituteNum");
    const instituteName = document.getElementById("instituteName");
    const instituteIntroduction  = document.getElementById("instituteIntroduction");
    if(instituteNum.value == null || instituteNum.value == "" || instituteNum.value == undefined){
        alert("请输入学院号!");
        return false;
    }
    else if(instituteName.value == null || instituteName.value == "" || instituteName.value == undefined){
        alert("请输入学院名称!");
        return false;
    }
    else if(instituteIntroduction.value == null || instituteIntroduction.value == "" || instituteIntroduction.value == undefined){
        alert("请输入学院简介!");
        return false;
    }

    item = {
        num : instituteNum.value.trim(),
        name: instituteName.value.trim(),
        introduction : instituteIntroduction.value.trim()
    }

    fetch(instituteUrl,{
        method: 'POST',
        headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json',
        'Authorization' : key
        },
        body:JSON.stringify(item)
    })
    .then(response => response.json())
    .then(() => {
      displayInstitute();
      instituteNum.value = '';
      instituteName.value = "";
      instituteIntroduction.value = "";
    })
    .catch(error => console.error('Unable to add.', error));
}

async function displayInstitute(){
    const table = document.getElementById("instituteTable");
    const select = document.getElementById("institute");
    const studentSelect = document.getElementById("studentSelectInstituteId");

    select.innerHTML = "";
    studentSelect.innerHTML = "";
    table.innerHTML = "";
    let data = await getInsitute();

    //在列表中添加学校信息
    data.forEach(element => {
        let tr = table.insertRow();
        
        let td1 = tr.insertCell(0);
        let Num = document.createTextNode(element.num);
        td1.appendChild(Num);

        let td2 = tr.insertCell(1);
        let Name = document.createTextNode(element.name);
        td2.appendChild(Name);

        let td3 = tr.insertCell(2);
        let Introduction = document.createTextNode(element.introduction);
        td3.appendChild(Introduction);

        //在教师模块中动态添加下拉框信息
        let option = document.createElement("option");
        option.value = element.id;
        option.innerHTML = `
        ${element.name}
        `;
        select.appendChild(option);

        //在学生模块中动态添加下拉框信息
        let opt = document.createElement("option");
        opt.value = element.id;
        opt.innerHTML = `
        ${element.name}
        `
        studentSelect.appendChild(opt);
    });
}

//展示教师编辑框
function displayEditTeacher(fatherId,id,num,name,introduction){

    document.getElementById("teacherId").value = id;
    document.getElementById("instituteId").value = fatherId;
    document.getElementById("edit_teacherNum").value = num;
    document.getElementById("edit_teacherName").value = name;
    document.getElementById("edit_teacherIntroduction").value = introduction;

    document.getElementById("edit_teacher").style.display = "block";
}


//展示学生编辑框
function displayEditStudent(fatherId,id,num,name){
    document.getElementById("studentId").value = id;
    document.getElementById("studentInstituteId").value = fatherId;
    document.getElementById("edit_studnetNum").value = num;
    document.getElementById("edit_studentName").value = name;

    document.getElementById("edit_student").style.display = "block";
}


//展示教师信息
async function displayTeacher(){
    const table = document.getElementById("teacherTable");
    table.innerHTML = "";
    let data = await getTeacehr();
    const button = document.createElement("button");
    data.forEach(element => {
        let tr = table.insertRow();
        
        let td1 = tr.insertCell(0);
        let Num = document.createTextNode(element.teacherNum);
        td1.appendChild(Num);

        let td2 = tr.insertCell(1);
        let Name = document.createTextNode(element.teacherName);
        td2.appendChild(Name);

        let td3 = tr.insertCell(2);
        let Introduction = document.createTextNode(element.teacherIntroduction);
        td3.appendChild(Introduction);

        let td4 = tr.insertCell(3);
        let editButton = button.cloneNode(false);
        editButton.innerText = "编辑";
        editButton.addEventListener("click", (e) => {
            displayEditTeacher(element.instituteId,element.id,element.teacherNum,element.teacherName,element.teacherIntroduction);
        });
        td4.appendChild(editButton);

        let td5 = tr.insertCell(4);
        let deleteButton = button.cloneNode(false);
        deleteButton.innerHTML = "删除";
        deleteButton.addEventListener("click", (e) => {
            deleteTeacher(element.instituteId,element.id);
        })
        td5.appendChild(deleteButton);
    });
}


//展示学生信息
async function displayStudent(){
    const table = document.getElementById("studentTable");
    table.innerHTML = "";
    let data = await getStudent();
    const button = document.createElement("button");

    data.forEach(element => {
        let tr = table.insertRow();
        
        let td1 = tr.insertCell(0);
        let Num = document.createTextNode(element.studentNum);
        td1.appendChild(Num);

        let td2 = tr.insertCell(1);
        let Name = document.createTextNode(element.studentName);
        td2.appendChild(Name);

        let td3 = tr.insertCell(2);
        let editButton = button.cloneNode(false);
        editButton.innerText = "编辑";
        editButton.addEventListener("click", (e) => {
            displayEditStudent(element.instituteId,element.id,element.studentNum,element.studentName);
        });
        td3.appendChild(editButton);

        let td4 = tr.insertCell(3);
        let deleteButton = button.cloneNode(false);
        deleteButton.innerHTML = "删除";
        deleteButton.addEventListener("click", (e) => {
            deleteStudent(element.instituteId,element.id);
        })
        td4.appendChild(deleteButton);
    })
}

//添加教师到后台
async function addTeacher(){
    const teacherNum = document.getElementById("teacherNum");
    const teacherName = document.getElementById("teacherName");
    const teacherIntroduction = document.getElementById("teacherIntroduction");
    const select = document.getElementById("institute");

    let index = select.selectedIndex;
    let teacher_institute_id = select.options[index].value;


    if(teacherNum.value == null || teacherNum.value == "" || teacherNum.value == undefined){
        alert("请输入教师工号！");
        return false;
    }
    else if(teacherName.value == null || teacherName.value == "" || teacherName.value == undefined){
        alert("请输入教师姓名！");
        return false;
    }
    else if(teacherIntroduction.value == null || teacherIntroduction.value == "" || teacherIntroduction.value == undefined){
        alert("请输入教师简介!");
        return false;
    }

    let item = {
        "teacherNum" : teacherNum.value.trim(),
        "teacherName" : teacherName.value.trim(),
        "teacherIntroduction" : teacherIntroduction.value.trim()
    }

    fetch(`api/institute/${teacher_institute_id}/teacher`,{
        method: 'POST',
        headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json',
        'Authorization' : key
        },
        body:JSON.stringify(item)
    })
    .then(response => response.json())
    .then(() => {
      displayTeacher();
      teacherNum.value = '';
      teacherName.value = "";
      teacherIntroduction.value = "";
    })
    .catch(error => console.error('Unable to add teacher.', error));
}


//添加学生到后台
async function addStudent(){
    const studentNum = document.getElementById("studentNum");
    const studentName = document.getElementById("studentName");
    const select = document.getElementById("studentSelectInstituteId");

    let index = select.selectedIndex;
    let student_institute_id = select.options[index].value;


    if(studentNum.value == null || studentNum.value == "" || studentNum.value == undefined){
        alert("请输入学号！");
        return false;
    }
    else if(studentName.value == null || studentName.value == "" || studentName.value == undefined){
        alert("请输入学生姓名！");
        return false;
    }

    let item = {
        "studentNum" : studentNum.value.trim(),
        "studentName" : studentName.value.trim(),
    }

    fetch(`api/institute/${student_institute_id}/student`,{
        method: 'POST',
        headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json',
        'Authorization' : key
        },
        body:JSON.stringify(item)
    })
    .then(response => response.json())
    .then(() => {
      displayStudent();
      studentNum.value = '';
      studentName.value = "";
    })
    .catch(error => console.error('Unable to add student.', error));
}


//更新教师信息
async function updateTeacher(){
    const fatherId  = document.getElementById("instituteId");
    const id = document.getElementById("teacherId");
    const num = document.getElementById("edit_teacherNum");
    const name = document.getElementById("edit_teacherName");
    const introduction = document.getElementById("edit_teacherIntroduction");

    if(num.value == null || num.value == "" || num.value == undefined){
        alert("更改教工号不能为空.");
        return false;
    }
    else if(name.value == null || name.value == "" || name.value == undefined){
        alert("更改教师姓名不能为空.");
        return false;
    }
    else if(introduction.value == null || introduction.value == "" || introduction.value == undefined){
        alert("教师介绍不能为空.");
        return false;
    }

    //构造更改的body
    const item = [
        {
            "op": "replace",
            "path": "/teacherIntroduction",
            "value": introduction.value.trim(),
        },
        {
            "op": "replace",
            "path": "/teacherNum",
            "value": num.value.trim(),
        },
        {
            "op": "replace",
            "path": "/teacherName",
            "value": name.value.trim(),
        }
    ]

    fetch(`api/institute/${fatherId.value}/teacher/${id.value}`,{
        method : "PATCH",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
            'Authorization' : key
          },
        body: JSON.stringify(item)
    })
    .then(() => displayTeacher())
    .catch(error => console.log("Unable to update teacher",error));
    
}


//更新学生信息
async function updateStudent(){
    const fatherId  = document.getElementById("studentInstituteId");
    const id = document.getElementById("studentId");
    const num = document.getElementById("edit_studnetNum");
    const name = document.getElementById("edit_studentName");

    if(num.value == null || num.value == "" || num.value == undefined){
        alert("更改学号号不能为空.");
        return false;
    }
    else if(name.value == null || name.value == "" || name.value == undefined){
        alert("更改学生姓名不能为空.");
        return false;
    }

    //构造更改的body
    const item = [
        {
            "op": "replace",
            "path": "/studentNum",
            "value": num.value.trim(),
        },
        {
            "op": "replace",
            "path": "/studentName",
            "value": name.value.trim(),
        }
    ]

    fetch(`/api/institute/${fatherId.value}/student/${id.value}`,{
        method : "PATCH",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
            'Authorization' : key
          },
        body: JSON.stringify(item)
    })
    .then(() => displayStudent())
    .catch(error => console.log("Unable to update student",error));
    
}


//删除教师
async function deleteTeacher(fatherId, id){
    const url = `/api/institute/${fatherId}/teacher/${id}`;
    fetch(url,{
        method: 'DELETE',
        headers: {
            'Authorization' : key
        }
    })
    .then(() => displayTeacher())
    .catch(error => console.error("Unable to delete teacher.", error));
}

//删除学生
async function  deleteStudent(fatherId, id){
    const url = `/api/institute/${fatherId}/student/${id}`;
    fetch(url,{
        method : "DELETE",
        headers: {
            'Authorization' : key
        }
    })
    .then(() => displayStudent())
    .catch(error => console.error("Unable to delete student.", error))
}

//关闭教师编辑框
function closeInput(){
    document.getElementById("edit_teacher").style.display = "none";
}

//关闭学生编辑框
function closeStudentInput(){
    document.getElementById("edit_student").style.display = "none";
}


displayInstitute();
displayTeacher();
displayStudent();