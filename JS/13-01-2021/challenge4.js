//create fuction to compare BMI
function compareBMI() 
{
    //create object and function inside object to calculate BMI
    var John = {
        fname: 'John',
        //fetch data from html input and stored in variable
        johnHeight: document.getElementById("johnHeight").value/100,
        johnMass: document.getElementById("johnMass").value,
        //calculating BMI
        johnBMI: function() {
            var BMI = this.johnMass / (this.johnHeight * this.johnHeight);
            return BMI
        }
    }
    var Mark = {
        fname: 'Mark',
        //fetch data from html input and stored in variable
        markHeight: document.getElementById("markHeight").value/100,
        markMass: document.getElementById("markMass").value,
        //calculating BMI
        markBMI: function() {
            var BMI = this.markMass / (this.markHeight * this.markHeight);
            return BMI;
        }
    }
    //call object with fuvction and store BMI in variable
    var jBMI = John.johnBMI();
    var mBMI = Mark.markBMI();
    var msg,nm,bmi;
    //comparing John and Mark's BMI and Display higher BMI in span tag 
    if(jBMI == mBMI) {
        console.log("Both BMI is Equal");
        document.getElementById("msg").innerHTML = "Both BMI is Equal";
        document.getElementById("name").innerHTML = "Name:-" +  John.fname + "/" + Mark.fname;
        document.getElementById("bmi").innerHTML = "BMI:- " + jBMI;

        //Another way to display data you can store in var and display at last
        // msg = "Both BMI is Equal";
        // nm = "Name:-" +  John.fname + "/" + Mark.fname;
        // bmi = "BMI:- " + jBMI;
    }
    else {
        if(jBMI > mBMI) {
            console.log("John BMI is Higher");
            document.getElementById("msg").innerHTML = "John BMI is Higher then Mark";
            document.getElementById("name").innerHTML = "Name:- " + John.fname;
            document.getElementById("bmi").innerHTML = "BMI:- " + jBMI;

            // msg = "John BMI is Higher then Mark"; 
            // nm = "Name:- " + John.fname;
            // bmi = "BMI:- " + jBMI;
        }
        else {
            console.log("Mark BMI is Higher");
            document.getElementById("msg").innerHTML = "Mark BMI is Higher then John";
            document.getElementById("name").innerHTML = "Name:- " + Mark.fname;
            document.getElementById("bmi").innerHTML = "BMI:- " + mBMI;
            
            // msg = "Mark BMI is Higher then John";
            // nm =  "Name:- " + Mark.fname;
            // bmi = "BMI:- " + mBMI;
        }
    }
    //Display result 2nd way
    // document.getElementById("msg").innerHTML = msg;
    // document.getElementById("name").innerHTML = nm;
    // document.getElementById("bmi").innerHTML = bmi;
}

//calculate Particular User's BMI
function calculateBMI() 
{
    //Create object name as user
    var User = {
        //fetch data from html input and stored in variable
        fname: document.getElementById("userName").value,
        userHeight: document.getElementById("userHeight").value/100,
        userMass: document.getElementById("userMass").value,
        //calculate user's bmi
        userBMI: function() {
            var BMI = this.userMass / (this.userHeight * this.userHeight);
            return BMI
        }
    }
    document.getElementById("uName").innerHTML = "Name:- " + User.fname;
    document.getElementById("uBmi").innerHTML = "BMI:- " + User.userBMI();
}