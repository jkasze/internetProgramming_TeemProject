function getFileContent(){
    var reader = new FileReader();

    var files = document.getElementById("fileInput").files;
    reader.readAsDataURL(files[0]);	/*这里只有一个文件*/

    /*当文件读取完成后*/
    reader.onload=function(){
        /*显示图片*/
        document.getElementById("imgShower").src = reader.result;
    }
}