using HrApp_WebAPI.DTOs;
using System.Threading.Tasks;

namespace HrApp_WebAPI.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(UserLoginDto userLoginDto);
    }
}
