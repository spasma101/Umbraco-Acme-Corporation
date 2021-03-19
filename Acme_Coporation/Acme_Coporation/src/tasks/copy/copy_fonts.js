const pkg = require('../../../package.json');

module.exports = function (gulp, plugins) {

    return function (cb) {

        gulp.src(`${pkg.paths.src.fonts}**/*.*`)
            .pipe(gulp.dest(`${pkg.paths.dist.fonts}`));

        cb();

    }
}