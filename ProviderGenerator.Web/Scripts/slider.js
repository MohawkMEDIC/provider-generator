/*
 * Slider JS library
 * Uses D3.js to manipulate and draw Pie charts based on an HTML Range slider in real time.
 */
function createSlider(config) {
    d3.selectAll(config.id + ' #rangebox .range').each(function() {
        var def = parseInt(100 / config.sliders);
        this.value = def;
        config.oldValue[d3.select(this).attr('data-id')] = this.value;
    });

    equalize(config);
    showValues(config);
    pieChart(config);


    // slider event
    d3.selectAll(config.id + ' .range').on('input', function() {
        this.value = parseInt(this.value);
        if (this.value < 0) this.value = 0;
        else if (this.value > 100) this.value = 100;

        var id = d3.select(this).attr('data-id');
        config.moving_id = id;

        var old_value = config.oldValue[config.moving_id];
        var new_value = this.value;
        var delta = (new_value - old_value) / (config.sliders - 1);

        d3.selectAll(config.id + ' #rangebox .range').each(function() {
            var r_id = d3.select(this).attr('data-id');
            var r_val = this.value;
            if (r_id != config.moving_id && r_val > delta) {
                var equalized = parseInt(r_val - delta);
                this.value = equalized;
                config.oldValue[r_id] = this.value;
            }
        });

        config.oldValue[config.moving_id] = new_value;

        equalize(config);
        showValues(config);
        updatePieChart(config);

    });
}


// get JSON data from sliders
function getData(config) {
    var json = [];
    d3.selectAll(config.id + ' #rangebox .range').each(function() {

        json.push({
            label: d3.select(this).attr('data-id'),
            value: this.value
        });
    });
    return json;
}

// compute total percentage from sliders
function getTotal(config) {
    var total = 0;
    d3.selectAll(config.id + ' #rangebox .range').each(function() {
        total = total + parseInt(this.value);
    });
    return total;
}

// equalize the sliders (decimal delta)
function equalize(config) {
    var remaining = 100 - getTotal(config);

    if (remaining != 0) {
        var to_eq = null;
        var min = null;
        var max = null;
        var min_value = 9999;
        var max_value = 0;

        d3.selectAll(config.id + ' #rangebox .range').each(function() {
            var id = d3.select(this).attr('data-id');

            if (id != config.moving_id) {
                if (parseInt(this.value) > parseInt(max_value)) {
                    max_value = this.value;
                    max = this;
                }
                if (parseInt(this.value) < parseInt(min_value)) {
                    min_value = this.value;
                    min = this;
                }
            }
        });

        if (remaining > 0) to_eq = min;
        else to_eq = max;

        if (to_eq) {
            if (remaining > 0) {
                to_eq.value = parseInt(to_eq.value) + 1;
                remaining = remaining - 1;
            } else {
                to_eq.value = parseInt(to_eq.value) - 1;
                remaining = remaining + 1;
            }
            config.oldValue[d3.select(to_eq).attr('data-id')] = to_eq.value;

            if (remaining != 0) equalize(config);
        }
    }
}

// show slider value
function showValues(config) {
    d3.selectAll(config.id + ' #rangebox .range').each(function() {
        var perct = this.value + '%';
        d3.select(this).attr('data-val', perct);
        d3.select(this.nextSibling).html(perct);
        d3.select(this.previousSibling).attr('value', this.value);
    });
}

