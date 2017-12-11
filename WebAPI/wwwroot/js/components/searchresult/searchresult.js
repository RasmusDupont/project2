define (['knockout','dataservice'], function(ko, ds){
    
        return function (params) {

            var result = ko.observableArray();
            var next = ko.observable();
            var prev = ko.observable();
            var choosePost = function(data, event){
                alert("data.id");
            }

            
            ds.searchPosts("sql database javascript", 1, 10, function(data){
                
                result(data.content);
                next(data.nextLink);
                prev(data.prevLink);
                console.log(data);
            })

            return {
                result,
                choosePost
            };

        }
});
    