function OpenFileExploder() {
    document.getElementById("fileLoader").click();
}

async function Registration(Login, Password, RepPassword, Email) {
    const response = await fetch("/api/users/createuser", {
        method: 'POST', // or 'PUT'
        body: JSON.stringify({
            Login: Login,
            Password: Password,
            RepPassword: RepPassword,
            Email: Email
        }),
        headers: {
            'Accept': 'application/json; charset=utf-8',
            'Content-Type': 'application/json;charset=UTF-8'
        }
    });
    if(response.ok === true) alert("Пользователь зарагестрирован");
    else alert("Неудача");

}


function InitialFunction() {
    // сброс значений формы
    // отправка формы
    document.forms["regform"].addEventListener("submit", e => {
        e.preventDefault();
        const Form = document.forms["regform"];
        const Login = form.elements["Login"].value;
        const Password = form.elements["Password"].value;
        const RepPassword = form.elements["RepPassword"].value;
        const Email = form.elements["Email"].value;
        if (Login != "" & Password != "" & Email != "" & RepPassword == Password)
            Registration(Login, Password, RepPassword, Email);

    });
}
