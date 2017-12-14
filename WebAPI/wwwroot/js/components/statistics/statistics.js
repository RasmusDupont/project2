define(['knockout', 'dataservice'], function (ko, ds) {

    return function(params) {

        var title = ko.observableArray();

        var graphObjects = [];
        var graphObjectsTwo = [];

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
            console.table(graphObjects);

            ds.getMostUsedTags(15, function (data) {
                for (var i = 0; i < data.length; i++) {
                    var array = [data[i]['name'], data[i]['searchCount']];
                    graphObjectsTwo.push(array);
                }
                console.table(graphObjectsTwo);
            }); 
        });

        google.charts.load('current', { packages: ['corechart', 'bar'] });
        google.charts.setOnLoadCallback(drawMostViewedPosts);
        google.charts.setOnLoadCallback(drawMostUsedTags);

        function drawMostViewedPosts() {
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
            var chart = new google.visualization.BarChart(document.getElementById('postGraph'));
            chart.draw(data, options);
        }

        function drawMostUsedTags() {
            graphObjectsTwo.unshift(['Tag', 'Frequency']);
            var data = google.visualization.arrayToDataTable(graphObjectsTwo);
            var options = {
                title: 'Most used tags',
                chartArea: { width: '50%' },
                hAxis: {
                    title: 'Frequency',
                    minValue: 0
                },
                vAxis: {
                    title: 'Tag'
                }
            };
            var chart = new google.visualization.BarChart(document.getElementById('tagGraph'));
            chart.draw(data, options);
        }

        return {
            title
        };

    }
});