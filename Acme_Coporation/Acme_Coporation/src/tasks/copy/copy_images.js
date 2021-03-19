const pkg = require('../../../package.json');

// use the plugins array to configure the compression levels / settings of different types of media, or omit the array entirely which causes a fall back to suggested default settings

// Notes: 
// Do not use an empty array, this will cause compression to stop entirely

module.exports = function (gulp, plugins) {

    const imageminPlugins = [
        // Example options : Leave and uncomment when needed
        // -------------------------------------------------
        
        // plugins.imagemin.gifsicle({ interlaced: true }),
        // plugins.imagemin.mozjpeg({ quality: 75, progressive: true }),
        // plugins.imagemin.optipng({ optimizationLevel: 5 }),
        // plugins.imagemin.svgo({
        //     plugins: [
        //         { removeViewBox: true },
        //         { cleanupIDs: false }
        //     ]
        // })
    ],
    imageminOptions = {
        verbose: true,
        silent: false
    };

    return function (cb) {

        gulp.src(`${pkg.paths.src.images}**/*.*`)
            .pipe(plugins.imagemin(/*imageminPlugins,*/imageminOptions))
            .pipe(gulp.dest(`${pkg.paths.dist.images}`));

        cb();

    }
}