define(['knockout', 'dataservice'], function (ko, ds) {

    return function (params) {

        var title = ko.observableArray();

        var graphObjects = [];

        ds.getMostViewedPosts(15, function(data) {

            for (var i = 0; i < data.length; i++) {
                var array = [];
                if (data[i]['title'] != null) {
                    array = [data[i]['title'], data[i]['viewCount']];
                } else {
                    array = ['No title', data[i]['viewCount']];
                }
                graphObjects.push(array);
            }
        });

        
        google.charts.load('current', { packages: ['corechart', 'bar'] });
        google.charts.setOnLoadCallback(drawBasic);

        function drawBasic() {
            graphObjects.unshift(['Post','Views']);
            var data = google.visualization.arrayToDataTable(graphObjects);

            var options = {
                title: 'Most viewed posts',
                chartArea: { width: '50%' },
                hAxis: {
                    title: 'Total Views',
                    minValue: 0
                },
                vAxis: {
                    title: 'Post'
                }
            };

            var chart = new google.visualization.BarChart(document.getElementById('chart_div'));

            chart.draw(data, options);
        }


        return {
            title
        };

    }
});