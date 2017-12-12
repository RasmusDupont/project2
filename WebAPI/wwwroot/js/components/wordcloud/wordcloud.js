define (['knockout','dataservice'], function(ko, ds){

    return function (params) {
        var search = "boots,region,sql";
        var title = ko.observable();
        var words = ko.observableArray();
        
        ds.getSearchWords(search, function (data) {
            words(data.content);
        });   

       

        return {
            title,
            words,
            wordlist
        };

    }
});
