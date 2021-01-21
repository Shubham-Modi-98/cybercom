if(localStorage.getItem('adminData') != null) {
    alert("Admin is already Created!");
    document.getElementById("btnRegi").disabled = true;
}
console.log('call');
function storedAdmin() 
{
    console.log('function');
    var name = document.getElementById("txtName").value;
    console.log(name);
    var email = document.getElementById("txtEmail").value;
    var pass = document.getElementById("txtPassword").value;
    var cpass = document.getElementById("confirmPassword").value;
    var city = document.getElementById("drpCity").value;
    var state = document.getElementById("drpState").value;
    console.log(email);
    console.log(city);
    if(pass != cpass) {
        document.getElementById("msgConfirmPassword").innerHTML = "Password and Confirm password must be same";
        document.getElementById("cofirmPassword").focus();
        return false;
    }
    else if(city == "Select City") {
        document.getElementById("msgCity").innerHTML = "Password and Confirm password must be same";
        document.getElementById("drpCity").focus();
        return false;
    }
    else if(state == "Select State") {
        document.getElementById("msgState").innerHTML = "Password and Confirm password must be same";
        document.getElementById("drpState").focus();
        return false;
    }
    else {
        adminData = {'name':name, 'email':email, 'password':pass, 'city':city, 'state':state};
        localStorage.setItem('adminData',JSON.stringify(adminData));
        alert("Admin created Successfully!");
        // window.location = '~/login.html'
        return true;
    }
}
    