using ContactsManager.Core.Domain.IdentityEntities;
using Hesabdari_Core.DTO;
using Hesabdari_Core.DTO.Auth;
using Microsoft.AspNetCore.Identity;

namespace Hesabdari_Core.ServiceContracts;

public interface IAuthService
{
    Task SignupAsync(SignupRequest request);

    Task<LoginResult> LoginAsync(LoginRequest request);
    
    Task LogoutAsync();

    Task<LoginResult> RefreshTokenAsync(string refreshToken, string email);
    
    Task ChangePasswordAsync(ChangePasswordRequest request);

    Task ChangeUserNameAsync(string newUserName);

    Task UpdatePersonNameAsync(string newPersonName);
    
    Task<string> UpdateAvatarAsync(Stream avatarStream);

    Task DeleteUserAsync(string userId);
}