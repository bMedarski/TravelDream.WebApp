$(document).ready(function() {
	$("#trips").DataTable({
		"processing": false, // for show progress bar
		"serverSide": true, // for process server side
		"filter": true, // this is for disable filter (search box)
		"orderMulti": false, // for disable multiple column at once
		"ajax": {
			"url": "/@GlobalConstants.TravelsAreaText/Trips/GetAll",
			"type": "POST",
			"datatype": "json"
		},
		"columnDefs":
		[
			{
				"targets": [0],
				"visible": false,
				"searchable": false
			}
		],
		"columns": [
			{ "data": "id", "name": "id", "autoWidth": true },
			{ "data": "departure", "name": "departure", "autoWidth": true },
			{ "data": "destination", "name": "destination", "autoWidth": true },
			{ "data": "departureTime", "name": "departureTime", "autoWidth": true },
			{ "data": "arrivalTime", "name": "arrivalTime", "autoWidth": true },
			//{
			//	"render": function(data, type, full, meta) {
			//		return '<td><a class="btn bg-bet" href="/DemoGrid/Edit/' + full.id + '">Buy</a></td>';
			//	}
			//},
			//{
			//	data: null,
			//	render: function(data, type, row) {
			//		return "<a href='#' class='btn btn-danger' onclick=DeleteData('" +
			//			row.CustomerID +
			//			"'); >Delete</a>";
			//	}
			//},
		]

	});
});