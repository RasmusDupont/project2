require.config({
    baseUrl: "js",
    paths: {
        jquery: "../lib/jquery/dist/jquery.js",
        knockout: "../lib/knockout/dist/knockout.js",
        bootstrap: "../lib/bootstrap/dist/js/bootstrap.js"
    }
});

require(['knockout', 'bootstrap', 'dataservice'], (ko, ds) => {

    var vm = (function () {

        var out = ko.observable();
        var p = ko.observableArray();


        return {
            out,
            p
        };

    })();

    ds.getSearchedWords("sql,boost",
        function(data) {

            vm.out(JSON.stringify(data));
            console.log(vm.out());
        });

    console.log(ds);
    //vm.out((ds.getPost(19)));

    ko.applyBindings(vm);

});