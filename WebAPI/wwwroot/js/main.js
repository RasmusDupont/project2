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
        charts: "../lib/charts/loader",
        text: "../lib/text/text"
    }
});

require(['knockout'], function (ko) {
    ko.components.register("statistics",
        {
            viewModel: { require: "components/statistics/statistics" },
            template: { require: "text!components/statistics/statistics.html" }
        });
}); 

require(['knockout', 'bootstrap', 'dataservice', 'charts'], (ko, bs, ds) => {

    var vm = (function () {

        var out = ko.observable();
        var p = ko.observableArray();
        var statistics = ko.observable("statistics");


        return {
            out,
            p,
            statistics
        };

    })();

    console.log("component: " + ko.components.isRegistered('statistics')); 

    ds.putTagSearchCount("sql",
        function(data) {

            vm.out(JSON.stringify(data));
            console.log(vm.out());
        });

    console.log(ds);
    //vm.out((ds.getPost(19)));

    ko.applyBindings(vm);

});