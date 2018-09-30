var httpModule = require('http');
var pipesModule = require('./pipesModule');

module.exports.server = httpModule.createServer(function (request, response) {
    var successfulStatusCode = 200;
    response.writeHead(successfulStatusCode, { 'Content-Type': 'application/json'});


    response.end(JSON.stringify(json));
});

var portNumber = 3000;
var localHostIp = '127.0.0.1';
module.exports.server.listen(portNumber, localHostIp)

console.log('Listening to port ' + portNumber);