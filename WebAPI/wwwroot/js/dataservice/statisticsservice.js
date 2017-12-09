define(['jquery'], function($) {

    function getMostViewedPosts(num, baseURL, callback){

        $.getJSON(baseURL + "/api/statistics/posts/mostviewed/" + num, function(data) {

            callback(data);
        })
    }

    function getMostUsedTags(num, baseURL, callback){

        $.getJSON(baseURL + "/api/statistics/tags/mostused/" + num, function(data) {

            callback(data);
        })
    }

    function putPostViewCount(id, baseURL, callback){

        $.ajax({
            url: baseURL + "/api/statistics/post/viewcount/" + id,
            type: "PUT",
            dataType: "json",
            data: "",
            success: function(data) {

                callback(data);
            }
        });
    }

    function putTagSearchCount(tag, baseURL, callback){

        $.ajax({
            url: baseURL + "/api/statistics/tag/searchcount/" + tag,
            type: "PUT",
            dataType: "json",
            data: "",
            success: function(data) {

                callback(data);
            }
        });
    }

    return {

        getMostViewedPosts,
        getMostUsedTags,
        putPostViewCount,
        putTagSearchCount
    }

});