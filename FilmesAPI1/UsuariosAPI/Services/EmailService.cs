using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using MailKit.Net.Smtp;
using MimeKit;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class EmailService
    {
        private IConfiguration _config;
        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public void EnviarEmail(string[] destinatario, string assunto, int usuarioId, string code)
        {
            Mensagem mensagem = new Mensagem(destinatario, assunto, usuarioId, code);
            var mensagemDeEmail = CriaCorpoDoEmail(mensagem);
            Enviar(mensagemDeEmail);
        }
        private MimeMessage CriaCorpoDoEmail(Mensagem mensagem)
        {
            var mensagemDeEmail = new MimeMessage();
            mensagemDeEmail.From.Add(new MailboxAddress("",_config.GetValue<string>("EmailSettings:From")));
            mensagemDeEmail.To.AddRange(mensagem.Destinatario);
            mensagemDeEmail.Subject = mensagem.Assunto;
            mensagemDeEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = mensagem.Conteudo};
            
             return mensagemDeEmail;
        }
        private void Enviar(MimeMessage mensagemDeEmail)
        {
            using(var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_config.GetValue<string>("EmailSettings:SmtpServer")
                        ,_config.GetValue<int>("EmailSettings:Port"),true);
                    client.AuthenticationMechanisms.Remove("XOUATH2");
                    client.Authenticate(_config.GetValue<string>("EmailSettings:From"),
                        _config.GetValue<string>("EmailSettings:Password"));

                    client.Send(mensagemDeEmail);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }
    }
}

