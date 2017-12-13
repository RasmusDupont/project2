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
        text: "../lib/text/text"
    }
});


require(['knockout'], function (ko) {

    ko.components.register("QA",
    {
        viewModel: { require: "components/QA/QA" },
        template: { require: "text!components/QA/QA.html" }
    });

    ko.components.register("searchresult",
    {
        viewModel: { require: "components/searchresult/searchresult" },
        template: { require: "text!components/searchresult/searchresult.html" }
    });
    ko.components.register("searchhistory",
    {
        viewModel: { require: "components/SearchHistory/SearchHistory" },
        template: { require: "text!components/SearchHistory/SearchHistory.html" }
    });

});

require(['knockout', 'bootstrap', 'dataservice'], (ko, bs, ds) => {

    var vm = (function () {

        var main = ko.observable("QA");
        var searchField = ko.observable();
        var clickNav = function(data, event){
            
            //change page
            main(event.target.id);
        }
        var clickSearch = function(data, event){
            searchField(document.getElementById("id_search").value);
            main("searchresult");
        }

        return {
            main,
            searchField,
            clickNav,
            clickSearch
        };

    })();



    ko.applyBindings(vm);

});