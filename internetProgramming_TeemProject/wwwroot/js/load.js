const form = document.getElementById("form");
const userid = document.getElementById("userid");
const password = document.getElementById("password");
const identity =  document.getElementsByName("identity");
const button = document.getElementById("register");


const uri = "";

//在提交时将数据传输到后端api，通过响应状态判断账号是否存在
form.addEventListener("submit",(Event)=>{
    var value;
    
    //判断是否符合账号规定
    if(check(userid,password) != true){
        Event.preventDefault();
        return;
    }

    //获取选取的身份
    for(let i = 0;i < identity.length; i++){
        if(identity[i].checked == true){
            value = identity[i].value;
        }
    }

    const item = {
        AccountId: parseInt(userid.value,10),
        Password: password.value.toString().trim(),
        Type: value.trim(),
    }
    
    fetch(uri,{
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
            },
        body: JSON.stringify(item)
    }).then((response)=>{
        if(response.status == 200){
            window.location.href = value+".html?"+ "id="+userid.value;
        }
        else{
            alert("账号或密码输入错误，请重试或注册!")
        }
    })
    .catch(error => console.error('Unable to check account', error));
    Event.preventDefault();
})

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

//跳转到注册页面
button.addEventListener("click",(Event)=>{
    window.location.href = "register.html";
})