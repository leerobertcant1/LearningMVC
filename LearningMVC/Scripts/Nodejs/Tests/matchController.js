//Controller for the tests

function matchController() {
    var _roleUser = 'user';
    var _roleAdmin = 'admin';
    
    function isMatch(neededRole) {
        return _roleUser === neededRole;
    }

    function isMatchAsync(neededRole, cb) {
        setTimeout(function () { cb(_roleUser === neededRole) }, 0);
    }

    function isMatchPromise(neededRole, cb) {
        return new Promise(function (resolve) {
            setTimeout(function () { resolve(_roleUser === neededRole) }, 0);
        });
    }

    function getIndex(request, response) {
        response.render('index');  
    }

    function getIndexAsAdmin(requestRole, response) {
        if (requestRole.role = _roleAdmin) {
            response.render('index');
        }
        response.Render('error');
    }

    function isAuthd(role) {
        if (_roleUser === role) {
            return true;
        }
    }

    return { isMatch, isMatchAsync, isMatchPromise, getIndex, isAuthd };
}

module.exports = matchController();
