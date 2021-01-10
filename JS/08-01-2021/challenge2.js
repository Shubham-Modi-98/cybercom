//Variables Declaration
var johnTeamScore,mikeTeamScore,maryTeamScore; 
var avgJohnTeamSore,avgMikeTeamScore,avgMaryTeamScore;
var winnerTeamScore = 0;
var winnerName = "";

//Total of Team Scores
johnTeamScore = 88+120+103;
mikeTeamScore = 77+120+103;
maryTeamScore = 97+134+105;

//Logic to find Average Score of Teams
avgJohnTeamSore = johnTeamScore/3;
console.log("Average Score Of John : " +avgJohnTeamSore);

avgMikeTeamScore = mikeTeamScore/3;
console.log("Average Score Of Mike : " +avgMikeTeamScore);

avgMaryTeamScore = maryTeamScore/3;
console.log("Average Score Of John : " +avgMaryTeamScore);


// Check the winning team between John and Mike
if(avgJohnTeamSore == avgMikeTeamScore) {
    console.log("Match is Drawn!!!, Both Average : " + avgJohnTeamSore);
    winnerTeamScore = avgJohnTeamSore;
}
else if (avgJohnTeamSore > avgMikeTeamScore) {
    console.log("John's Team Won with Average Score : " + avgJohnTeamSore);
    winnerTeamScore = avgJohnTeamSore;
    winnerName = "John";
}
else {
    console.log("Mike's Team Won with Average Score : " + avgMikeTeamScore);
    winnerTeamScore = avgMikeTeamScore;
    winnerName = "Mike";
}

// Check winner of John or Mike with Mary
if(avgMaryTeamScore == winnerTeamScore) {
    console.log("Match is Drawn!!!, Both Average : " + avgMaryTeamScore);
}
else if (avgMaryTeamScore > winnerTeamScore) {
    console.log("Mary's Team Won with Average Score : " + avgMaryTeamScore);
}
else {
    console.log(winnerName +"'s Team Won with Average Score : " + winnerTeamScore);
}

function checkWinner() 
{
    //Variable Declaration used in Function
    var johnTeamScore,mikeTeamScore,maryTeamScore; 
    var avgJohnTeamSore,avgMikeTeamScore,avgMaryTeamScore;
    var winnerTeamScore = 0;
    var winnerName = "";
    var johnMatch1,johnMatch2, johnMatch3;
    var mikeMatch1,mikeMatch2,mikeMatch3;
    var maryMatch1,maryMatch2,maryMatch3;

    //Take input from user help of prompt and default value is 0
    johnMatch1 = prompt("Enter John Match 1 Score",0);
    johnMatch2 = prompt("Enter John Match 2 Score",0);
    johnMatch3 = prompt("Enter John Match 3 Score",0);

    mikeMatch1 = prompt("Enter Mike Match 1 Score",0);
    mikeMatch2 = prompt("Enter Mike Match 2 Score",0);
    mikeMatch3 = prompt("Enter Mike Match 3 Score",0);

    //Sum of 3 matches score 
    johnTeamScore = parseInt(johnMatch1) + parseInt(johnMatch2) + parseInt(johnMatch3);
    mikeTeamScore = parseInt(mikeMatch1) + parseInt(mikeMatch2) + parseInt(mikeMatch3);
    
    //find Averag of John and Mike
    avgJohnTeamSore = johnTeamScore/3;
    console.log("Average Score Of John : " +avgJohnTeamSore);

    avgMikeTeamScore = mikeTeamScore/3;
    console.log("Average Score Of Mike : " +avgMikeTeamScore);


    // Check the winning team between John and Mike
    if(avgJohnTeamSore == avgMikeTeamScore) {
        console.log("Match is Drawn!!!, Both Average : " + avgJohnTeamSore);
        winnerTeamScore = avgJohnTeamSore;
    }
    else if (avgJohnTeamSore > avgMikeTeamScore) {
        console.log("John's Team Won with Average Score : " + avgJohnTeamSore);
        winnerTeamScore = avgJohnTeamSore;
        winnerName = "John";
    }
    else {
        console.log("Mike's Team Won with Average Score : " + avgMikeTeamScore);
        winnerTeamScore = avgMikeTeamScore;
        winnerName = "Mike";
    }

    //Take input from user help of prompt and default value is 0
    maryMatch1 = prompt("Enter Mary Match 1 Score",0);
    maryMatch2 = prompt("Enter Mary Match 2 Score",0);
    maryMatch3 = prompt("Enter Mary Match 3 Score",0);

    //Calculate Mary's score total
    maryTeamScore = parseInt(maryMatch1) + parseInt(maryMatch2) + parseInt(maryMatch3);

    //find Averag Score of Mary
    avgMaryTeamScore = maryTeamScore/3;
    console.log("Average Score Of Mary : " +avgMaryTeamScore);
    alert("Average Score Of Mary : " +avgMaryTeamScore);

    // Check winner of John or Mike with Mary
    if(avgMaryTeamScore == winnerTeamScore) {
        console.log("Match is Drawn!!!, Both Average : " + avgMaryTeamScore);
        alert("Match is Drawn!!!, Both Average : " + avgMaryTeamScore);
    }
    else if (avgMaryTeamScore > winnerTeamScore) {
        console.log("Mary's Team Won with Average Score : " + avgMaryTeamScore);
        alert("Mary's Team Won with Average Score : " + avgMaryTeamScore);
    }
    else {
        console.log(winnerName +"'s Team Won with Average Score : " + winnerTeamScore);
        alert(winnerName +"'s Team Won with Average Score : " + winnerTeamScore);
    }
}
