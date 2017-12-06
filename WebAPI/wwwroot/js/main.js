require.config({
    baseUrl: "js",
    paths: {
        jquery: "../lib/jquery/dist/jquery.min",
        knockout: "../lib/knockout/dist/knockout",
        text: "../lib/text/text"
    }
});

require(['jquery', 'knockout'], ($, ko) => {

    var vm = (function () {


        var out = ko.observable();
        var p = ko.observableArray();


        return {
            out,
            p
        };

    })();


    $.getJSON("http://localhost:5001/api/posts", function(data) {

        vm.out(JSON.stringify(data.items));
        vm.p(data.items);
        console.log(vm.p()[0].title);

    });

    ko.applyBindings(vm);

});