using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ticari_Otomasyon
{
    public partial class FrmBankalar : Form
    {
        public FrmBankalar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void sehirlistesi()
        {
            SqlCommand komut = new SqlCommand("Select Sehir From TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Cmbİl.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }
     
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_BANKALAR", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void FrmBankalar_Load(object sender, EventArgs e)
        {
            
            listele();
            sehirlistesi();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_BANKALAR (BANKAADI,IL,ILCE,SUBE,IBAN,HESAPNO,YETKILI,TELEFON,TARIH,HESAPTURU,FIRMAID) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtBankaAd.Text);
            komut.Parameters.AddWithValue("@p2", Cmbİl.Text);
            komut.Parameters.AddWithValue("@p3", Cmbİlce.Text);
            komut.Parameters.AddWithValue("@p4", txtSube.Text);
            komut.Parameters.AddWithValue("@p5", Mskiban.Text);
            komut.Parameters.AddWithValue("@p6", mskHesapNo.Text);
            komut.Parameters.AddWithValue("@p7", txtYetkili.Text);
            komut.Parameters.AddWithValue("@p8", MskTel.Text);
            komut.Parameters.AddWithValue("@p9", MskTarih.Text);
            komut.Parameters.AddWithValue("@p10", txtHesapTuru.Text);
            komut.Parameters.AddWithValue("@p11", TxtFirma.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Banka Sisteme Eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void Cmbİl_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Cmbİlce.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("Select ilce from TBL_ILCELER where Sehir=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Cmbİl.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Cmbİlce.Properties.Items.Add(dr[0]);

            }
            bgl.baglanti().Close();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_BANKALAR set BANKAADI=@P1,IL=@P2,ILCE=@P3,SUBE=@P4,IBAN=@P5,HESAPNO=@P6,YETKILI=@P7,TELEFON=@P8,TARIH=@P9,HESAPTURU=@P10,FIRMAID=@P11 where ID=@P12", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtBankaAd.Text);
            komut.Parameters.AddWithValue("@p2", Cmbİl.Text);
            komut.Parameters.AddWithValue("@p3", Cmbİlce.Text);
            komut.Parameters.AddWithValue("@p4", txtSube.Text);
            komut.Parameters.AddWithValue("@p5", Mskiban.Text);
            komut.Parameters.AddWithValue("@p6", mskHesapNo.Text);
            komut.Parameters.AddWithValue("@p7", txtYetkili.Text);
            komut.Parameters.AddWithValue("@p8", MskTel.Text);
            komut.Parameters.AddWithValue("@p9", MskTarih.Text);
            komut.Parameters.AddWithValue("@p10", txtHesapTuru.Text);
            komut.Parameters.AddWithValue("@p11", TxtFirma.Text);
            komut.Parameters.AddWithValue("@p12", txtBankaid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Banka Bilgileri Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtBankaid.Text = dr["ID"].ToString();
                txtBankaAd.Text = dr["BANKAADI"].ToString();
                Cmbİl.Text = dr["IL"].ToString();
                Cmbİlce.Text = dr["ILCE"].ToString();
                txtSube.Text = dr["SUBE"].ToString();
                Mskiban.Text = dr["IBAN"].ToString();
                mskHesapNo.Text = dr["HESAPNO"].ToString();
                txtYetkili.Text = dr["YETKILI"].ToString();
                MskTel.Text = dr["TELEFON"].ToString();
                MskTarih.Text = dr["TARIH"].ToString();
                txtHesapTuru.Text = dr["HESAPTURU"].ToString();
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from TBL_BANKALAR where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtBankaid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Banka Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            listele();
        }
    }
}
