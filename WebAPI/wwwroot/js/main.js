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