const path = require('path');

module.exports = {
    entry: './wwwroot/js/src/site.js',
    output: {
        filename: 'site.js',
        path: path.resolve(__dirname, 'wwwroot/js/dist'),
    },
};