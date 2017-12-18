define (['knockout','dataservice'], function(ko, ds){
    
        return function (params) {

            ko.observableArray();

            var x = ds.getTermNetwork("mongodb", function(data){
                alert("help me!");
                console.log(data);
                return data;
            });

            console.log(x);
        }
});
