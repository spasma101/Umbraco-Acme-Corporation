const uglify = require('gulp-uglify-es').default;
const pkg = require('../../../package.json');
const bundles = require('../../config/bundles.json');

module.exports = function (gulp, plugins) {
    return function (cb) {

        if (bundles.js.length) {

            let i = 0;

            while (i < bundles.js.length) {
                var bundle = bundles.js[i];

                gulp.src(bundle.input)
                    //   .pipe(plugins.sourcemaps.init())
                    .pipe(plugins.concat(bundle.filename))

                    //Minify the bundled files
                    .pipe(uglify())

                    //    .pipe(plugins.sourcemaps.write())
                    .pipe(gulp.dest(`${pkg.paths.dist.js}${bundle.dir}`));

                i++;
            }

        }
        cb();

    }
}