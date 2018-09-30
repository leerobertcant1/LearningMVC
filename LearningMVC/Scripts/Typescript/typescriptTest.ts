class User
{
    fullName: string;
    constructor(public firstName: string, public middleInitial: string, public lastName: string)
    {
        this.fullName = firstName + " " + middleInitial + " " + lastName;
    }
}

interface User
{
    firstName: string;
    lastName: string;
}

function greeter(person: User)
{
    return "Hello, " + person.firstName + " " + person.middleInitial + " " + person.lastName;
}

let user = new User("Lee", "R.", "Cant");

document.body.innerHTML = greeter(user);