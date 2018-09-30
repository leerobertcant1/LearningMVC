var httpModule = require('http');

//hits when request fired
server = httpModule.createServer(function (request, response) {
    var successfulStatusCode = 200;

    console.log(`Request url: ${request.url}` )

    response.writeHead(successfulStatusCode, { 'Content-Type': 'text/plain' });
    response.end("Response text");
});

var portNumber = 3000;
var localHostIp = '127.0.0.1';
server.listen(portNumber, localHostIp)

console.log('Listening to port ' + portNumber);