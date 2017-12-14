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

});

require(['knockout'], function (ko) {
    ko.components.register("SearchHistory",
        {
            viewModel: { require: "components/SearchHistory/SearchHistory" },
            template: { require: "text!components/SearchHistory/SearchHistory.html" }
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

        var out = ko.observable();
        var p = ko.observableArray();
        var QA = ko.observable("wordcloud");



        return {
            out,
            p,
            QA
        };

    })();

    console.log("QA component: " + ko.components.isRegistered('wordcloud'));

    ds.putTagSearchCount("sql",
        function(data) {

            vm.out(JSON.stringify(data));
            console.log(vm.out());
        });

    console.log(ds);
    //vm.out((ds.getPost(19)));

    ko.applyBindings(vm);

});