//获取学院div
const institutes = document.getElementById("institutes");
//获取所有学院的集合
const instituteList = document.getElementsByClassName("institute");

const url = 'api/institute';


//从后台获取学院介绍信息
async function getInsitute() {
    const res = await fetch(url);
    const data = await res.json();

    return data;
}

//获取指定学院的教师数据
async function getTeacher(id){
    const response = await fetch(`${url}/${id}/teacher`);
    const data = await response.json();
    return data;
}

//展示教师数据
async function displayTeacher(id){
    let teacherData = getTeacher(id);
    //获取teacher的父元素
    let father = document.getElementById(id);
    data.forEach(item => {
        let teacher  = document.createElement("div");
        teacher.classList.add("teacher");
        teacher.id = item.id;
        teacher.innerHTML = `
        <div class="teacherNum">教师编号:${item.teacherNum}</div>
        <div class="teacherName">${item.teacherName}</div>
        <div class="teacherIntroduction"> ${item.teacherIntroduction}</div>
        `;
        father.appendChild(teacher);
    });

}

//展示学院及其介绍
async function displayInstitute(){
    let data =await getInsitute();
    data.forEach(item => {
        let institute = document.createElement("div");
        institute.classList.add("institute");
        institute.id = item.id;
        institute.innerHTML = `
        <h3>${item.name}</h3>
        <div class="introduction">${item.introduction}</div>
        `;
        institute.addEventListener("click",(e)=>{
            displayTeacher(item.id);
            });
        institute.addEventListener("dblclick",(e) => {
            institute.lastElementChild.style.display = 'none';
        })
        institutes.appendChild(institute);
    });
}

displayInstitute();
/*
test = {
    data : [
        {
        "id" : "1",
        "name": "cs",
        "introduction":'testcs',
        "teachers":"helu"
        },
        {
        "id" : "1",
        "name": "cs",
        "introduction":'testcs',
        "teachers":"helu"
        },
        {
        "id" : "1",
        "name": "cs",
        "introduction":'testcs',
        "teachers":"helu"
        },
    ]
}

displayInstitute(test.data);
*/
