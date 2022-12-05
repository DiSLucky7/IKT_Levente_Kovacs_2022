const apiUrl = 'http://localhost:54198/Service1.svc/';

const container = document.querySelector('.container');
const tableContainer = document.querySelector('.table-container');
const username = document.querySelector('.username');
const password = document.querySelector('.password');
const loginButton = document.querySelector('.login__button');
const dangerAlert = document.querySelector('.alert-danger');

// ----- USER MODEL -----
// id
// uname
// email
// password
// fullname
// active
// rank
// ban
// reg__time
// log__time


// ----- FETCHES -----
async function login(UName, Pwd) {
    try {
        const response = await fetch(apiUrl + `login/${UName}/${Pwd}`, {
            method: 'GET',
            // body: body,
            headers: {
                'Content-Type': 'application/json',
            }
        })

        // if (!id.ok) {
        //     console.log('Nem jó id-t adtál meg.');
        //     return;
        // }

        return await response.json();

    } catch {
        return null;
    }
}

async function getUsers() {
    const response = await fetch(apiUrl + 'getUsers');
    return await response.json();
}

async function postUser() {
    const usernameInput = document.querySelector('.username');
    const emailInput = document.querySelector('.email');
    const passwordInput = document.querySelector('.password');
    const fullnameInput = document.querySelector('.fullname');
    const activeInput = document.querySelector('.active');
    const rankInput = document.querySelector('.rank');
    const banInput = document.querySelector('.ban');
    const reg__timeInput = document.querySelector('.reg__time');
    const log__timeInput = document.querySelector('.log__time');

    const response = await fetch(apiUrl + 'post', {
        method: 'POST',
        body: JSON.stringify({
            UName: usernameInput.value,
            Email: emailInput.value,
            Pwd: passwordInput.value,
            Fullname: fullnameInput.value,
            Active: activeInput.value,
            Rank: rankInput.value,
            Ban: banInput.value,
            RegTime: reg__timeInput.value,
            LogTime: log__timeInput.value
        }),
        headers: {
            'Content-Type': 'application/json'
        }
    });

    // if (!response.ok) {
    //     console.log('POST végpont hiba!');
    //     return;
    // }

    return await response.json();
}

async function updateUser(Id) {
    const usernameInput = document.querySelector('.username');
    const emailInput = document.querySelector('.email');
    const passwordInput = document.querySelector('.password');
    const fullnameInput = document.querySelector('.fullname');
    const activeInput = document.querySelector('.active');
    const rankInput = document.querySelector('.rank');
    const banInput = document.querySelector('.ban');
    const reg__timeInput = document.querySelector('.reg__time');
    const log__timeInput = document.querySelector('.log__time');

    const response = await fetch(apiUrl + 'patch', {
        method: 'PATCH',
        body: JSON.stringify({
            Id: Id,
            UName: usernameInput.value,
            Email: emailInput.value,
            Pwd: passwordInput.value,
            Fullname: fullnameInput.value,
            Active: activeInput.value,
            Rank: rankInput.value,
            Ban: banInput.value,
            RegTime: reg__timeInput.value,
            LogTime: log__timeInput.value
        }),
        headers: {
            'Content-Type': 'application/json'
        }
    });

    // if (!response.ok) {
    //     console.log('POST végpont hiba!');
    //     return;
    // }

    return await response.json();
}


async function deleteUser(Id) {
    await fetch(apiUrl + `delete/${Id}`, {
        method: 'DELETE'
    })
}

