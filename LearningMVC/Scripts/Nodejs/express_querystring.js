var expressModule = require('express');
var app = expressModule();

app.set('view engine', 'ejs'); //ejs is a templated engine which was downoaded through npm

app.get('/profile', function (request, response) {
    var queryString = request.query;
    console.log('querystring: ' + queryString.id);

    response.render('profile', { id: request.params.id, person: { name: 'lee', age: 32 } });
});

app.listen(3000); 