const pkg = require('../../../package.json');
const bundles = require('../../config/bundles.json');

module.exports = function (gulp, plugins) {
    return function (cb) {

        if (bundles.css.length) {
            
            let i = 0;

            while(i < bundles.css.length){
                
                var bundle = bundles.css[i];

                    if(bundle.input.length) {

                        gulp.src(bundle.input)
                            .pipe(plugins.sourcemaps.init())
                            .pipe(plugins.concat(bundle.filename))
                            .pipe(plugins.sourcemaps.write())
                            .pipe(gulp.dest(`${pkg.paths.dist.css}${bundle.dir}`));
                    }

                i++;
            }

        }
        cb();

    }
}