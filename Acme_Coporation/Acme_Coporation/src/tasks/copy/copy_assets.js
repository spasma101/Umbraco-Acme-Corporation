const pkg = require('../../../package.json');
const assets = require('../../config/assets.json');

module.exports = function (gulp, plugins) {
   return function (cb) {

        let i = 0;

        while (i < assets.length) {
            gulp.src(`../node_modules/${assets[i].file}`)
                .pipe(gulp.dest(`${pkg.paths.dist.root}/${assets[i].dest}`));
            i++;
        };

        cb();

    }
}