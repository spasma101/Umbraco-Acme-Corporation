const pkg = require('../../../package.json');

module.exports = function(gulp, plugins) {

    return function(cb) {
        gulp.watch(`${pkg.paths.src.scripts}**/*.js*`, gulp.series('bundle:js'));
        cb();
    }

}