//function OpenFileExploder() {
//    document.getElementById("fileLoader").click();
//}

//async function Registration(Login, Password, RepPassword, Email) {
//    const response = await fetch("/api/users/createuser", {
//        method: 'POST', // or 'PUT'
//        body: JSON.stringify({
//            Login: Login,
//            Password: Password,
//            RepPassword: RepPassword,
//            Email: Email

//        }),
//        headers: {
//            'Accept': 'application/json; charset=utf-8',
//            'Content-Type': 'application/json;charset=UTF-8'
//        }
//    });
//    if(response.ok === true) alert("Пользователь зарагестрирован");
//    else alert("Неудача");

//}

//async function UploadAvayat(data)
//{
//    const response = await fetch("/api/users/uploadavatar", {
//        method: 'POST', // or 'PUT'
//        body: JSON.stringify({
//            file: data
//        }),
//        headers: {
//            'Accept': 'application/json; charset=utf-8',
//            'Content-Type': 'application/json;charset=UTF-8'
//        }
//    });
//    if (response.ok === true) alert("Изображение загружено");
//    else alert("Изображение не загружено");
//}

//function InitialFunction() {
//    // сброс значений формы
//    // отправка формы
//    document.forms["avatarform"].addEventListener("submit", e => {
//        e.preventDefault();
//        const Form = document.forms["avatarform"];
//        var formdata = new FormData();
//        var filedata = document.getElementsByName("files");
//        var i = 0, len = filedata.files.length, file;
//        for (; i < len; i++) {
//            file = filedata.files[i];
//            formdata.append("file", file);
//        }
//        UploadAvatar(formdata);
//    });
//    document.forms["regform"].addEventListener("submit", e => {
//        e.preventDefault();
//        const Form = document.forms["regform"];
//        const Login = form.elements["Login"].value;
//        const Password = form.elements["Password"].value;
//        const RepPassword = form.elements["RepPassword"].value;
//        const Email = form.elements["Email"].value;
//        if (Login == ""z)
//            Registration(mark, numberOfCar, CodeOfParking);
//        else
//            EditCar(id, mark, numberOfCar, CodeOfParking);

//    });
//    GetCar();

//}


async function Status() {
    const response = await fetch("/api/users" {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) alert("Пользователь зарегестрирован");
    else alert("Пользователь не смог зарегестрироваться");
}