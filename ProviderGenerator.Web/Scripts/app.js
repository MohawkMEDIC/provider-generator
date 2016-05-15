/*
 * Update Range Clusters
 */
var lhins = {
    id: '#lhins',
    sliders: 14,
    moving_id: null,
    oldValue: [],
    radius: 100,
    margin: {
        top: 50,
        right: 50,
        bottom: 50,
        left: 50
    },
    color: d3.scale.category10(),
    pie: d3.layout.pie().value(function(d) {
        return d.value;
    }).sort(null),
    arc: d3.svg.arc().outerRadius(100).innerRadius(100 / 3)
};
createSlider(lhins);




var ProviderAgeDistribution = {
    id: '#ProviderAgeDistribution',
    sliders: 3,
    moving_id: null,
    oldValue: [],
    radius: 50,
    margin: {
        top: 50,
        right: 50,
        bottom: 50,
        left: 50
    },
    color: d3.scale.category10(),
    pie: d3.layout.pie().value(function(d) {
        return d.value;
    }).sort(null),
    arc: d3.svg.arc().outerRadius(50).innerRadius(50 / 3)
};
createSlider(ProviderAgeDistribution);




var ProviderGenderDistribution = {
    id: '#ProviderGenderDistribution',
    sliders: 3,
    moving_id: null,
    oldValue: [],
    radius: 50,
    margin: {
        top: 50,
        right: 50,
        bottom: 50,
        left: 50
    },
    color: d3.scale.category10(),
    pie: d3.layout.pie().value(function(d) {
        return d.value;
    }).sort(null),
    arc: d3.svg.arc().outerRadius(50).innerRadius(50 / 3)
};
createSlider(ProviderGenderDistribution);




var PatientAgeDistribution = {
    id: '#PatientAgeDistribution',
    sliders: 3,
    moving_id: null,
    oldValue: [],
    radius: 50,
    margin: {
        top: 50,
        right: 50,
        bottom: 50,
        left: 50
    },
    color: d3.scale.category10(),
    pie: d3.layout.pie().value(function(d) {
        return d.value;
    }).sort(null),
    arc: d3.svg.arc().outerRadius(50).innerRadius(50 / 3)
};
createSlider(PatientAgeDistribution);






var PatientGenderDistribution = {
    id: '#PatientGenderDistribution',
    sliders: 3,
    moving_id: null,
    oldValue: [],
    radius: 50,
    margin: {
        top: 50,
        right: 50,
        bottom: 50,
        left: 50
    },
    color: d3.scale.category10(),
    pie: d3.layout.pie().value(function(d) {
        return d.value;
    }).sort(null),
    arc: d3.svg.arc().outerRadius(50).innerRadius(50 / 3)
};
createSlider(PatientGenderDistribution);



/*
 * Update Single Range controls
 */
$("input.range-single").change(function(e) {
    $(this).next(".show-slider").html(this.value + "%");
    $(this).prev("input").attr('value', this.value);
});

$("input.range-single").each(function ()
{
	$(this).next(".show-slider").html("50%");
	$(this).prev("input").attr('value', 50);
});

$("#HNS").change(function ()
{
	if ($(this).is(":checked"))
	{
		$("#ClientRegistry").attr("checked", true);
		$("#ProviderRegistry").attr("checked", true);
	}
});

$("#OLIS").change(function ()
{
	if ($(this).is(":checked"))
	{
		$("#ClientRegistry").attr("checked", true);
		$("#ProviderRegistry").attr("checked", true);
	}
});