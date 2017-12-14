define (['knockout','dataservice'], function(ko, ds){

    return function (params) {
        var search = "block,region,sql";
        var title = ko.observable();
        var words = ko.observableArray();
        
        ds.getSearchedWords(search, function (data) {
            
            console.log(data);
            words(data);
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

        return {
            title,
            words
        };

    }
});
