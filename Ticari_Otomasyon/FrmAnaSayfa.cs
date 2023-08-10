using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlClient;

namespace Ticari_Otomasyon
{
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }

        private void d(object sender, EventArgs e)
        {

        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void stoklar()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Urunad, Sum(Adet) as 'Adet' From TBL_URUNLER group by Urunad having Sum(adet)<=20 order by Sum(Adet)"
               , bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }


        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.tcmb.gov.tr/kurlar/today.xml");
            haberler();
            stoklar();
            notlar();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
           
        }
        void haberler()
        {
            XmlTextReader xmloku = new XmlTextReader("https://www.hurriyet.com.tr/rss/anasayfa");
            while (xmloku.Read())
            {
                if (xmloku.Name == "title")
                {
                    listBox1.Items.Add(xmloku.ReadString());
                }
            }
        }
        void notlar()
        {
            DataTable df = new DataTable();
            SqlDataAdapter dc = new SqlDataAdapter("Select * From TBL_NOTLAR ", bgl.baglanti());
            dc.Fill(df);
            gridControl2.DataSource = df;
        }
    }
}
