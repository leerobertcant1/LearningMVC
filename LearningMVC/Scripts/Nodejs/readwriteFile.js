var fsModule = require('fs'); //file system

//Async
var readFile = fsModule.readFile('read.txt', 'utf-8', function (errors, data) {
    console.log(data);

    fsModule.writeFile('writeFile.txt', data + ' Altered')
});

console.log('Proves not async');
