using Microsoft.EntityFrameworkCore;
using Npgsql;
using TravelControll.Repositories.Interfaces;

namespace TravelControll.Repositories
{
    public class HandlerError : IHandleError
    {
        public string handlerErroMesage(Exception exception)
        {
            if(exception is DbUpdateException Dbex)
            {
                if (Dbex.InnerException is PostgresException postgresException)
                {
                    string messageDetails = postgresException.MessageText;
                    return messageDetails;
                }
            }
            string messageEx = exception.Message;
            return messageEx;
        }
    }
}
