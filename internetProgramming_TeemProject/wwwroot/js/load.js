const form = document.getElementById("form");
const userid = document.getElementById("userid");
const password = document.getElementById("password");
const identity =  document.getElementsByName("identity");

const uri = "";

//在提交时将数据传输到后端api，通过响应状态判断账号是否存在
form.addEventListener("submit",(Event)=>{
    var value;
    
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
            alert("该账号未注册！请先注册账号")
        }
    })
    .catch(error => console.error('Unable to check account', error));
    Event.preventDefault();
})