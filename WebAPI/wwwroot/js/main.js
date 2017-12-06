require.config({
    baseUrl: "js",
    paths: {
        jquery: "../lib/jquery/dist/jquery.min",
        knockout: "../lib/knockout/dist/knockout",
        text: "../lib/text/text"
    }
});

require(['jquery', 'knockout', 'dataservice'], ($, ko, ds) => {

    var vm = (function () {

        var out = ko.observable();
        var p = ko.observableArray();


        return {
            out,
            p
        };

    })();

    console.log(ds);
    vm.out((ds.getPost(19)));
    console.log(vm.out());


    ko.applyBindings(vm);

});