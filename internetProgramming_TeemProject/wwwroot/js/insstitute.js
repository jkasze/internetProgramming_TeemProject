//获取学院div
const institutes = document.getElementById("institutes");
//获取所有学院的集合
const instituteList = document.getElementsByClassName("institute");

const url = 'https://localhost:44397/api/institute';

//从后台获取学院介绍信息
async function getInsitute() {
    const res = await fetch(url);
    const data = await res.json();

    return data;
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
        <div class="teacher">${item.teachers}<div>
        `;
        institute.lastElementChild.style.display = 'none';
        institute.addEventListener("click",(e)=>{
            institute.lastElementChild.style.display = "block";
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
