import del from 'del';

const pkg = require('../../../package.json');


module.exports = function(gulp, plugins) {
    
    // use this task as the basis of all others, copy, paste and rename file
    return function(cb) {
        del(`${pkg.paths.dist.images}**/*`, {force: true})
        cb(); // <--- callback signals async completion
    }
}