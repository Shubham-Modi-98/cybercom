document.getElementById("h6Hide").style.visibility = 'hidden';
document.getElementById("errorMsg").style.visibility = 'hidden';
function calcFibonacci() 
{
    var number = document.getElementById("txtNumber").value;
    if(number == '') {
        document.getElementById("errorMsg").style.visibility = 'visible';
        document.getElementById("h6Hide").style.visibility = 'hidden';
        document.querySelector("#errorMsg").textContent = "Enter Number First to Check Fibonacci Series"
        document.getElementById("txtNumber").focus();
    }
    else {
        var a = 0, b = 1, i = 2, c;
        var x = new Array();
        x = [0,1];
        while(i <= number) {
            c = a + b;
            x.push(c);
            a = b;
            b = c;
            i++;
        }
        console.log(x);
        document.getElementById("h6Hide").style.visibility = 'visible';
        document.getElementById("errorMsg").style.visibility = 'hidden';
        document.querySelector("#series").textContent = x;
    }
    
}