define (['knockout','dataservice'], function(ko, ds){

    return function (params) {

        var page;
        var pageSize;
        var result = ko.observableArray();
        var next = ko.observable();
        var prev = ko.observable();
        var chooseSearch = function(data, event){
            
            alert("go to: " + data.searchString);
        }
        var prevPage = function(data,evnt){
            loadViewModel(page-1, pageSize);
        }
        var nextPage = function(data, event){
            loadViewModel(page+1, pageSize);
        }

        var loadViewModel = function(p, pSize){

            ds.getSearchHistory(p, pSize, function(data){
                
                            result(data.content);
                            console.log(data);
                
                
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
                
                            page = p;
                            pageSize = pSize;
                
                            next(data.nextLink);
                            prev(data.prevLink);
                
                        });

        }

        loadViewModel(0, 10);



        return {
            
            result,
            chooseSearch,
            prev,
            next,
            prevPage,
            nextPage
            
        };

    }
});
