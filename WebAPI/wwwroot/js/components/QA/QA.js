define (['knockout','dataservice'], function(ko, ds){

    return function (params) {

        var title = ko.observableArray();
        var qaPosts = ko.observableArray();
        var clickMark = function(data, event){

            for(i = 0; i < qaPosts().length; i++)
            {
                if(qaPosts()[i].id === data.id){
                    if (qaPosts()[i].markedPost() === "glyphicon glyphicon-star")
                    {
                        qaPosts()[i].markedPost("glyphicon glyphicon-star-empty")
                    }
                    else 
                    {
                        qaPosts()[i].markedPost("glyphicon glyphicon-star");
                    }
                    ds.putMark(data.id,function(d){});
                }
            }
                        
        }

        // get posts
        ds.getPost(19,
            function(data) {

                //modify mark to fit viewmodel
                for(i = 0;i < data.length;i++){


                    if(data[i].markedPost === true){

                        data[i].markedPost = ko.observable("glyphicon glyphicon-star");
                    }
                    else{

                        data[i].markedPost = ko.observable("glyphicon glyphicon-star-empty");
                    }
                   
                }

                console.log(data);

                qaPosts(data);
                title(data[0].title);


            });

        return {
            title,
            qaPosts,
            clickMark
        };

    }
});
