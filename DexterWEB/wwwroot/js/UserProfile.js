async function UpdateUser(name, card, passport, address, tel, email, inn) {
    let user = {
        Name: name,
        BankCard: card,
        Passport: passport,
        Address: address,
        Telephone: tel,
        Email: email,
        INN: inn
    }
    const response = await fetch(`https://localhost:44315/api/userprofile/userupdate`, {
        method: "POST",
        headers: {
            "Accept": "application/json",
            'Content-type': 'application/json; charset=UTF-8'
        },
        body: JSON.stringify(user)
    });
    if (response.ok === true) alert("Изменения были сохранены");
    else alert("Возникла какая-то ошибка. Проверьте правильность введеных полей");
}

async function UpdatePassword(password) {
    let user = {
        Password: password
    }
    const response = await fetch(`https://localhost:44315/api/userprofile/updatepassword`, {
        method: "POST",
        headers: {
            "Accept": "application/json",
            'Content-type': 'application/json; charset=UTF-8'
        },
        body: JSON.stringify(user)
    });
    if (response.ok === true) alert("Пароль был обновлен");
    else alert("Возникла какая-то ошибка. Проверьте правильность введеных полей");
}



async function ChangeAva() {
    document.getElementById("btnAva").click();
}

function InitialFunction() {

    document.forms["userform"].addEventListener("submit", e => { 
        e.preventDefault();
        const form = document.forms["userform"];
        const Name = form.elements["Name"].value;
        const BankCard = form.elements["BankCard"].value;
        const Passport = form.elements["Passport"].value;
        const Address = form.elements["Address"].value;
        const Telephone = form.elements["Telephone"].value;
        const Email = form.elements["Email"].value;
        const Inn = form.elements["Inn"].value;
        if (Name == null) alert("Имя не должно быть пустым!");
        else UpdateUser(Name, BankCard, Passport, Address, Telephone, Email, Inn);
    });

    document.forms["passform"].addEventListener("submit", e => {
        e.preventDefault();
        const form = document.forms["passform"];
        const Password = form.elements["Password"].value;
        const RepPassword = form.elements["RepPassword"].value;

        if (Password != RepPassword || Password == null || RepPassword == null) alert("Поля не должны быть пустыми/разными");
        else UpdatePassword(Password);
    });

}