
async function GetUser(Login, Password,
    RepPassword, Email)
{
    const response = await fetch(`https://localhost:44315/api/users/${Login}`, {
        method: "GET",
        headers: {  "Accept": "application/json" }
    });
    if (!(response.ok === true)) {
        let el = document.getElementById("ErrorL");
        let erp = document.getElementById("ErrorRP");
        let ep = document.getElementById("ErrorP");
        erp.textContent = ""; ep.textContent = "";
        el.textContent = "Данный пользователь уже существует в системе!";
    }
    else {
        let el = document.getElementById("ErrorL");
        let erp = document.getElementById("ErrorRP");
        let ep = document.getElementById("ErrorP");
        erp.textContent = ""; ep.textContent = "";
        el.textContent = "";
        CreateUser(Login, Password,
            RepPassword, Email);
    }
}

async function CreateUser(Login, Password,
    RepPassword, Email) {
    if (RepPassword != Password) {
        let erp = document.getElementById("ErrorRP");
        let ep = document.getElementById("ErrorP");
        erp.textContent = "Пароли не совпадают"; ep.textContent = "Пароли не совпадают";
    }
    else { 
        let erp = document.getElementById("ErrorRP");
        let ep = document.getElementById("ErrorP");
        erp.textContent = ""; ep.textContent = "";
        let user = {
            Login: Login,
            Password: Password,
            RepPassword: RepPassword,
            Email: Email
        };
        const response = await fetch("https://localhost:44315/api/users/createuser", {
            method: "POST",
            headers: {
                "Accept": "application/json",
                'Content-type': 'application/json; charset=UTF-8'
            },
            body: JSON.stringify(user)
        });

        if (response.ok === true) {
            let pst = document.getElementById("PStatus");
            let ist = document.getElementById("IconStatus");
            let pist = document.getElementById("PIconStatus");
            ist.value = ""; pst.textContent = "";
            pst.className = "StatusOfRegistrationTrue";
            pist.className = "StatusOfRegistrationTrue";
            ist.textContent = "check_circle";
            pst.textContent = `Пользователь ${Login} успешно зарегестрирован`;
            pst.style.display = "block";
            pist.style.display = "block";
        }
        else {
            let pst = document.getElementById("PStatus");
            let ist = document.getElementById("IconStatus");
            let pist = document.getElementById("PIconStatus");
            ist.value = ""; pst.textContent = "";
            pst.removeAttribute('class');
            pist.removeAttribute('class');
            pst.className = "StatusOfRegistrationFalse";
            pist.className = "StatusOfRegistrationFalse";
            ist.textContent = "cancel";
            pst.textContent = "Ошибка регистрации!";
            pst.style.display = "block";
            pist.style.display = "block";
        }

    }

}


function InitialFunction() {
    let el = document.getElementById("ErrorL");
    let ep = document.getElementById("ErrorP");
    let erp = document.getElementById("ErrorRP");
    let ee = document.getElementById("ErrorE");
    erp.textContent = ""; el.textContent = "";
    ep.textContent = ""; ee = "";
    erp.className = "ErrorSpan"; el.className = "ErrorSpan"; ep.className = "ErrorSpan"; ee.className = "ErrorSpan";  
    document.getElementById("PIconStatus").style.display = "none"; 
    document.getElementById("PStatus").style.display = "none";

    document.forms["regform"].addEventListener("submit", e => {
        e.preventDefault();
        const form = document.forms["regform"];
        const Login = form.elements["Login"].value;
        const Password = form.elements["Password"].value;
        const RepPassword = form.elements["RepPassword"].value;
        const Email = form.elements["Email"].value;

        GetUser(Login, Password,
            RepPassword, Email);
    });

}