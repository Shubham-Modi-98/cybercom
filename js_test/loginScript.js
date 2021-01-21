sessionStorage.removeItem("loginData");
function checkLogin() 
{
    var email = document.getElementById("txtEmail").value;
    var passwod = document.getElementById("txtPassword").value;
    var admin = localStorage.getItem("adminData");
    var adEmail = JSON.parse(admin).email;
    var adPass = JSON.parse(admin).password;
    var adName = JSON.parse(admin).name;
    
    for(var i=0; i<localStorage.length; i++) {
        var k = localStorage.key(i);
        var user = localStorage.getItem(k);
        var nm = JSON.parse(user).name;
        var em = JSON.parse(user).email;
        var pass = JSON.parse(user).password;
        
        console.log(localStorage.key(i));
        console.log(localStorage.getItem(k));
        console.log(JSON.parse(user).name);
        
        if(email == adEmail && passwod == adPass) {
            loginData = {'email':email, 'password':passwod, 'time': new Date()};
            sessionStorage.setItem('loginData',JSON.stringify(loginData));
            window.location.replace("dashboard.html");
            return true;
        }
        else if(email == em && passwod == pass) {
            loginData = {'email':email, 'password':passwod, 'time': new Date()};
            sessionStorage.setItem('loginData',JSON.stringify(loginData));
            window.location.replace("sabUser.html");
            return true;
        }
    }
}