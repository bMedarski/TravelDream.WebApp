namespace TravelDream.Services.DataServices.Contracts
{
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Identity;
	using ViewModels.UserModels;

	public interface IUsersService
	{
		Task<IdentityResult> CreateUser(InputRegisterViewModel model);
		//IList<AdminPanelUsersViewModel> AdminPanelUsers();
		void LogoutUser();
		//void Demote(string id);
		//void Promote(string id);
	}
}
