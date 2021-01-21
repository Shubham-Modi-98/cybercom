for(var i=0; i<localStorage.length; i++) {
    var k = localStorage.key(i);
    var user = localStorage.getItem(k);
    var name = JSON.parse(user).name;
    var dob = JSON.parse(user).dob;
    var x = new Date(dob);
    var day = x.getDate();
    var month = x.getMonth();
    var curDay = new Date().getDate();
    var curMonth = new Date().getMonth();
    
    console.log(day);
    console.log(month);
    console.log(curDay);
    console.log(curMonth);
    
    var age = JSON.parse(user).age;
    var count = 0;
    var count18 = 0;
    var count50 = 0;
    if(k == 'adminData') {
        continue;
    }
    else {
        if(age < 18) {
            count++;
        }
        else if(age >= 18 && age < 50) {
            count18++;
        }
        else {
            count50++;
        }
        if(day == curDay && month == curMonth) {
            document.getElementById("birthdayText").innerHTML = "Today's is " + name + "'s Birthday<br/>";
        }
        document.getElementById("countAge").innerHTML = count + ' Users';
        document.getElementById("countAge18").innerHTML = count18 + ' Users';
        document.getElementById("countAge50").innerHTML = count50 + ' Users';
    }
}