for(var i=0; i<localStorage.length; i++) {
    var k = localStorage.key(i);
    console.log(localStorage.key(i));
    console.log(localStorage.getItem(k));
    var user = localStorage.getItem(k);
    console.log(JSON.parse(user).name);
    var nm = JSON.parse(user).name;
    var em = JSON.parse(user).email;
    var pas = JSON.parse(user).password;
    var d = JSON.parse(user).dob;
    var date = new Date(d)
    age = new Date().getFullYear() - date.getFullYear();
    if(k == 'adminData') {
        continue;
    }
    else {
        
        document.getElementById("tdName").innerHTML += nm+ '<br/></td><td>';
        document.getElementById("tdEmail").innerHTML += em + '<br/></td><td>';
        document.getElementById("tdPass").innerHTML += pas + '<br/></td><td>';
        document.getElementById("tdAge").innerHTML += age + '<br/></td><td>';
        document.getElementById("tdDob").innerHTML += date.getDate() + '/' + (parseInt(date.getMonth())+1) + '/' + date.getFullYear() + '<br/></td><td>';
        document.getElementById("tdAction").innerHTML += "<a href=''>Edit</a>/<a href='#'>Delete</a><br/></td>";
    }
}

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
        userData = {'name':name, 'email':email, 'password':pass, 'dob':dob};
        localStorage.setItem(i, JSON.stringify(userData));
        return true;
        // for(var i=0; i<localStorage.length; i++) {
        //     var k = localStorage.key(i);
        //     console.log(localStorage.key(i));
        //     console.log(localStorage.getItem(k));
        // }
        
    }
}
function deleteData(key)
{
    localStorage.removeItem(k);
}