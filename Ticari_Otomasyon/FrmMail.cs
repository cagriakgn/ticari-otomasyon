using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
namespace Ticari_Otomasyon
{
    public partial class FrmMail : Form
    {
        public FrmMail()
        {
            InitializeComponent();
        }
        public string mail;
        private void FrmMail_Load(object sender, EventArgs e)
        {
            txtMailAdres.Text = mail;
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            List<String> mails = new List<string>();
            mails.Add("cgriakgn@gmail.com");
            mails.Add("cagri.akgun@oskon.com.tr");

           
                MailMessage mesajım = new MailMessage();
                SmtpClient istemci = new SmtpClient();
                istemci.Credentials = new System.Net.NetworkCredential("cgriakgn67@outlook.com", "kartal67");
                istemci.Port = 587;
                istemci.Host = "smtp.office365.com";
                istemci.EnableSsl = true;
            foreach (String mail in mails)
            {
                mesajım.To.Add(mail);
            }
                mesajım.From = new MailAddress("cgriakgn67@outlook.com");
                mesajım.Subject = txtKonu.Text;
                mesajım.Body = rchMsj.Text;
                istemci.Send(mesajım);
                MessageBox.Show("Mail İletildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
        }
    }
}
