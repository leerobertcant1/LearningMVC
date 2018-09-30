var expressModule = require('express');
var app = expressModule();

app.set('view engine', 'ejs'); //ejs is a templated engine which was downoaded through npm
app.use('/styles', expressModule.static('Styles'));
//middleware needed here to feed up style sheets, etc. Next tells which middlewear to go to next, i.e. next get method

app.get('/profile/:id', function (request, response) {
    var me = {name:'lee', age: 32}
    response.render('profile', { id: request.params.id, person: me});
});

app.listen(3000); 