define (['knockout','dataservice'], function(ko, ds){

    return function (params) {

        var title = ko.observable();
        var qaPosts = ko.observableArray();
        var clickMark = function(data, event){

            for(i = 0; i < qaPosts().length; i++)
            {
                if(qaPosts()[i].id === data.id){
                    if (qaPosts()[i].markedPost() === true)
                    {
                        qaPosts()[i].markedPost(false)
                    }
                    else 
                    {
                        qaPosts()[i].markedPost(true);
                    }
                    ds.putMark(data.id,function(d){});
                }
            }
                        
        }

        // get posts
        ds.getPost(19,
            function(data) {

                //make markedPost observable
                for(i = 0;i < data.length;i++){

                    data[i].markedPost = ko.observable(data[i].markedPost);
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
