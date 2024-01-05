using Microsoft.EntityFrameworkCore;
using TravelControll.Models;

namespace TravelControll.Repositories.Interfaces
{
    public interface IHandleError
    {
        public  string handlerErroMesage(Exception ex);   
    }
}
