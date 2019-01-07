﻿namespace TravelDream.Services.DataServices.Contracts
{
	using System.Linq;
	using System.Threading.Tasks;
	using Data.Models;
	using ViewModels.TripModels;

	public interface ITripsService
	{
		Task<int> Add(InputTripViewModel model);
		IQueryable<TripViewModel> GetAll();
		Trip GetById(int id);
	}
}
