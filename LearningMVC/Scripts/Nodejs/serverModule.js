var httpModule = require('http');
var pipesModule = require('./pipesModule');
var fsModule = require('fs');

//hits when request fired
module.exports.server = httpModule.createServer(function (request, response) {
    var successfulStatusCode = 200;
    console.log(`Request url: ${request.url}`)

    response.writeHead(successfulStatusCode, { 'Content-Type': 'text/plain' });
    var readStream = fsModule.createReadStream(__dirname + '/streamText.txt', 'utf8');

    readStream.pipe(response);
});

var portNumber = 3000;
var localHostIp = '127.0.0.1';
module.exports.server.listen(portNumber, localHostIp)

console.log('Listening to port ' + portNumber);