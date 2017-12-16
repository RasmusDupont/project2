require.config({
    baseUrl: "js",
    shim: {

      bootstrap: {
        deps: ['jquery'],
        exports: 'Bootstrap'        
        },
      jqcloud: {
          deps: ['jquery']
      }

    },
    paths: {
        jqcloud: '../lib/jqcloud2/dist/jqcloud.min',
        jquery: "../lib/jquery/dist/jquery",
        knockout: "../lib/knockout/dist/knockout",
        bootstrap: "../lib/bootstrap/dist/js/bootstrap",
        charts: "../lib/charts/loader",
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
    ko.components.register("wordcloud",
        {
            viewModel: { require: "components/wordcloud/wordcloud" },
            template: { require: "text!components/wordcloud/wordcloud.html" }
        });
    ko.components.register("statistics",
        {
            viewModel: { require: "components/statistics/statistics" },
            template: { require: "text!components/statistics/statistics.html" }
        });
    ko.components.register("termnetwork",
        {
            viewModel: { require: "components/termnetwork/termnetwork" },
            template: { require: "text!components/termnetwork/termnetwork.html" }
        });

});

require(['knockout', 'jquery', 'jqcloud'], function (ko, $) {
    ko.bindingHandlers.cloud = {
        init: function(element, valueAccessor, allBindings, viewModel, bindingContext) {
            // This will be called when the binding is first applied to an element
            // Set up any initial state, event handlers, etc. here
            var words = allBindings.get('cloud').words;
            if(words && ko.isObservable(words)) {
                words.subscribe(function() {
                    $(element).jQCloud('update', ko.unwrap(words));
                });
            }
        },
        update: function(element, valueAccessor, allBindings, viewModel, bindingContext) {
            // This will be called once when the binding is first applied to an element,
            // and again whenever any observables/computeds that are accessed change
            // Update the DOM element based on the supplied values here.
            var words = ko.unwrap(allBindings.get('cloud').words) || [];
            $(element).jQCloud(words);
        }
    };
});

require(['knockout', 'bootstrap', 'dataservice'], (ko, bs, ds) => {

    var vm = (function () {

        var main = ko.observable("searchhistory");
        var componentParams = ko.observable();
        var searchField = ko.observable();
        var navBar = ko.observableArray([
            {id: "searchhistory", btnText: "Search History"}, 
            {id: "statistics", btnText: "Statistics"},
            {id: "termnetwork", btnText: "Term Network"}
        ]);

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
            
            changePage(data.id);
        }
        //clicking the search button
        var clickSearch = function(data, event){

            if(searchField() === "")
            {
                alert("Searchfield is empty");
            }
            else
            {
                ds.saveSearch(searchField(), function(d){});
                changePage("searchresult", {searchString: searchField()});
            }
            
        }

        //when user click a search in search histoory
        var clickHistorySearch = function(data, event){


            changePage("searchresult", {searchString: data.searchString});
        }

        //when user click a post in a search result
        var clickSearchResult = function(data, event){

            ds.putPostViewCount(data.id,function(d){});
            changePage("QA", {postId: data.id});
        }





        return {
            main,
            clickNav,
            clickSearch,
            changePage,
            clickHistorySearch,
            clickSearchResult,
            componentParams,
            navBar,
            searchField
        };

    })();

    ko.applyBindings(vm);

});