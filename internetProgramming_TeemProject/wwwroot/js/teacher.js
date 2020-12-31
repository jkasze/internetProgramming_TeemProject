//获取教工号
const num = window.localStorage.getItem("num");
//获取token验证字段
const key = "Bearer " + window.localStorage.getItem("key");

//通过教工号获取个人信息
async function getTeacher(){
    let res = await fetch(`api/institute/teacher/${num}`,{
        headers : {
            Authorization : key
        }
    });
    let data = res.json();
    return data;
}

async function getCourse(id){
    let res = await fetch(`api/institute/teacher/${id}/courses`,{
        headers : {
            Authorization : key
        }
    });
    let data = res.json();
    return data;
}
