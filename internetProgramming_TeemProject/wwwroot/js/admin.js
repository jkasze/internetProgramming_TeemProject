const instituteUrl = "/api/institute";
const teacehrUrl = "/api/institute/allteacher";



//从后台获取学院介绍信息
async function getInsitute() {
    const res = await fetch(instituteUrl);
    const data = await res.json();
    return data;
}


//从后台获取教师信息
async function getTeacehr(){
    const res = await fetch(teacehrUrl);
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
        'Content-Type': 'application/json'
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
    select.innerHTML = "";
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

function closeInput(){
    document.getElementById("edit_teacher").style.display = "none";
}


displayInstitute();
displayTeacher();