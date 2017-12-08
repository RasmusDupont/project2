define(['dataservice/postservice', 
        'dataservice/searchservice'], 
        function(ps, ss){

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

    function saveSearch(searchString, callback){

        ss.saveSearch(searchString, baseUrl, callback);
    }

    function getSearchHistory(page, pageSize, callback){

        ss.getSearchHistory(page, pageSize, baseUrl, callback);
    }
    
    return {
        getPost,
        putMark,
        getAnnotation,
        putAnnotation,
        searchPosts,
        getSearchedWords,
        saveSearch,
        getSearchHistory
    }
   
});