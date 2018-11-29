// Note this only includes basic configuration for development mode.
// For a more comprehensive configuration check:
// https://github.com/fable-compiler/webpack-config-template

var path = require("path");

module.exports = {
    entry: "./src/Fable.ReactTransitionGroup.Sample.fsproj",
    output: {
        path: path.join(__dirname, "./docs"),
        filename: "[name].js"
    },
    devServer: {
        contentBase: "./docs",
        port: 8080
    },
    optimization: {
        splitChunks: {
            cacheGroups: {
                commons: {
                    test: /node_modules/,
                    name: "vendors",
                    chunks: "all"
                }
            }
        }
    },
    module: {
        rules: [{
            test: /\.fs(x|proj)?$/,
            use: "fable-loader"
        }, {
            test: /\.css$/,
            use: ["style-loader", "css-loader"]
        }]
    }
}