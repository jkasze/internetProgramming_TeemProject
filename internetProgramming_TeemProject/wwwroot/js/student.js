//获取学号
const num = window.localStorage.getItem("num");
//获取token验证字段
const key = "Bearer " + window.localStorage.getItem("key");

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

async function displayStudent(){
    let studentData = await getStudent();
    let course = await getCourse(studentData.id);
    const welcome = document.getElementById("welcome");
    welcome.innerHTML = "";
    welcome.innerHTML = `welcome ${studentData.studentNum} ${studentData.studentName}`;
    
    /*
    course.foreach(Element => {

    })
    */
}

//展示改密码界面
function displayPasswprd(){
    document.getElementById("password").style.display = 'block';
}

function closeInput(){
    document.getElementById("password").style.display = 'none';
}

displayStudent();