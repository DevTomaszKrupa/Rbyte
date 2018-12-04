var gulp = require('gulp');
var del = require('del');
var gutil = require('gulp-util');
var connect = require('gulp-connect');
var sass = require('gulp-sass');

var paths = {
    scss: ['Styles/**/*.scss'],
    csslib: [

    ],
    outDir: "wwwroot/css",
};

// include plugins
var plugins = require("gulp-load-plugins")({
    pattern: ['gulp-*', 'gulp.*', 'del'],
    replaceString: /\bgulp[\-.]/
});

// libs css
gulp.task('csslib', function () {
    gulp.src(paths.csslib)
        .pipe(plugins.concat('vendor.css'))
        .pipe(gulp.dest(paths.outDir + 'lib/css'))
});

// sass
gulp.task('sass', function () {
    return gulp.src(paths.scss)
        .pipe(sass().on('error', sass.logError))
        .pipe(plugins.concat('rbyte.css'))
        .pipe(gulp.dest(paths.outDir))
        .pipe(connect.reload());
});

// create a default task to build the app
gulp.task('default', ['sass', 'csslib'], function () {
    return gutil.log('App is built!')
});

// configure which files to watch and what tasks to use on file changes
gulp.task('watch', function () {
    gulp.watch(paths.scss, ['sass']);
    gulp.watch(paths.csslib, ['csslib']);
});

gulp.task('start', ['default', 'watch'], function () {
    return gutil.log('App is run!');
});