var httpModule = require('http');
var fsModule = require('fs');

var server = httpModule.createServer(function (request, response) {
    var url = request.url;
    console.log(url);
    var successfulStatusCode = 200;

    if (url === '/home' || url === '/') {
        response.writeHead(successfulStatusCode, { 'Content-Type': 'text/html' });
        fsModule.createReadStream(__dirname + '/index.html').pipe(response);
    }
    else {
        response.writeHead(successfulStatusCode, { 'Content-Type': 'text/html' });
        fsModule.createReadStream(__dirname + '/contact.html').pipe(response);
    }
});

var portNumber = 3000;
var localHostIp = '127.0.0.1';
server.listen(portNumber, localHostIp)

console.log('Listening to port ' + portNumber);