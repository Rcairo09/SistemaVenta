using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaVenta.BLL.Interfaces;
using System.Security.Cryptography;

namespace SistemaVenta.BLL.Implementacion
{
    public class UtilidadesService : IUtilidadesService
    {

        public string GenerarClave()
        {
            string clave = Guid.NewGuid().ToString("N").Substring(0,6);
            return clave;
        }
        public string ConvertirSha256(string texto)
        {
            if (texto == null)
            {
                throw new ArgumentNullException(nameof(texto), "La cadena de entrada no puede ser nula");
            }

            StringBuilder sb = new StringBuilder();
            try
            {
                using (SHA256 hash = SHA256Managed.Create())
                {
                    Encoding enc = Encoding.UTF8;

                    byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                    foreach (byte b in result)
                    {
                        sb.Append(b.ToString("x2"));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al calcular el hash SHA256", ex);
            }

            return sb.ToString();
        }


    }
}
