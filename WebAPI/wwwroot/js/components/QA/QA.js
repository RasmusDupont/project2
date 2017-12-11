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

            for(i = 0; i < qaPosts().length; i++)
            {
                if(qaPosts()[i].id === data.id){
                    console.log(qaPosts()[i]);
                }
            }
            console.log(data);
        }

        var edited;

        // get posts
        ds.getPost(19,
            function(data) {

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
