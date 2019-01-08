﻿namespace TravelDream.WebApp.Areas.Travels.Controllers
{
	using System;
	using System.Linq;
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Services.DataServices.Contracts;
	using Services.Utilities.Constants;
	using Services.ViewModels.TripModels;
	using WebApp.Controllers;

	[Area(GlobalConstants.TravelsAreaText)]
	[Authorize(Roles = GlobalConstants.AdministrationModerationAreaText)]
	public class TripsController : BaseController
	{
		private readonly ITripsService _tripsService;

		public TripsController(ITripsService tripsService)
		{
			this._tripsService = tripsService;
		}

		public IActionResult Add()
		{
			return this.View();
		}

		//TODO da napravq pri change na locationite ajax kato IsExist za proverka dali sa ednakvi
		//TODO atributi bez validaciq
		//TODO i za datite



		[HttpPost]
		public async Task<IActionResult> Add(InputTripViewModel model)
		{
			if (!this.ModelState.IsValid)
			{
				return this.View(model);
			}

			var result = await this._tripsService.Add(model);

			this.TempData[GlobalConstants.SuccessMessageKey] = "Trip" + GlobalConstants.SuccessfullyAddedMessage;
			return this.Redirect("Add");
		}

		[HttpPost]
		[AllowAnonymous]
		public IActionResult GetAll()
		{
			try
			{
				var draw = this.HttpContext.Request.Form["draw"].FirstOrDefault();
				// Skiping number of Rows count  
				var start = this.Request.Form["start"].FirstOrDefault();
				// Paging Length 10,20  
				var length = this.Request.Form["length"].FirstOrDefault();
				// Sort Column Name  
				var sortColumn = this.Request
					.Form["columns[" + this.Request.Form["order[0][column]"].FirstOrDefault() + "][name]"]
					.FirstOrDefault();
				// Sort Column Direction ( asc ,desc)  
				var sortColumnDirection = this.Request.Form["order[0][dir]"].FirstOrDefault();
				// Search Value from (Search box)  
				var searchValue = this.Request.Form["search[value]"].FirstOrDefault();

				//Paging Size (10,20,50,100)  
				int pageSize = length != null ? Convert.ToInt32(length) : 0;
				int skip = start != null ? Convert.ToInt32(start) : 0;
				int recordsTotal = 0;

				// Getting all Customer data  
				var trips = this._tripsService.GetAll();

				//Sorting  
				trips = this.Sort(trips,sortColumn,sortColumnDirection);

				//Search  
				if (!string.IsNullOrEmpty(searchValue))
				{
					trips = trips.Where(m => m.Departure == searchValue);
				}

				//total number of rows count   
				recordsTotal = trips.Count();
				//Paging   
				var data = trips.Skip(skip).Take(pageSize).ToList();
				//Returning Json Data  
				return this.Json(new { draw, recordsFiltered = recordsTotal, recordsTotal, data });

			}
			catch (Exception)
			{
				throw;
			}
		}

		public IActionResult Details(int id)
		{
			var trip = this._tripsService.Details(id);
			return this.View(trip);
		}

		private IQueryable<TripViewModel> Sort(IQueryable<TripViewModel> trips, string sortColumn,
			string sortColumnDirection)
		{
			if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
			{
				if (sortColumn == "id")
				{
					if (sortColumnDirection == "asc")
					{
						trips = trips.OrderBy(t => t.Id);
					}
					else
					{
						trips = trips.OrderBy(t => t.Id).Reverse();
					}
				}
				else if (sortColumn == "departure")
				{
					if (sortColumnDirection == "asc")
					{
						trips = trips.OrderBy(t => t.Departure);
					}
					else
					{
						trips = trips.OrderBy(t => t.Id).Reverse();
					}
				}
				else if (sortColumn == "destination")
				{
					if (sortColumnDirection == "asc")
					{
						trips = trips.OrderBy(t => t.Destination);
					}
					else
					{
						trips = trips.OrderBy(t => t.Id).Reverse();
					}
				}
				else if (sortColumn == "departureTime")
				{
					if (sortColumnDirection == "asc")
					{
						trips = trips.OrderBy(t => t.DepartureTime);
					}
					else
					{
						trips = trips.OrderBy(t => t.Id).Reverse();
					}
				}
				else if (sortColumn == "arrivalTime")
				{
					if (sortColumnDirection == "asc")
					{
						trips = trips.OrderBy(t => t.ArrivalTime);
					}
					else
					{
						trips = trips.OrderBy(t => t.Id).Reverse();
					}
				}

			}

			return trips;
		}
	}
}