// draw pie chart
function pieChart(config) {

    var json = getData(config);
    d3.select(config.id + ' #pie svg').remove();

    var canvasWidth = config.radius * 2 + config.margin.left + config.margin.right,
        canvasHeight = config.radius * 2 + config.margin.top + config.margin.bottom;

    // svg canvas
    var svg = d3.select(config.id + ' #pie')
        .append("svg:svg")
        .attr("width", canvasWidth)
        .attr("height", canvasHeight)
        .append("svg:g")
        .attr("transform", "translate(" + canvasWidth / 2 + "," + canvasHeight / 2 + ")")

    // create the classes under the transform
    d3.select(config.id + ' g')
        .append("g")
        .attr("class", "slices");

    d3.select(config.id + ' g')
        .append("g")
        .attr("class", "labels");

    d3.select(config.id + ' g')
        .append("g")
        .attr("class", "lines");

    d3.select(config.id + ' g')
        .append("g")
        .attr("class", "legend");

    // group all ther paths into the slices class
    var arcPaths = svg.select(".slices").selectAll("path").data(config.pie(getData(config)))

    // render the slices
    arcPaths.enter()
        .append('svg:path')
        .attr("class", "slice")
        .attr("fill", function(d, i) {
            return config.color(i);
        })

        .attr("d", config.arc)
        .each(function(d) {
            this._current = d;
        })
        .append('title')
        .text(function(d, i) {
            return json[i].value + '%';
        });

    // group all ther paths into the slices class
    var arcLabels = svg.select(".labels").selectAll("label").data(config.pie(getData(config)))

    // render the labels
    arcLabels.enter()
        .append("svg:text")
        .attr("class", "label")
        .attr("transform", function(d) {
            return "translate(" + config.arc.centroid(d) + ")";
        })
        .attr("text-anchor", "middle")
        .text(function(d, i) {
            if (json[i].value > 1) return json[i].label;
            else return null;
        });
}

// update pie chart
function updatePieChart(config) {
    updateArcs(config);
    updateLabels(config);
    updateLabelLines(config);

}

// update the slices of the pie chart
function updateArcs(config) {
    var json = getData(config);

    d3.selectAll(config.id + ' #pie path title')
        .text(function(d, i) {
            return json[i].value + '%';
        });

    d3.selectAll(config.id + ' #pie path')
        .data(config.pie(json))
        .transition()
        .duration(100)
        .attrTween('d', function(a) {
            var i = d3.interpolate(this._current, a);
            this._current = i(0);
            return function(t) {
                return config.arc(i(t));
            };
        });
}

/* ------- TEXT LABELS -------*/
// update the labels of the pie chart
function updateLabels(config) {
    var labelr = config.radius + 40 // radius for label anchor
    d3.selectAll(config.id + ' #pie text')
        .data(config.pie(getData(config)))
        .transition()
        .duration(120)

        .attr("transform", function(d) {
            var c = config.arc.centroid(d),
                x = c[0],
                y = c[1],
            // pythagorean theorem for hypotenuse
                h = Math.sqrt(x * x + y * y);
            return "translate(" + (x / h * labelr) + ',' +
                (y / h * labelr) + ")";
        })
        .attr("dy", ".35em")
        .attr("text-anchor", function(d) {
            // are we past the center?
            return (d.endAngle + d.startAngle) / 2 > Math.PI ?
                "end" : "start";
        })

        //.text(function(d, i) { return d.value.toFixed(2); });
        .text(function(d, i) {
            if (getData(config)[i].value > 0) return getData(config)[i].label;
            else return null;
        });
}

/* ------- SLICE TO TEXT POLYLINES -------*/
function midAngle(d) {
    return d.startAngle + (d.endAngle - d.startAngle) / 2;
}

function updateLabelLines(config) {

    var outerArc = d3.svg.arc()
        .innerRadius(config.radius +50)
        .outerRadius(config.radius * .95);

    var polyline = d3.select(config.id + ' .lines').selectAll("polyline")
        .data(config.pie(getData(config)));

    polyline.enter().append("polyline")
    polyline.transition()
        .duration(100)
        .attrTween("points", function(d) {
            this._current = this._current || d;
            var interpolate = d3.interpolate(this._current, d);
            this._current = interpolate(0);
            return function(t) {
                var d2 = interpolate(t);
                var pos = 0;
                return [config.arc.centroid(d2), outerArc.centroid(d2)];
            };
        });
    polyline.exit().remove();
}