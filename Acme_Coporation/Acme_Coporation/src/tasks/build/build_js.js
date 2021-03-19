const pkg = require('../../../package.json');
const gulpWebpack = require('webpack-stream');
const webpack = require('webpack');
const glob = require('glob');

module.exports = function (gulp, plugins) {

    return function (cb) {

        var entryPoints = glob.sync(`${pkg.paths.src.js}*.js`).reduce((acc, path) => {
            const entry = path.replace(`${pkg.paths.src.js}`, '').replace('.js', '');
            acc[entry] = path;
            return acc;
        }, {});

        if (entryPoints.length) {
            gulp.src(`${pkg.paths.src.js}`)
                .pipe(gulpWebpack({
                    entry: entryPoints,
                    output: {
                        filename: './[name].min.js'
                    }
                }, webpack, function (err, stats) {
                }))
                .pipe(gulp.dest(`${pkg.paths.dist.js}`));
        }


        cb();
    }

}