// ----- ADMIN INTERFACE -----
async function generatingAdminTemplate() {
    const userList = await getUsers();
    console.log(userList);

    const oneRowTemplate = `<form class="container add__new__form col-12 p-4 mt-3">
    <div class="d-flex flex-column flex-lg-row">
        <div class="mb-3 me-3">
            <label for="exampleInputusername1" class="form-label">Username</label>
            <input type="text" class="username form-control form-control-sm" id="exampleInputusername1" aria-describedby="usernameHelp">
        </div>
        <div class="mb-3 me-3">
            <label for="exampleInputEmail1" class="form-label">E-mail</label>
            <input type="email" class="email form-control form-control-sm" id="exampleInputEmail1">
        </div>
        <div class="mb-3 me-3">
            <label for="exampleInputPassword1" class="form-label">Password</label>
            <input type="password" class="password form-control form-control-sm" id="exampleInputPassword1" aria-describedby="passwordHelp">
        </div>
        <div class="mb-3 me-3">
            <label for="exampleInputFullname1" class="form-label">Full Name</label>
            <input type="text" class="fullname form-control form-control-sm" id="exampleInputFullname1">
        </div>
        <div class="mb-3 me-3">
            <label for="exampleInputActive1" class="form-label">Active</label>
            <input type="string" class="active form-control form-control-sm" id="exampleInputActive1" aria-describedby="activeHelp">
        </div>
        <div class="mb-3 me-3">
            <label for="exampleInputRank1" class="form-label">Rank</label>
            <input type="number" class="rank form-control form-control-sm" id="exampleInputRank1">
        </div>
        <div class="mb-3 me-3">
            <label for="exampleInputBan1" class="form-label">Ban</label>
            <input type="string" class="ban form-control form-control-sm" id="exampleInputBan1" aria-describedby="BanHelp">
        </div>
        <div class="mb-3 me-3">
            <label for="exampleInputRegTime1" class="form-label">Reg. Time</label>
            <input type="text" class="reg__time form-control form-control-sm" id="exampleInputRegTime1" aria-describedby="RegTimeHelp">
        </div>
        <div class="mb-3">
            <label for="exampleInputLogTime1" class="form-label">Log. Time</label>
            <input type="text" class="log__time form-control form-control-sm" id="exampleInputLogTime1" aria-describedby="LogTimeHelp">
        </div>

    </div>

    <button type="submit" class="col-12 add__user btn btn-primary btn-block m-0">Add User</button>
</form>`

    document.body.innerHTML = `${oneRowTemplate}
    <table class="table mt-5 mx-auto">
        <thead>
            <tr>
                <th scope="col">Id</th>
                <th scope="col">Username</th>
                <th scope="col">E-mail</th>
                <th scope="col">Password</th>
                <th scope="col">Fullname</th>
                <th scope="col">Active</th>
                <th scope="col">Rank</th>
                <th scope="col">Ban</th>
                <th scope="col">Reg. Time</th>
                <th scope="col">Log. Time</th>
                <th scope="col"></th>
                <th scope="col"></th>
            </tr>
        </thead>
        <tbody>
        </tbody>
    </table>`

    const tbody = document.querySelector('tbody');

    // ----- GENERATING ROWS IN TABLE -----
    for (user of userList) {
        const trow = `
    <tr>
    <td>${user.Id}</td>
    <td>${user.UName}</td>
    <td>${user.Email}</td>
    <td>${user.Pwd}</td>
    <td>${user.Fullname}</td>
    <td>${user.Active}</td>
    <td>${user.Rank}</td>
    <td>${user.Ban}</td>
    <td>${user.RegTime}</td>
    <td>${user.LogTime}</td>
    <td>
    <button class="edit__button"><i class="fa fa-pencil" aria-hidden="true"></i></button>
    </td>
    <td>
    <button class="delete__button"><i class="fa fa-trash" aria-hidden="true"></i></button>
    </td>
    </tr>`
        tbody.insertAdjacentHTML("afterbegin", trow);
    }

}

// function createUser() {
// }


