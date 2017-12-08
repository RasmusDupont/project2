require.config({
    baseUrl: "js",
    paths: {
        jquery: "../lib/jquery/dist/jquery",
        knockout: "../lib/knockout/dist/knockout",
        bootstrap: "../lib/bootstrap/dist/js/bootstrap"
    }
});

require(['knockout', 'bootstrap', 'dataservice'], (ko, bs, ds) => {

    var vm = (function () {

        var out = ko.observable();
        var p = ko.observableArray();


        return {
            out,
            p
        };

    })();

    ds.getSearchHistory(1,3,
        function(data) {

            vm.out(JSON.stringify(data));
            console.log(vm.out());
        });

    console.log(ds);
    //vm.out((ds.getPost(19)));

    ko.applyBindings(vm);

});