var a = {x:'ABC'};
for(var i=0; i<5; i++)
{
    console.log(a.x);
    console.log(a);

}
for (X in a) {
    document.writeln(a.x);
    document.writeln(X.a);
    document.writeln(X);
    
    console.log(a.x);
    console.log(X.a);
    console.log(X);
}

//Object Function used by Another function
var shubh = {
    name: 'Shubham Modi',
    doy: 1998,
    age: function() {
        var curYear = new Date().getFullYear();
        var curAge = curYear - this.doy;
        document.writeln(`${this.name} age is ${curAge}.`);
        console.log(`${this.name} age is ${curAge}.`);
    }
}

//Diff object used diff object funcion
var teenu = {
    name: 'Teenu Modi',
    doy: 1969
};

shubh.age();

teenu.age = shubh.age;
teenu.age();

sonam = function(dob) {
    var name = 'Soam Modi';
    var age = 2021 - dob;
    document.writeln(`${name} age is ${age}.`);
    console.log(`${name} age is ${age}.`);
}

sonam(1989);


// Function Prototype Chaining
var Person = function(name,doy) {
    this.name = name;
    this.doy = doy;
}

Person.prototype.calcAge = 
function() {
    var curYear = new Date().getFullYear();
    var curAge = curYear - this.doy;
    document.writeln(`${this.name} age is ${curAge}.`);
    console.log(`${this.name} age is ${curAge}.`);
}


virat = {
    name: 'Virat Kohli',
    doy: 1988
};

var vk = new Person(virat.name,virat.doy);
vk.calcAge();

var chris = new Person('Chris Hemsworth',1983).calcAge();