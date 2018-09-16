var httpModule = require('http');
var pipesModule = require('./pipesModule');
var fsModule = require('fs');

module.exports.server = httpModule.createServer(function (request, response) {
    var successfulStatusCode = 200;
    response.writeHead(successfulStatusCode, { 'Content-Type': 'text/html' });
    var readStream = fsModule.createReadStream(__dirname + '/index.html', 'utf8');

    readStream.pipe(response);
});

var portNumber = 3000;
var localHostIp = '127.0.0.1';
module.exports.server.listen(portNumber, localHostIp)

console.log('Listening to port ' + portNumber);