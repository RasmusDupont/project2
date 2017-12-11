define (['knockout','dataservice'], function(ko, ds){

    return function (params) {

        
        var searchHistory = ko.observableArray();


        searchHistory = ds.getSearchHistory();



        return {
            
            searchHistory
            
        };

    }
});
