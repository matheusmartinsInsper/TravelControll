using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Drawing.Printing;
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
                }else if (Dbex.InnerException is ArgumentNullException nullexc)
                {
                    string messageNullex = nullexc.Message;
                    return messageNullex;
                }
            }
            string messageEx = exception.Message;
            return messageEx;
        }
    }
}
