define (['knockout','dataservice'], function(ko, ds){

    return function (params) {
        var search = "block,region,sql";
        var title = ko.observable();
        var words = ko.observableArray();
        
        ds.getSearchedWords(search, function (data) {
            words(data.content);
        });   

       

        return {
            title,
            words,
            wordlist
        };

    }
});
