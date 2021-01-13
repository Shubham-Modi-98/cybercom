//create static array
var billArray = [124,48,268];

//display array as Span tag
document.getElementById("bill").innerHTML = "Bill Array:- [" + billArray + "]";

//Tip calculation function 
function calculateTip() 
{
    //create 2 array to store tip and total bill(tip + bill)
    var tipArray = new Array();
    var tipBillArray = new Array();

    //for loop to access each bill from billArray
    for (var i=0; i<billArray.length; i++) {
        if (billArray[i] < 50) {
            tipArray[i] = (billArray[i] * 20)/100;
        }
        else if (billArray[i] >= 50 && billArray[i] <= 200) {
            tipArray[i] = (billArray[i] * 15)/100;
        }
        else {
            tipArray[i] = (billArray[i] * 10)/100;
        }
        //calculate total bill with tip and storein aray
        tipBillArray[i] = billArray[i] + tipArray[i];
    }
    //display tip array and total(bill + tip) array as span on screen
    document.getElementById("tip").innerHTML = "Tip Array:- [" + tipArray + "]";
    document.getElementById("tipBill").innerHTML = "Bill+Tip Array:- [" + tipBillArray + "]";
}

function tipCalculator()
{
    var billAmount = document.getElementById("billAmount").value;
    var tipPerc = document.getElementById("tipPercentage").value;
    var totalBill = 0,tipAmount=0;
    if(billAmount == '' || tipPerc == '' || tipPerc > 100) {
        if(billAmount == '') {
            alert("Bill amount must required!!");
        }
        if(tipPerc == '') {
            alert("% must required!!");
        }
        if(tipPerc > 100) {
            alert("% must between 0 to 100");
        }
    }
    else {
        tipAmount = (billAmount * tipPerc)/100;
        document.getElementById("amount").innerHTML = billAmount;
        document.getElementById("percentage").innerHTML = tipAmount;
        document.getElementById("total").innerHTML = (parseInt(billAmount)+parseInt(tipAmount));
    }
}