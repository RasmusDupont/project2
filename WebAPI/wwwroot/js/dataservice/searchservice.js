define(['jquery'], function($) {

    function saveSearch(searchString, baseURL, callback){

    console.log(searchString);

        $.ajax({
            url: baseURL + "/api/search",
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(searchString),
            success: function(data) {

                console.log("save search");
                callback(data);
            }
        });
    }

    function getSearchHistory(page, pageSize, baseURL, callback){

        $.ajax({
            url: baseURL + "/api/search/history/" + page + "/" + pageSize,
            type: "GET",
            dataType: "json",
            success: function(data) {

                console.log("get search history");
                callback(data);
            }
        });    
    }

    return {

        saveSearch,
        getSearchHistory
    }



});
