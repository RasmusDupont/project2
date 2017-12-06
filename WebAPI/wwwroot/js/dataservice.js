define(['jquery'], ($) => {

    function getPost(postId){

            return $.getJSON("http://localhost:5001/api/post/19").then(function(data) {

                //JSON.stringify(data);

                console.log(data);
                return data;

            })
       }
    
    return{
        getPost
    }
   
});