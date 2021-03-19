import del from 'del';

const pkg = require('../../../package.json');

module.exports = function(gulp, plugins) {
    
    return function(cb) {
        del(`${pkg.paths.dist.css}**/*`, {force: true})
        cb();
    }

}