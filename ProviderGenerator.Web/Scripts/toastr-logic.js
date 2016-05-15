$(document).ready(function ()
{
	if ($('#success').val())
	{
		displayMessage($('#success').val(), 'success');
	}
	if ($('#info').val())
	{
		displayMessage($('#info').val(), 'info');
	}
	if ($('#warning').val())
	{
		displayMessage($('#warning').val(), 'warning');
	}
	if ($('#error').val())
	{
		displayMessage($('#error').val(), 'error');
	}
});

var displayMessage = function (message, msgType)
{
	toastr.options = {
		"closeButton": false,
		"debug": true,
		"positionClass": "toast-top-right",
		"onClick": null,
		"showDuration": "300",
		"hideDuration": "1000",
		"timeOut": "8000",
		"extendedTimeOut": "1000",
		"showEasing": "swing",
		"hideEasing": "linear",
		"showMethod": "fadeIn",
		"hideMethod": "fadeOut"
	};

	toastr[msgType](message);
};