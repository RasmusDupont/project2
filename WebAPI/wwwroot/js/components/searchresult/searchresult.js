define (['knockout','dataservice'], function(ko, ds){
    
        return function (params) {

            console.log(params.args());
            var searchString = params.args().searchString;
            var page;
            var pageSize;
            var result = ko.observableArray();
            var next = ko.observable();
            var prev = ko.observable();

            var prevPage = function(data,evnt){
                loadViewModel(searchString, page-1, pageSize);
            }
            var nextPage = function(data, event){
                loadViewModel(searchString, page+1, pageSize);
            }
            var loadViewModel = function(search, p, pSize){

                ds.searchPosts(search, p, pSize, function(data){
                    
                    if(data.prevLink === null){
                        prev(false);
                    }
                    else{
                        prev(data.prevLink);
                    }
    
                    if(data.nextLink === null){
                        next(false);
                    }
                    else{
                        next(data.prevLink);
                    }
    
                    result(data.content);

                    page = p;
                    pageSize = pSize;
                    
                    searchString = search;

                    next(data.nextLink);
                    prev(data.prevLink);
                    console.log(data);
                })

            }
            
            loadViewModel(searchString, 0, 10);

            return {
                result,
                prev,
                next,
                prevPage,
                nextPage
            };

        }
});
    