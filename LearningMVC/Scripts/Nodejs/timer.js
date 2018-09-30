console.log('App.js file loaded');

//*** Global object stuff***
console.log('Directory is: ' + __dirname);
console.log('Filenname is: ' + __filename);
//3000 ms
setTimeout(function () {
    console.log('App.js 3 seconds passed');
}, 3000);

var time = 0;
var timer = setInterval(function () {
    time += 2;
    console.log(time + ' seconds passed');

    //Stops timer
    if (time > 5) {
        clearInterval(timer);
    }
}, 4000);


