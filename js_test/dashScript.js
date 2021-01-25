var count = 0;
var count18 = 0;
var count50 = 0;
var birthday = false;
var curDay = new Date().getDate();
var curMonth = new Date().getMonth();

console.log(curDay);
console.log(curMonth);

for(var i=0; i<localStorage.length; i++) {
    var k = localStorage.key(i);
    var user = localStorage.getItem(k);
    var name = JSON.parse(user).name;
    var dob = JSON.parse(user).dob;
    var x = new Date(dob);
    var day = x.getDate();
    var month = x.getMonth();
    
    console.log(day);
    console.log(month);
    
    var age = JSON.parse(user).age;
    if(k == 'adminData') {
        continue;
    }
    else {
        if(age < 18) {
           count =  (parseInt(count) + 1);
        }
        else if(age >= 18 && age < 50) {
            count18 =  (parseInt(count18) + 1);
        }
        else {
            count50 =  (parseInt(count50) + 1);
        }
        if(day == curDay && month == curMonth) {
            birthday = true;
            document.getElementById("birthdayText").innerHTML += "Today's is '" + name + "' Birthday!<br/>";
        }
    }
}
if(!birthday) {
    document.getElementById("birthdayText").innerHTML = "No birthday Today!!!<br/>";
}
document.getElementById("countAge").innerHTML = count + ' Users';
document.getElementById("countAge18").innerHTML = count18 + ' Users';
document.getElementById("countAge50").innerHTML = count50 + ' Users';