using Gregory.Context;
using Gregory.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Gregory.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly Contexto _contexto = new Contexto();
        private static string AesIV256BD = @"%j?TmFP6$BbMnY$@";
        private static string AesKey256BD = @"rxmBUJy]&,;3jKwDTzf(cui$<nc2EQr)";

        public ActionResult Index()
        {

            if (Session["Nome "] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            List<UsuarioModel> usuarios = _contexto.Usuarios.ToList();

            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.IV = Encoding.UTF8.GetBytes(AesIV256BD);
            aes.Key = Encoding.UTF8.GetBytes(AesKey256BD);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            for (int i = 0; i < usuarios.Count; i++)
            {
                byte[] src = System.Convert.FromBase64String(usuarios[i].Email);

                using (ICryptoTransform decrypt = aes.CreateDecryptor())
                {
                    byte[] dest = decrypt.TransformFinalBlock(src, 0, src.Length);

                    usuarios[i].Email = Encoding.Unicode.GetString(dest);
                }

            }
            return View(usuarios);

        }   
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioModel usuarioModel)
        {
            if (ModelState.IsValid)
            {
                usuarioModel.Senha = BCrypt.Net.BCrypt.HashPassword(usuarioModel.Senha);
                usuarioModel.ConfirmarSenha = usuarioModel.Senha;

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

                _contexto.Usuarios.Add(usuarioModel);

                _contexto.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            return View(usuarioModel);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            UsuarioModel usuarioModel = _contexto.Usuarios.Find(id);
            if (usuarioModel == null)
            {
                return HttpNotFound();
            }

            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.IV = Encoding.UTF8.GetBytes(AesIV256BD);
            aes.Key = Encoding.UTF8.GetBytes(AesKey256BD);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            byte[] src = System.Convert.FromBase64String(usuarioModel.Email);

            using (ICryptoTransform decrypt = aes.CreateDecryptor()) 
            {
                byte[] dest = decrypt.TransformFinalBlock(src, 0, src.Length);

                usuarioModel.Email = Encoding.Unicode.GetString(dest);
            }

            return View(usuarioModel);

        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioModel usuarioModel = _contexto.Usuarios.Find(id);
            if (usuarioModel == null)
            {
                return HttpNotFound();
            }

            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.IV = Encoding.UTF8.GetBytes(AesIV256BD);
            aes.Key = Encoding.UTF8.GetBytes(AesKey256BD);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            byte[] src = System.Convert.FromBase64String(usuarioModel.Email);

            using (ICryptoTransform decrypt = aes.CreateDecryptor())
            {
                byte[] dest = decrypt.TransformFinalBlock(src, 0, src.Length);

                usuarioModel.Email = Encoding.Unicode.GetString(dest);
            }

            return View(usuarioModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = _contexto.Usuarios.Find(usuarioModel.Id);
            usuarioModel.Senha = usuario.Senha;
            usuarioModel.ConfirmarSenha = usuario.Senha;
            _contexto.Entry(usuario).State = EntityState.Detached;

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

            _contexto.Entry(usuarioModel).State = EntityState.Modified;
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index));


        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            UsuarioModel usuarioModel = _contexto.Usuarios.Find(id);
            if (usuarioModel == null)
            {
                return HttpNotFound();
            }
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.IV = Encoding.UTF8.GetBytes(AesIV256BD);
            aes.Key = Encoding.UTF8.GetBytes(AesKey256BD);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            byte[] src = System.Convert.FromBase64String(usuarioModel.Email);

            using (ICryptoTransform decrypt = aes.CreateDecryptor())
            {
                byte[] dest = decrypt.TransformFinalBlock(src, 0, src.Length);

                usuarioModel.Email = Encoding.Unicode.GetString(dest);
            }
            return View(usuarioModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsuarioModel usuarioModel = _contexto.Usuarios.Find(id);
            _contexto.Usuarios.Remove(usuarioModel);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }


    }
}