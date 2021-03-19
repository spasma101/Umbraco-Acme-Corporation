const pkg = require('../../../package.json'),

      sassOptions = {
        "outputStyle": "compressed"
      },
      autoprefixerOptions = {}

module.exports = function (gulp, plugins) {
    return function (cb) {

        gulp.src(`${pkg.paths.src.sass}*.scss`)
            .pipe(plugins.sourcemaps.init())
            .pipe(plugins.sass(sassOptions).on('error', plugins.sass.logError))
            .pipe(plugins.autoprefixer(autoprefixerOptions))
            .pipe(plugins.sourcemaps.write('./maps'))
            .pipe(gulp.dest(`${pkg.paths.dist.css}`));
        
        cb();

    };
    return function (pipeline) {
        gulp.src(`${pkg.paths.src.css}**/*.css`),
            gulp.dest(`${pkg.paths.dist.css}`)

        pipeline();

    };

};