async function adminMethods() {

    await generatingAdminTemplate();

    // ----- ADD NEW USER ------
    const addNewButton = document.querySelector('.add__user');
    addNewButton.addEventListener('click', async (event) => {
        event.preventDefault();
        await postUser();
        await generatingAdminTemplate();
    })

    // ----- UPDATE USER -----
    const editButtons = document.querySelectorAll('.edit__button');
    editButtons.forEach(button => button.addEventListener('click', () => {
        const tr = button.parentNode.parentNode;
        const Id = tr.children[0].textContent;
        const UName = tr.children[1].textContent;
        const Email = tr.children[2].textContent;
        const Pwd = tr.children[3].textContent;
        const Fullname = tr.children[4].textContent;
        const Active = tr.children[5].textContent;
        const Rank = tr.children[6].textContent;
        const Ban = tr.children[7].textContent;
        const RegTime = tr.children[8].textContent;
        const LogTime = tr.children[9].textContent;

        document.body.innerHTML = `<form class="container add__new__form col-12 p-4 mt-3">
                <div class="d-flex flex-column flex-lg-row">
                    <div class="mb-3 me-3">
                        <label for="exampleInputusername1" class="form-label">Username</label>
                        <input value="${UName}" type="text" class="username form-control form-control-sm" id="exampleInputusername1" aria-describedby="usernameHelp">
                    </div>
                    <div class="mb-3 me-3">
                        <label for="exampleInputEmail1" class="form-label">E-mail</label>
                        <input value="${Email}" type="email" class="email form-control form-control-sm" id="exampleInputEmail1">
                    </div>
                    <div class="mb-3 me-3">
                        <label for="exampleInputPassword1" class="form-label">Password</label>
                        <input value="${Pwd}" type="password" class="password form-control form-control-sm" id="exampleInputPassword1" aria-describedby="passwordHelp">
                    </div>
                    <div class="mb-3 me-3">
                        <label for="exampleInputFullname1" class="form-label">Full Name</label>
                        <input value="${Fullname}" type="text" class="fullname form-control form-control-sm" id="exampleInputFullname1">
                    </div>
                    <div class="mb-3 me-3">
                        <label for="exampleInputActive1" class="form-label">Active</label>
                        <input value="${Active}" type="string" class="active form-control form-control-sm" id="exampleInputActive1" aria-describedby="activeHelp">
                    </div>
                    <div class="mb-3 me-3">
                        <label for="exampleInputRank1" class="form-label">Rank</label>
                        <input value="${Rank}" type="string" class="rank form-control form-control-sm" id="exampleInputRank1">
                    </div>
                    <div class="mb-3 me-3">
                        <label for="exampleInputBan1" class="form-label">Ban</label>
                        <input value="${Ban}" type="string" class="ban form-control form-control-sm" id="exampleInputBan1" aria-describedby="BanHelp">
                    </div>
                    <div class="mb-3 me-3">
                        <label for="exampleInputRegTime1" class="form-label">Reg. Time</label>
                        <input value="${RegTime}" type="text" class="reg__time form-control form-control-sm" id="exampleInputRegTime1" aria-describedby="RegTimeHelp">
                    </div>
                    <div class="mb-3">
                        <label for="exampleInputLogTime1" class="form-label">Log. Time</label>
                        <input value="${LogTime}" type="text" class="log__time form-control form-control-sm" id="exampleInputLogTime1" aria-describedby="LogTimeHelp">
                    </div>

                </div>

                <button type="submit" class="col-12 edit__user btn btn-primary btn-block m-0">Edit User</button>
            </form>`

        const editButton = document.querySelector('.edit__user');
        editButton.addEventListener('click', async () => {
            event.preventDefault();
            await updateUser(Id);
            await generatingAdminTemplate();
        })
    }))

    // ----- DELETE USER -----
    const deleteButtons = document.querySelectorAll('.delete__button');
    deleteButtons.forEach(button => button.addEventListener('click', async () => {
        const tr = button.parentNode.parentNode;
        const Id = tr.children[0].textContent;
        console.log(Id);
        await deleteUser(Id);
        await generatingAdminTemplate();
    }))
}

// ----- LOGIN FORM SUBMIT -----
loginButton.addEventListener('click', async () => {
    event.preventDefault();
    const loginData = await login(username.value, password.value);

    try {
        const user = loginData.loginResult;
        console.log('Success.');
        // console.log(user.Rank);

        switch (user.Rank) {
            case 0:
                container.innerHTML = `<h1 class="text-center mt-5">Wellcome ${user.UName}!</h1>`;
                break;
            case 1:
                adminMethods();
                break;
            default:
            // code block
        }

    } catch {
        dangerAlert.classList.add('transition');
        setTimeout(() => {
            dangerAlert.classList.remove('transition');
        }, 3000)
        console.log('Try again.');
    }
})
