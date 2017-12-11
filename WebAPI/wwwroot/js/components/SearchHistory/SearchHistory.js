define (['knockout','dataservice'], function(ko, ds){

    return function (params) {

        var title = ko.observable();
        var qaPosts = ko.observableArray();
        var clickMark = function(data, event){

            if (data.markedPost() === true)
            {
                data.markedPost(false);
            }
            else 
            {
                data.markedPost(true);
            }
            ds.putMark(data.id,function(d){});
       
        }
        var saveAnnotation = function(data, event){

            ds.putAnnotation(data.id, data.annotation(), function(d){});

        }

        // get posts
        ds.getPost(427217,
            function(data) {

 
                for(i = 0; i < data.length; i++)
                {
                    if(data[0].acceptedAnswerId === data[i].id)
                    {
                        data[i].acceptedAnswer = ko.observable(true);
                    }
                    else
                    {
                        data[i].acceptedAnswer = ko.observable(false);
                    }
                }


                //make markedPost observable
                for(i = 0;i < data.length;i++){

                    data[i].markedPost = ko.observable(data[i].markedPost);
                    data[i].annotation = ko.observable(data[i].annotation);

                }

                console.log(data);

                qaPosts(data);
                title(data[0].title);


            });

        return {
            title,
            qaPosts,
            clickMark,
            saveAnnotation
        };

    }
});
