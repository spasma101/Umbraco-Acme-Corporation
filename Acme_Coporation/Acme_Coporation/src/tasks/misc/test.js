const pkg = require('../../../package.json');

module.exports = function(gulp, plugins) {
    
    return function(cb) {
        console.log(plugins)
        cb();
    }
    
}