function validateForm()
{
    var month = document.getElementById("drpMonth").value;
    var day = document.getElementById("drpDay").value;
    var year = document.getElementById("drpYear").value;
    var email = document.getElementById("txtEmail").value;
    var reemail = document.getElementById("txtReTypeEmail").value;
    var password = document.getElementById("txtPassword").value;
    var repassword = document.getElementById("txtReTypePassword").value;


    if(month == "Month") {
        document.getElementById("msgMonth").innerHTML = "Select month first";
        document.getElementById("drpMonth").focus();
        console.log("Select month first");
    }

    if(day == "Day") {
        document.getElementById("msgDay").innerHTML = "Select day first";
        document.getElementById("drpDay").focus();
    }

    if(year == "Year") {
        document.getElementById("msgYear").innerHTML = "Select year first";
        document.getElementById("drpYear").focus();
    }    

    function checkEmail() {
        if(email != reemail) {
            document.getElementById("msgReEmail").innerHTML = "Email and Re-type Email must be same";
            document.getElementById("txtReTypeEmail").focus();
        }
    }
    
    function checPassword() {
        if(password != repassword) {
            document.getElementById("msgRePassword").innerHTML = "Password and Re-type Password must be same";
            document.getElementById("txtReTypePassword").focus();
        }
    }
}