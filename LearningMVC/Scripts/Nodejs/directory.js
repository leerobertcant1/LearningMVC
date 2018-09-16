var fsModule = require('fs'); //file system

//creates directory
fsModule.mkdirSync('assets');
fsModule.mkdir('assets2', function () {
    console.log('Created asynchronously');
})

//removes directory
fsModule.rmdirSync('assets');
fsModule.rmdir('assets2', function (){
    console.log('Removed asynchronnously');
})

