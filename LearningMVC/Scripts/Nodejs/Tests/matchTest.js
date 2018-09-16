var assert = require('assert');
var chai = require('chai');
var chaiAsPromised = require('chai-as-promised');
var expect = require('chai').expect;
var matchController = require('./matchController');
var should = require('chai').should(); //is function
var sinon = require('sinon');

chai.use(chaiAsPromised);
chai.should();

//Uses Mocha as testing framework

//Basic assert, BDD Style for expect and should be
describe('MatchController', function () {
    var isMatch = matchController.isMatch('user', 'user');

    describe('Roles Match', function () {
        //Regular
        it('Should return true if values match - *** ASSERT ***', function () {
            assert.equal(true, isMatch);          
        })

        it('Should return true if values match - *** EXPECT ***', function () {
            expect(isMatch).to.be.true;
        })

        it('Should return true if values match -  ***SHOULD ***', function () {
            isMatch.should.be.true;
        }) 
    })

    describe('Random bits', function () {
        it('Should have property name and equal Lee', function () {
            var me = { name: 'Lee', age: 32 }

            me.should.have.property('name').equal('Lee');
        }) 

        it('Should have identical objects', function () {
            var me = { name: 'Lee', age: 32 }
            var me2 = me;

            me2.should.equal(me);
        })

        it('Should be null', function () {
            var _null = null;

            should.not.exist(_null);
        })
    })

    describe('Async', function () {
        it('Should return true if ASYNC roles match - *** ASSERT ASYNC ***', function (done) {
            matchController.isMatchAsync('user',
                function (isMatch) {
                    assert.equal(true, isMatch);
                    done();
                }
            )
        })

        //it('Should return true if PROMISE roles match - *** ASSERT ASYNC ***', function (done) {
        //    matchController.isMatchPromise('user').should.eventually.be.true;
        //})
    })

    //Need to mock req and res which uses Sinon
    //Spys are fakes, used here to mock a web page
    describe('Index', function () {
        it('Should render index', function () {
            var request = {};
            var response = {
                render: sinon.spy()
            };

            matchController.getIndex(request, response);
            response.render.calledOnce.should.be.true;
            response.render.firstCall.args[0].should.equal('index');
        })   

    //Watches functions normally used with anonymous objects
        it('Should Match is Authd', function () {
            var role = 'user';

            sinon.spy(matchController, 'isAuthd');
            matchController.isAuthd(role);
        })

        //Stubs, can stub out a function, has direct control over a function
        it('Should replace a function', function () {
            var stub = sinon.stub(matchController, 'isMatch').callsFake;            
        })

        //Creating Mocks.
        it('Should Mock out', function () {
            var mock = sinon.mock(isMatch);          
            mock.verify();
        })
    })
});
