$.validator.addMethod("unlike",
	function (value, element, parameters) {
		var departureLocation = $("#departureLocationMenu").val();
		console.log(departureLocation)
		console.log(value)
		return value === departureLocation;

	});
$.validator.unobtrusive.adapters.add("unlike", [], function (options) {
	//options.rules.unlike = {};
	options.messages["unlike"] = options.message;
});