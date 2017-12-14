define (['knockout','dataservice'], function(ko, ds){

    return function (params) {
        
        console.log(params.words())
        var words = ko.observableArray(params.words());
        
        

        return {
            words
        };

    }
});
