require.config({
    baseUrl: "js",
    shim: {
        bootstrap: {
            deps: ['jquery'],
            exports: 'Bootstrap'
        }
    },
    paths: {
        jquery: "../lib/jquery/dist/jquery",
        knockout: "../lib/knockout/dist/knockout",
        bootstrap: "../lib/bootstrap/dist/js/bootstrap",
        charts: "../lib/charts/loader"
    }
});

require(['knockout', 'bootstrap', 'dataservice', 'charts'], (ko, bs, ds) => {

    var vm = (function () {

        var out = ko.observable();
        var p = ko.observableArray();


        return {
            out,
            p
        };

    })();

    ds.putTagSearchCount("sql",
        function(data) {

            vm.out(JSON.stringify(data));
            console.log(vm.out());
        });

    console.log(ds);
    //vm.out((ds.getPost(19)));

    ko.applyBindings(vm);

});