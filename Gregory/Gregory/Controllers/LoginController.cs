using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Gregory.Context;
using Gregory.Models;

namespace Gregory.Controllers
{
    public class LoginController : Controller
    {
        private Contexto _contexto = new Contexto();
        private static string AesIV256BD = @"%j?TmFP6$BbMnY$@";
        private static string AesKey256BD = @"rxmBUJy]~&,3jKwDTzf(cui$<nc2EQr)";
        public ActionResult Index(string erro)
        {

            //List<UsuarioModel> usuarios = _contexto.Usuarios.ToList();

            //AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            //aes.BlockSize = 128;
            //aes.KeySize = 256;
            //aes.IV = Encoding.UTF8.GetBytes(AesIV256BD);
            //aes.Key = Encoding.UTF8.GetBytes(AesKey256BD);
            //aes.Mode = CipherMode.CBC;
            //aes.Padding = PaddingMode.PKCS7;

            //for (int i = 2; i < usuarios.Count; i++)
            //{
            //    byte[] src = System.Convert.FromBase64String(usuarios[i].Email);

            //    using (ICryptoTransform decrypt = aes.CreateDecryptor())
            //    {
            //        byte[] dest = decrypt.TransformFinalBlock(src, 0, src.Length);

            //        usuarios[i].Email = Encoding.Unicode.GetString(dest);
            //    }

            if (erro != null)
            {
                TempData["error"] = erro;
            }


            //}
            return View();
        }

        [HttpPost]
        public ActionResult Verificar (Models.UsuarioModel usuarioModel)
        {
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.IV = Encoding.UTF8.GetBytes(AesIV256BD);
            aes.Key = Encoding.UTF8.GetBytes(AesKey256BD);
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
                Session["Nome "] = Consulta.Nome;
                Session["Nivel "] = Consulta.Nivel;
                return RedirectToAction("Index", "Usuario");
            }

            return RedirectToAction(nameof(Index), new { @erro = erro });
            //return RedirectToAction("Index", "Usuario");


        }
            

        
    }
}