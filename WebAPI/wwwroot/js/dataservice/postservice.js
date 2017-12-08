define(['jquery'], function($) {

    //get a post with related qestion and answers
    function getPost(postId, baseURL, callback){

        $.getJSON(baseURL + "/api/post/" + postId, function(data) {

            callback(data);
        })
    }

    function putMark(postId, baseURL, callback){

        
        $.ajax({
            url: baseURL + "/api/post/mark/" + postId,
            type: "PUT",
            dataType: "json",
            data: "",
            success: function(data) {
                console.log("Post marked");

                //returns true or falls
                callback(data);
            }
        });
    }


    function getAnnotation(postId, baseURL, callback){

        $.ajax({
            url: baseURL + "/api/post/annotation/" + postId,
            type: "GET",
            dataType: "text",
            data: "",
            success: function(data) {

                console.log("got annotation");
                callback(data);
            }
        });

    }

    function putAnnotation(postId, annotation, baseURL, callback){
        
        $.ajax({
            url: baseURL + "/api/post/annotation/" + postId,
            type: "PUT",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(annotation),
            success: function(data) {

                console.log("putAnnotation");
                callback(data);
            }
        });
    }

    function searchPosts(search, page, pageSize, baseURL, callback){

        $.ajax({
            url: baseURL + "/api/post/search/" + search + "/" + page + "/" + pageSize,
            type: "GET",
            dataType: "json",
            success: function(data) {

                console.log("search posts");
                callback(data);
            }
        });
    }


    function getSearchedWords(search, baseURL, callback){

         $.ajax({
            url: baseURL + "/api/post/search/words/" + search,
            type: "GET",
            dataType: "json",
            success: function(data) {

                console.log("get searched words");
                callback(data);
            }
        });
    }
    
    return {
        getPost,
        putMark,
        getAnnotation,
        putAnnotation,
        searchPosts,
        getSearchedWords
    }
   
});