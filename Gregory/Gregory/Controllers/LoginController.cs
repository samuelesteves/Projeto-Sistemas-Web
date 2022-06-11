using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Gregory.Context;

namespace Gregory.Controllers
{
    public class LoginController : Controller
    {
        private Contexto _contexto = new Contexto();
        private static string AesIV256BG = @"%j?TmFP6$BbMnY$@";
        private static string AesKey256BG = @"rxmBUJy]~&,3jKwDTzf(cui$<nc2EQr)";
        public ActionResult Index(string erro)
        {
            if (erro != null)
            {
                TempData["error"] = erro;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Verificar(Models.UsuarioModel usuarioModel)
        {
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.IV = Encoding.UTF8.GetBytes(AesIV256BG);
            aes.Key = Encoding.UTF8.GetBytes(AesKey256BG);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            byte[] src = Encoding.Unicode.GetBytes(usuarioModel.Email);

            using (ICryptoTransform encrypt = aes.CreateEncryptor())
            {
                byte[] dest = encrypt.TransformFinalBlock(src, 0, src.Length);

                usuarioModel.Email = Convert.ToBase64String(dest);
            }

            Models.UsuarioModel Consulta = (Models.UsuarioModel)_contexto.Usuarios.FirstOrDefault
                (a => a.Email == usuarioModel.Email);
            string erro = "Usuário ou senha inválido";
            if (Consulta == null)
            {
                return RedirectToAction(nameof(Index), new { @erro = erro });
            }
            if (BCrypt.Net.BCrypt.Verify(usuarioModel.Senha, Consulta.Senha))
            {
                Session["Nome"] = Consulta.Nome;
                Session["Nivel"] = Consulta.Nivel;
                return RedirectToAction("Index", "Usuario");
            }
            return RedirectToAction(nameof(Index), new { @erro = erro });
            
        }
    }
}