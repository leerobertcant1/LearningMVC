//Standard function
function standardFunction() {
    console.log('Standard function');
}

standardFunction();

var anonymousFunction = function () { console.log('Anonymous function'); };

//Function expression
anonymousFunction();

function getAnonymousFunction(anonymousFunction) {
    anonymousFunction();
}

getAnonymousFunction(anonymousFunction);