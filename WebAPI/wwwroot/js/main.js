require.config({
    baseUrl: "js",
    paths: {
        jquery: "../lib/jquery/dist/jquery.min",
        knockout: "../lib/knockout/dist/knockout",
        text: "../lib/text/text"
    }
});

require(['knockout', 'dataservice'], (ko, ds) => {

    var vm = (function () {

        var out = ko.observable();
        var p = ko.observableArray();


        return {
            out,
            p
        };

    })();

    ds.getSearchedWords("sql,boost", function(data){

        vm.out(JSON.stringify(data));
        console.log(vm.out());
    })

    console.log(ds);
    //vm.out((ds.getPost(19)));

    ko.applyBindings(vm);

});