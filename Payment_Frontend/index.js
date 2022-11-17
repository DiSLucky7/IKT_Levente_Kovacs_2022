const url = 'http://localhost:60227/Service1.svc/';

async function getCustomers() {

    const userList = await fetch(url + 'getCustomers');
    
    if (!userList.ok) {
        console.log('Get végpont hiba!');
        return;
    };

    const users = await userList.json();
    // console.log(users);

    renderUsers(users);

};

getCustomers();

// fetch('http://localhost:60227/Service1.svc/getCustomers')
//   .then((response) => response.json())
//   .then((data) => console.log(data));

function renderUsers(users) {
    let contentText = '';

    for (let item of users) {
        contentText += `<li  class="list-group-item">
        <strong>${item.Id}</strong>
        ${item.Name}
        ${item.City}
        ${item.Age}<br>
        </li>`
    }

    document.querySelector('.uList').innerHTML = `<ul class="list-group list-group-flush">${contentText}</ul>`

}

const nameInput = document.querySelector('.name');
const cityInput = document.querySelector('.city');
const ageInput = document.querySelector('.age');
const idInput = document.querySelector('.id');

//PUT:
async function postCustomer() {
    var url='http://localhost:60227/Service1.svc/putCustomer';
    var putUser = await fetch(url, {
            method: 'POST',
            // body: body,
            body: JSON.stringify({
                Name: nameInput.value,
                City: cityInput.value,
                Age: ageInput.value
            }),
            headers: {
                'Content-Type': 'application/json'
            }
        });

        if (!putUser.ok) {
            console.log('POST végpont hiba!');
            return;
        }

        var httpMessage = await putUser.json();
        console.log(httpMessage);

        getCustomers();

        // .then(response => response.json())
        // .then(data => {
        //     console.log('Success:', data);
        // })
        // .catch((error) => {
        //     console.error('Error:', error);
        // });
        return 'PUT ok.';
}

// const updateButton = document.querySelector('.update');
// updateButton.addEventListener('click', () => {
//     putCustomer(url);
// })

// document.getElementById('form1').onsubmit = function (event) {
//     event.preventDefault();
//     var nev = event.target.elements.nev.value;
//     var kor = event.target.elements.kor.value;
//     var varos = event.target.elements.varos.value;

//     console.log(nev);

//     var body = JSON.stringify({
//         Name: nev,
//         Age: kor,
//         City: varos
//     })

// }


async function deleteCustomer(id) {
    var putUser = await fetch(url + `deleteCustomer/${id}`, {
            method: 'DELETE',
            // body: body,
            headers: {
                'Content-Type': 'application/json',
            }
        })

        // if (!id.ok) {
        //     console.log('Nem jó id-t adtál meg.');
        //     return;
        // }

        var httpMessage = await putUser.json();
        console.log(httpMessage);

        getCustomers();

        // .then(response => response.json())
        // .then(data => {
        //     console.log('Success:', data);
        // })
        // .catch((error) => {
        //     console.error('Error:', error);
        // });
        return 'PUT ok.';
}

const deleteButton = document.querySelector('.deleteCustomer');
const deleteIdInput = document.querySelector('.deleteId');
deleteButton.addEventListener('click', () => {

    deleteCustomer(deleteIdInput.value);
    getCustomers();


})

// UPDATE
async function updateCustomer() {
    var patchUser = await fetch(url + `patchCustomer`, {
            method: 'PATCH',
            body: JSON.stringify({
                Id: idInput.value,
                Name: nameInput.value,
                City: cityInput.value,
                Age: ageInput.value
            }),
            headers: {
                'Content-Type': 'application/json',
            }
        })

        // if (!id.ok) {
        //     console.log('Nem jó id-t adtál meg.');
        //     return;
        // }

        var httpMessage = await patchUser.json();
        console.log(httpMessage);
        
        getCustomers();
}

const createInput = document.querySelector('.create');
const updateInput = document.querySelector('.update');
const idWrapper = document.querySelector('.id-wrp');
const updateCreateButton = document.querySelector('.update-create');

createInput.addEventListener('change', () => {
    idWrapper.classList.add('hidden');
    updateCreateButton.textContent = 'Add new';
})


updateInput.addEventListener('change', () => {
    idWrapper.classList.remove('hidden');
    updateCreateButton.textContent = 'Edit';
})    

updateCreateButton.addEventListener('click', (event) => {
    event.preventDefault();
    if (createInput.checked) {
        postCustomer();

    } else {
        updateCustomer();
    }
})




// document.getElementById('button2').onclick=function (){
//     var delNumber=document.getElementById('number2').value;
//     delCustomer(delNumber)
// }

// async function delCustomer(delNumber){

//     var url='http://localhost:60227/Service1.svc/deltecustomer/'+delNumber;
//     // var 
// }

// document.getElementById('form1').onsubmit=function (event){
  
//     event.preventDefault();
//     var nev=event.target.elements.nev.value;
//     var kor=event.target.elements.kor.value;
//     var varos=event.target.elements.varos.value;

//     var bodyCustomer=JSON.stringify({
//       Name: nev,
//       Age: kor,
//       City: varos
//     });

//     putCustomer(bodyCustomer);
// }


// async function putCustomer(bodyCustomer){
   
//     var url='http://localhost:60227/Service1.svc/putcustomer';
//     var putUser=await fetch(url,{
//         method: "POST",
//         body: bodyCustomer,
//         headers: {
//             'Content-Type': 'application/json'
//         }
//     })

//     if(!putUser.ok){
//         alert("POST végpont hiba!");
//         return;
//     }

//     var httpMessage=await putUser.json();

//     alert(httpMessage);

//     getCustomers();
// } 

// async function getCustomers(){

//     var url='http://localhost:60227/Service1.svc/getcustomers';
//     var userList = await fetch(url); 

//     if(!userList.ok){
//         alert("GET végpont hiba!");
//         return;
//     }

//     var users=await userList.json();

//     renderUsers(users);

// }

// function renderUsers(users){
//     var contentText='';

//     for (var item of users) {
//         contentText+=`<li>
//         ${item.Id} 
//         ${item.Name}
//         ${item.Age}
//         ${item.City}<br>
//         </li>`;
//     }

//     document.getElementById("uList").innerHTML="<ul>"+contentText+"</ul>"
// }

// getCustomers();