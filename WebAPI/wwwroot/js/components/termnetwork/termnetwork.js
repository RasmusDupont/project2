﻿define (['knockout','dataservice', 'd3js'], function(ko, ds){
    
        return function (params) {

            var inputField = ko.observable();
            var clickCreate = function(data, event){
                
                if(inputField() === "")
                {
                    alert("Searchfield is empty");
                }
                else
                {
                    createTermNetwork(inputField());
                }
                
                            
            }

            var createTermNetwork = function(word){

                ds.getTermNetwork(word, function (data) {
                    console.log(data);
    
                    var graph = data;
                    var width = 960, height = 500;
                    var svg = d3.select("body").append("svg").attr("width", width).attr("height", height);
                    var force = d3.layout.force()
                        .gravity(0.05)
                        .distance(100)
                        .charge(-200)
                        .size([width, height]);

                    var color = d3.scale.category20c();
    
                    (function () {
                        force
                            .nodes(graph.nodes)
                            .links(graph.links)
                            .start();
    
                        var link = svg.selectAll(".link")
                            .data(graph.links)
                            .enter().append("line")
                            .attr("class", "link")
                            .attr("stroke-width", function (d) { return Math.sqrt(d.value); });
    
                        var node = svg.selectAll(".node")
                            .data(graph.nodes)
                            .enter().append("g")
                            .attr("class", "node")
                            .call(force.drag);
    
                        node.append("circle")
                            .attr("r", function(d) { return 5; })
                            .style("fill", "red");
    
                        node.append("text")
                            .attr("dx", function (d) { return -(d.name.length * 3) })
                            .attr("dy", ".65em")
                            .text(function (d) { return d.name });
    
                        force.on("tick", function () {
                            link.attr("x1", function (d) { return d.source.x; })
                                .attr("y1", function (d) { return d.source.y; })
                                .attr("x2", function (d) { return d.target.x; })
                                .attr("y2", function (d) { return d.target.y; });
                            node.attr("transform", function (d) { return "translate(" + d.x + "," + d.y + ")"; });
                        });
                    })();
                });

            }

            return {
                clickCreate,
                inputField

            }
            
        }
});
