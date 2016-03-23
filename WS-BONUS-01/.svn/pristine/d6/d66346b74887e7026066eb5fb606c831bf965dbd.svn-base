using Bonus.BusinessEntities.DTO;
using Bonus.BusinessServices.Interfaces;
using System;
using System.Configuration;
using System.Globalization;

namespace Bonus.BusinessServices.Providers
{
    public class TokenServices : ITokenServices
    {
        #region Public member methods.

        /// <summary>
        ///  Function to generate unique token with expiry against the provided userId.
        ///  Also add a record in database for generated token.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public TokenEntity GenerateToken(int userId)
        {
            string token = Guid.NewGuid().ToString();
            DateTime issuedOn = DateTime.Now;
            DateTime expiredOn = DateTime.Now.AddSeconds(
                                              Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));
            string msgError = "";
           
            WsBonusInsertarToken.wsinstokenSoapPortClient ws = new WsBonusInsertarToken.wsinstokenSoapPortClient();
            short respuesta = ws.Execute(userId.ToString(), token, issuedOn, expiredOn, out msgError);

            if(respuesta == 0)
            { 
                var tokenModel = new TokenEntity()
                {
                    UserId = userId,
                    IssuedOn = issuedOn,
                    ExpiresOn = expiredOn,
                    AuthToken = token
                };

                return tokenModel;
            }
            return null;
        }

        /// <summary>
        /// Method to validate token against expiry and existence in database.
        /// </summary>
        /// <param name="tokenId"></param>
        /// <returns></returns>
        public bool ValidateToken(string tokenId)
        {
            WsBonusObtenerToken.wsobttokenSoapPortClient ws = new WsBonusObtenerToken.wsobttokenSoapPortClient();
            WsBonusActualizarToken.wsacttokenSoapPortClient wsActualizar = new WsBonusActualizarToken.wsacttokenSoapPortClient();
            TokenEntity token = new TokenEntity();
            string userId, msgError;
            int _tokenID;
            string issuedOn;
            string expiredOn;

            short respuesta = ws.Execute(tokenId, DateTime.Now, out msgError, out _tokenID, out userId, out issuedOn, out expiredOn);

            if (respuesta == 0)
            {
                TokenEntity tokenEntity = new TokenEntity();
                tokenEntity.AuthToken = tokenId;
                tokenEntity.TokenId = _tokenID;
                tokenEntity.UserId = int.Parse(userId);

                var formats = new[] {
                  "yyyy.MM.dd HH:mm:ss",
                  "yyyy-MM-dd HH:mm:ss",
                  "yyyy/MM/dd HH:mm:ss",
                  "yyyy.MM.dd hh:mm:ss",
                  "yyyy-MM-dd hh:mm:ss",
                  "yyyy/MM/dd hh:mm:ss",
                  "dd.MM.yyyy HH:mm:ss",
                  "dd-MM-yyyy HH:mm:ss",
                  "dd/MM/yyyy HH:mm:ss",
                  "dd.MM.yyyy hh:mm:ss",
                  "dd-MM-yyyy hh:mm:ss",
                  "dd/MM/yyyy hh:mm:ss"
                };

                tokenEntity.IssuedOn = DateTime.ParseExact(issuedOn, formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
                tokenEntity.ExpiresOn = DateTime.ParseExact(expiredOn, formats, CultureInfo.InvariantCulture, DateTimeStyles.None);

                if (tokenEntity != null && !(DateTime.Now > tokenEntity.ExpiresOn))
                {
                    tokenEntity.ExpiresOn = tokenEntity.ExpiresOn.AddSeconds(
                                                  Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));

                    short respuestaActualizar = wsActualizar.Execute(tokenEntity.AuthToken, tokenEntity.ExpiresOn, out msgError);
                    if(respuestaActualizar==0)
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Method to kill the provided token id.
        /// </summary>
        /// <param name="tokenId">true for successful delete</param>
        public bool Kill(string tokenId)
        {
            /*
            Mapeo de errores:
            0: Éxito
            1: AuthToken en blanco
            2: No se encontró AuthToken ingresado
            */
            WsBonusEliminarToken.wselitokenSoapPortClient ws = new WsBonusEliminarToken.wselitokenSoapPortClient();
            WsBonusObtenerCountToken.wsobtcotokSoapPortClient wsCount = new WsBonusObtenerCountToken.wsobtcotokSoapPortClient();
            string msgError;
            short codError;
            short respuesta = ws.Execute(tokenId, out msgError);
            if (respuesta == 0)
                respuesta = wsCount.Execute(tokenId, out codError, out msgError);
            else
                return false;

            return (respuesta == 0) ? true : false;
        }

        /// <summary>
        /// Delete tokens for the specific deleted user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>true for successful delete</returns>
        public bool DeleteByUserId(int userId)
        {
            /*
            0: Éxito
            1: UserId en blanco
            2: No se encontró UserId ingresado
            */
            WsBonusEliminarTokenPorUsuario.wselitokusSoapPortClient ws = new WsBonusEliminarTokenPorUsuario.wselitokusSoapPortClient();
            WsBonusObtenerCountTokenPorUsuario.wsobtctousSoapPortClient wsCount = new WsBonusObtenerCountTokenPorUsuario.wsobtctousSoapPortClient();
            string msgError;
            short codError;
            short respuesta = ws.Execute(userId.ToString(), out msgError);
            if (respuesta == 0)
                respuesta = wsCount.Execute(userId.ToString(), out codError, out msgError);
            else
                return false;

            return (respuesta == 0) ? true : false;
        }

        #endregion
    }
}
