function vizRender(graphvizText) {
    var viz = new Viz();

    //viz.renderSVGElement(graphvizText)
    viz.renderSVGElement(graphvizText)
        .then(function (element) {
            updateVizWithPanZoom(element);
        })
        .catch(error => {
            // Create a new Viz instance (@see Caveats page for more info)
            viz = new Viz();

            appendError(error);
        });

}

function vizRenderOn(graphvizText,target) {
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

function updateVizWithPanZoom(svg) {

    return updateVizWithPanZoomOn("#output");
    // var graph = document.querySelector("#output");
    //
    // cleanGraph(graph);
    //
    // svg.id = 'svg';
    // graph.appendChild(svg);
    //
    //
    // panZoom = svgPanZoom(svg, {
    //     zoomEnabled: true,
    //     controlIconsEnabled: true,
    //     fit: true,
    //     center: true,
    //     minZoom: 0.1
    // });
    //
    //
    // svg.addEventListener('paneresize', function (e) {
    //     panZoom.resize();
    // }, false);
    // window.addEventListener('resize', function (e) {
    //     panZoom.resize();
    // });
    //
    // return svg
}

function updateVizWithPanZoomOn(svg, target) {

    var graph = document.querySelector(target);

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


function cleanViz() {
    var graph = document.querySelector("#output");
    cleanGraph(graph);
}


function buildSvg() {
    import { instance } from "@viz-js/viz";

    instance().then(viz => {
        const svg = viz.renderSVGElement("digraph { a -> b }");

        document.getElementById("graph").appendChild(svg);
    });
}

