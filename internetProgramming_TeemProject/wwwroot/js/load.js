const form = document.getElementById("form");
const userid = document.getElementById("userid");
const password = document.getElementById("password");
const identity =  document.getElementsByName("identity");
const buttonInstitute = document.getElementById("institute");


const uri = "api/token";


async function getKeyValue(){
    var value;
    
    //判断是否符合账号规定
    if(check(userid,password) != true){
        return false;
    }

    //获取选取的身份
    for(let i = 0;i < identity.length; i++){
        if(identity[i].checked == true){
            value = identity[i].value;
        }
    }

    const item = {
        username: userid.value.trim(),
        password: password.value.toString().trim(),
    }

    fetch(uri,{
        method: 'POST',
        headers: {
            'Accept': '*/*',
            'Content-Type': 'application/json'
            },
        body: JSON.stringify(item)
    })
    .then(response => response.text())
    .then(data => {
        console.log(data);
        window.localStorage.setItem("key",data.toString());
        window.sessionStorage.setItem("key",data.toString());
        window.localStorage.setItem("num",userid.value);
        window.sessionStorage.setItem("num",userid.value);
    })
    .then(() => window.location.href = value + ".html");
    
}


function check(id, pwd){
    //账号为空
    if(id.value == null || id.value == undefined || id.value == ""){
        alert("请输入账号！");
        return false;
    }
    //密码为空
    if(pwd.value == null || pwd.value == undefined || pwd.value == ""){
        alert("请输入密码!");
        return false;
    }
    //账号不能为非数字字符
    if(isNaN(Number(id.value))){
        alert("账号应为数字！");
        return false;
    }
    return true;
}
