define (['knockout','dataservice'], function(ko, ds){
    
        return function (params) {

            
            
            ds.getTermNetwork("sql", function(data){
                alert("help me!");
                console.log(data);

            });
        }
});
