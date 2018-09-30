var expressModule = require('express');
var bodyParserModule = require('body-parser');

var app = expressModule();
var urlEncodedParser = bodyParserModule.urlencoded({extended: false});

app.set('view engine', 'ejs');

//Parses data posted to the server, body parser is a npm package
app.post('/post', urlEncodedParser, function (request, response) {
    console.log(request.body);

    response.render('post');
});

app.get('/post',  function (request, response) {
    response.render('post');
});

app.listen(3000); 