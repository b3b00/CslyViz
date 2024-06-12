function vizRender(graphvizText, target = "output") {
    var viz = new Viz();

    //viz.renderSVGElement(graphvizText)
    viz.renderSVGElement(graphvizText)
        .then(function (element) {
            updateVizWithPanZoom(element, target);
        })
        .catch(error => {
            // Create a new Viz instance (@see Caveats page for more info)
            viz = new Viz();

            appendError(error);
        });

}



function cleanGraph(graph) {

    var oldError = graph.querySelector("error");
    if (oldError) {
        graph.removeChild(oldError);
    }

    var oldSvg = graph.querySelector("svg");
    if (oldSvg) {
        graph.removeChild(oldSvg);
    }

}

function updateVizWithPanZoom(svg, target) {

    var graph = document.querySelector("#"+target);
    if (graph) {

        cleanGraph(graph);

        svg.id = 'svg';
        graph.appendChild(svg);


        panZoom = svgPanZoom(svg, {
            zoomEnabled: true,
            controlIconsEnabled: true,
            fit: true,
            center: true,
            minZoom: 0.1
        });


        svg.addEventListener('paneresize', function (e) {
            panZoom.resize();
        }, false);
        window.addEventListener('resize', function (e) {
            panZoom.resize();
        });

        return svg
    }
}


function cleanViz(target) {
    var graph = document.querySelector("#"+target);
    if (graph) {
        cleanGraph(graph);
    }
}


