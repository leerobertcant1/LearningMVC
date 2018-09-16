var User = /** @class */ (function () {
    function User(firstName, middleInitial, lastName) {
        this.firstName = firstName;
        this.middleInitial = middleInitial;
        this.lastName = lastName;
        this.fullName = firstName + " " + middleInitial + " " + lastName;
    }
    return User;
}());
function greeter(person) {
    return "Hello, " + person.firstName + " " + person.middleInitial + " " + person.lastName;
}
var user = new User("Lee", "R.", "Cant");
document.body.innerHTML = greeter(user);
//# sourceMappingURL=typescriptTest.js.map