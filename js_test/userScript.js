var allUserData = `<table class="table table-bordered table-light" id="tableData">
              <thead>
                <tr>
                  <th scope="col">Name</th>
                  <th scope="col">Email</th>
                  <th scope="col">Password</th>
                  <th scope="col">Birthdate</th>
                  <th scope="col">Age</th>
                  <th scope="col" colspan="2">Actions</th>
                </tr>
              </thead>
              <tbody>`
              
              for(var i=0; i<localStorage.length; i++) {
                var k = localStorage.key(i);
                var user = localStorage.getItem(k);
                var nm = JSON.parse(user).name;
                var em = JSON.parse(user).email;
                var pas = JSON.parse(user).password;
                var d = JSON.parse(user).dob;
                var date = new Date(d)
                var age = JSON.parse(user).age;
                if(k == 'adminData') {
                    continue;
                }
                else {
                    allUserData += `<tr>
                                <th scope="row">${nm}</th>
                                <td>${em}</td>
                                <td>${pas}</td>
                                <td>${date}</td>
                                <td>${age}</td>
                                <td>
                                <button type="button" onclick="editData('${nm}','${em}','${pas}','${date}')" class="btn btn-link"> Edit </button>
                                </td>
                                <td>
                                <button type="button" onclick="deleteData('${em}')" class="btn btn-link"> Delete </button>
                                </td>
                            </tr>`   
               }
            }
    allUserData += `</tbody></table>`;
    document.getElementById('allUser').innerHTML += allUserData ;

function deleteData(key)
{
    alert(key + ' User Deleted');
    localStorage.removeItem(key);
}

function editData(nm,em,pas,date) 
{
    document.getElementById("txtName").value = nm;
    document.getElementById("txtName").focus();
    document.getElementById("txtEmail").value = em;
    document.getElementById("txtEmail").disabled = true;
    document.getElementById("txtPassword").value = pas;
    document.getElementById("txtDob").value = new Date(date).toISOString().substring(0,10);
}


//         document.getElementById("tdName").innerHTML += nm+ '<br/></td><td>';
//         document.getElementById("tdEmail").innerHTML += em + '<br/></td><td>';
//         document.getElementById("tdPass").innerHTML += pas + '<br/></td><td>';
//         document.getElementById("tdAge").innerHTML += age + '<br/></td><td>';
//         document.getElementById("tdDob").innerHTML += date.getDate() + '/' + (parseInt(date.getMonth())+1) + '/' + date.getFullYear() + '<br/></td><td>';
//         document.getElementById("tdAction").innerHTML += "<a href=''>Edit</a>/<a href='javascript:deleteData(i)'>Delete</a><br/></td>";

function addUser() 
{
    var name = document.getElementById("txtName").value;
    console.log(name);
    var email = document.getElementById("txtEmail").value;
    var pass = document.getElementById("txtPassword").value;
    var date = document.getElementById("txtDob").value;
    var dob = new Date(date);
    var i;
    // for(var i=0; i<localStorage.length; i++) {
    //    key = localStorage.key(i);
    // }
    // key = key + 1;
    // console.log(key);
        
    //var i = 0;
    //for(i=0; i<localStorage.length; i++) {
    //    key = localStorage.key(i);
    //}
    //console.log(i);
    if(name == '') {
        alert("Name must be required");
        document.getElementById("txtName").focus();
        return false;
    }
    else if(email == '') {
        alert("Email must be required");
        document.getElementById("txtEmail").focus();   
        return false;
    }
    else if(pass == '') {
        alert("Passeord must be required");
        document.getElementById("txtPassword").focus();   
        return false;
    }
    else if(dob == '') {
        alert("DOB must be required");
        document.getElementById("txtDob").focus();
        return false;
    }
    else {
        for(i=0; i<localStorage.length; i++) {
            key = localStorage.key(i);
        }
        console.log(i);
        var age = new Date().getFullYear() - dob.getFullYear();
        console.log(age)
        userData = {'name':name, 'email':email, 'password':pass, 'dob':dob, 'age':age};
        localStorage.setItem(email, JSON.stringify(userData));
        return true;
        // for(var i=0; i<localStorage.length; i++) {
        //     var k = localStorage.key(i);
        //     console.log(localStorage.key(i));
        //     console.log(localStorage.getItem(k));
        // }
        
    }
}