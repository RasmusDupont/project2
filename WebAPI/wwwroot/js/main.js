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

        var main = ko.observable("searchhistory");
        var componentParams = ko.observable();
        var searchField = ko.observable();

        //use when chaging main component
        var changePage = function(page, paramList){

            if(main() === page)
            {
                //reload component
                main.valueHasMutated();
            }
            else
            {
                //change component
                main(page);
            }
            
            componentParams(paramList);
        }
        //clicking link in navigation bar
        var clickNav = function(data, event){
            
            componentName = event.target.id;
            changePage(componentName);
        }
        //clicking the search button
        var clickSearch = function(data, event){
            searchField(document.getElementById("id_search").value);
            changePage("searchresult", {searchString: searchField()});
        }

        //when user click a search in search histoory
        var clickHistorySearch = function(data, event){

            changePage("searchresult", {searchString: data.searchString});
        }

        //when user click a post in a search result
        var clickSearchResult = function(data, event){
            changePage("QA", {postId: data.id})
        }

        return {
            main,
            clickNav,
            clickSearch,
            changePage,
            clickHistorySearch,
            clickSearchResult,
            componentParams
        };

    })();



    ko.applyBindings(vm);

});