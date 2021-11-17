using Business.Models;

namespace API.Token
{
    public interface ITokenService 
    {
        string GerarToken(Usuario usuario);
    }
}
