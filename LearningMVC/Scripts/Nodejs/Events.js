var eventsModule = require('events'); // events
var utilitiesModule = require('util'); //can inherit objects built in

//Observable type thing
var emitter = new eventsModule.EventEmitter();

emitter.on('emittedEvent', function (receivedMessage) {
    console.log('ReceivedMessage: ' + receivedMessage);
});

//his happens in any situation JS can't handle
emitter.emit('emittedEvent', 'Event emitted');

//inherit events emitter
var Name = function (nameVal) {
    this.nameVal = nameVal;
};

utilitiesModule.inherits(Name, eventsModule.EventEmitter);

var firstName = new Name('Lee');
var middleName = new Name('Robert');                                                                                                                                         
var lastName = new Name('Cant');

//Object required.
var me = [firstName, middleName, lastName];

me.forEach(function (name) {
    name.on('individual', function (individual) {
        console.log(name.nameVal);
       });
});

firstName.emit('individual', ' is the name')