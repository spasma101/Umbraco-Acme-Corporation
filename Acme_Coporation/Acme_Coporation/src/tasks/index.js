'using strict';

import gulp from 'gulp';
const plugins = require('gulp-load-plugins')();

function getTask(task){
    return require(`./${task}`)(gulp, plugins);
}

// TEST task
gulp.task('test', getTask('./misc/test'));

// CLEAN
gulp.task('clean:js', getTask('./clean/clean_js'));
gulp.task('clean:css', getTask('./clean/clean_css'));
gulp.task('clean:images', getTask('./clean/clean_images'));
gulp.task('clean', getTask('./clean/clean'));

// COPY
gulp.task('copy:images', getTask('./copy/copy_images'));
gulp.task('copy:assets', getTask('./copy/copy_assets'));
gulp.task('copy:fonts', getTask('./copy/copy_fonts'));
gulp.task('copy', gulp.series('copy:images', 'copy:assets', 'copy:fonts'));

//BUNDLE
gulp.task('bundle:js', getTask('./bundles/bundle_js'));
gulp.task('bundleMinify:js', getTask('./bundles/bundleMinify_js'));
gulp.task('bundle:css', getTask('./bundles/bundle_css'));
gulp.task('build:bundles', gulp.parallel('bundle:js', 'bundle:css'));
gulp.task('build:bundlesMinified', gulp.parallel('bundleMinify:js', 'bundle:css'));

// BUILD
gulp.task('build:css', getTask('./build/build_css'));
gulp.task('build:js', getTask('./build/build_js'));
gulp.task('build', gulp.series('clean', 'copy', 'build:js', 'build:css', 'build:bundles'));
//gulp.task('build', gulp.series('clean', 'copy', 'build:js', 'bundle:js', 'build:css'));

// WATCH
gulp.task('watch:scss', getTask('./watch/watch_scss'));
gulp.task('watch:images', getTask('./watch/watch_images'));
gulp.task('watch:scripts', getTask('./watch/watch_scripts'));
gulp.task('watch', gulp.series('watch:scss', 'watch:images', 'watch:scripts'));

//DEV
gulp.task('dev', gulp.series('copy', 'build:css', 'build:bundles', 'watch'));

//PROD
gulp.task('prod', gulp.series('copy', 'build:css', 'build:bundlesMinified'));