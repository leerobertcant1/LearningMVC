var httpModule = require('http');
var fsModule = require('fs');

var readStream = fsModule.createReadStream(__dirname + '/streamText.txt', 'utf8');
var writeStream = fsModule.createWriteStream(__dirname + '/streamWriteText.txt', 'utf8')

readStream.on('data', function (chunk) {
    console.log('Chunk: ' + chunk);

    writeStream.write(chunk);
});     

