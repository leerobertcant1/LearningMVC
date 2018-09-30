var expressModule = require('express');
var app = expressModule();

app.get('/', function (request, response) {
    response.send('Get request');
});

app.get('/profile/:id', function (request, response) {
    response.send('The id is: ' + request.params.id);
});

app.listen(3000);                               