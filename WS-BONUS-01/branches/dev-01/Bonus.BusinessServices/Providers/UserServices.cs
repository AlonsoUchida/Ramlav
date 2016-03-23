using Bonus.BusinessServices.Interfaces;
using Bonus.DataModel.UnitOfWork;

namespace Bonus.BusinessServices.Providers
{
    /// <summary>
    /// Offers services for user specific operations
    /// </summary>
    public class UserServices : IUserServices
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public UserServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Public method to authenticate user by user name and password.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int Authenticate(string userName, string password)
        {
            string msgError = "";
            WsBonusLogin.wslogusugxSoapPortClient ws = new WsBonusLogin.wslogusugxSoapPortClient();
            int codError = ws.Execute(userName, password, out msgError);
            /*
            0: Éxito
            1: Usuario en blanco
            2: Clave en blanco
            3: Usuario no existe
            4: Usuario no pertenece al grupo autorizado
            5: Clave incorrecta
            */
            if (codError == 0) {
                return 1;
            }
            return 0;
        }
    }
}

