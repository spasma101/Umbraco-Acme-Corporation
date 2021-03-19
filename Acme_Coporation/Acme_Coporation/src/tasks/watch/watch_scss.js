const pkg = require('../../../package.json');

module.exports = function(gulp, plugins) {
    
    return function(cb) {
        gulp.watch(`${pkg.paths.src.sass}**/*.scss`, gulp.series('build:css'));
        cb();
    }
    
}