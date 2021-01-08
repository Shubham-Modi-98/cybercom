function myScript() {

var markMass,markHeight,markBMI;
var johnMass,johnHeight,johnBMI,isHigherBMI;

//Take input from user help of prompt and default value is 0
markMass = prompt('Enter Mark Mass',0);
markHeight = prompt('Enter Mark Height in cms',0);
johnMass = prompt('Enter John Mass',0);
johnHeight = prompt('Enter John Height in cms',0);

//Convert height in meter
markHeight = markHeight/100;
johnHeight = johnHeight/100;

//Logic to find BMI
markBMI =  markMass / (markHeight * markHeight);
console.log("BMI of Mark : "+markBMI)

johnBMI = johnMass / (johnHeight * johnHeight);
console.log("BMI of John : "+johnBMI)

//Check the Mark BMI is greater or not using Ternary Op
isHigherBMI = markBMI > johnBMI ? true : false ;

//Display the Result of isHigherBMI
console.log("Is Mark's BMI higher than John's ? "+isHigherBMI );

//Display the reault as alertDialog
alert("Is Mark's BMI higher than John's ? "+isHigherBMI );

}