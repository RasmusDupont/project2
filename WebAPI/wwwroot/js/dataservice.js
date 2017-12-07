define(['dataservice/postservice'], function(ps){

    var baseUrl = "http://localhost:5001";

    function getPost(postId, callback){

        ps.getPost(postId, baseUrl, callback);
    }

    function putMark(postId, callback){

        ps.putMark(postId, baseUrl, callback);
    }

    function getAnnotation(postId, callback){

        ps.getAnnotation(postId, baseUrl, callback);
    }

    function putAnnotation(postId, annotation, callback){

        ps.putAnnotation(postId, baseUrl, baseUrl, callback);
    }

    function searchPosts(search, page, pageSize, callback){

        ps.searchPosts(search, page, pageSize, baseUrl, callback);
    }

    function getSearchedWords(search, callback){

        ps.getSearchedWords(search, baseUrl, callback);
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