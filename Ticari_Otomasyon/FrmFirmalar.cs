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
    public partial class FrmFirmalar : Form
    {
        public FrmFirmalar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void firmalistesi()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_FIRMALAR", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }


        private void labelControl3_Click(object sender, EventArgs e)
        {

        }
        void sehirlistesi()
        {
            SqlCommand komut = new SqlCommand("Select Sehir From TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbil.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }


            private void FrmFirmalar_Load(object sender, EventArgs e)
        {
            firmalistesi();
            sehirlistesi();

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr !=null)
            {
                txtid.Text = dr["ID"].ToString();
                txtAd.Text = dr["AD"].ToString();
                txtYetkiliGorev.Text = dr["YETKILISTATU"].ToString();
                txtYetkili.Text = dr["YETKILIADSOYAD"].ToString();
                MskTc.Text = dr["YETKILITC"].ToString();
                txtSektör.Text = dr["SEKTOR"].ToString();
                MskTel1.Text = dr["TELEFON1"].ToString();
                MskTel2.Text = dr["TELEFON2"].ToString();
                MskTel3.Text = dr["TELEFON3"].ToString();
                txtMail.Text = dr["MAIL"].ToString();
                MskFax.Text = dr["FAX"].ToString();
                cmbil.Text = dr["IL"].ToString();
                cmbilce.Text = dr["ILCE"].ToString();
                txtvergid.Text = dr["VERGIDAIRE"].ToString();
                rchadres.Text = dr["ADRES"].ToString();
                txtKod1.Text = dr["OZELKOD1"].ToString();
                txtKod2.Text = dr["OZELKOD2"].ToString();
                txtKod3.Text = dr["OZELKOD3"].ToString();






            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_FIRMALAR (AD,YETKILISTATU,YETKILIADSOYAD,YETKILITC,SEKTOR,TELEFON1,TELEFON2,TELEFON3,MAIL,FAX,IL,ILCE,VERGIDAIRE,ADRES,OZELKOD1,OZELKOD2,OZELKOD3) VALUES (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9,@P10,@P11,@P12,@P13,@P14,@P15,@P16,@P17)", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", txtAd.Text);
            komut.Parameters.AddWithValue("@P2", txtYetkiliGorev.Text);
            komut.Parameters.AddWithValue("@P3", txtYetkili.Text);
            komut.Parameters.AddWithValue("@P4", MskTc.Text);
            komut.Parameters.AddWithValue("@P5", txtSektör.Text);
            komut.Parameters.AddWithValue("@P6", MskTel1.Text);
            komut.Parameters.AddWithValue("@P7", MskTel2.Text);
            komut.Parameters.AddWithValue("@P8", MskTel3.Text);
            komut.Parameters.AddWithValue("@P9", txtMail.Text);
            komut.Parameters.AddWithValue("@P10", MskFax.Text);
            komut.Parameters.AddWithValue("@P11", cmbil.Text);
            komut.Parameters.AddWithValue("@P12", cmbilce.Text);
            komut.Parameters.AddWithValue("@P13", txtvergid.Text);
            komut.Parameters.AddWithValue("@P14", rchadres.Text);
            komut.Parameters.AddWithValue("@P15", txtKod1.Text);
            komut.Parameters.AddWithValue("@P16", txtKod2.Text);
            komut.Parameters.AddWithValue("@P17", txtKod3.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma Sisteme Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            firmalistesi();
        }

        private void cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbilce.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("Select ilce from TBL_ILCELER where Sehir=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbil.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbilce.Properties.Items.Add(dr[0]);

            }
            bgl.baglanti().Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_FIRMALAR set AD=@P1,YETKILISTATU=@P2,YETKILIADSOYAD=@P3,YETKILITC=@P4,SEKTOR=@P5,TELEFON1=@P6,TELEFON2=@P7,TELEFON3=@P8,MAIL=@P9,IL=@P11,ILCE=@P12,FAX=@P10,VERGIDAIRE=@P13,ADRES=@P14,OZELKOD1=@P15,OZELKOD2=@P16,OZELKOD3=@P17 WHERE ID=@P18", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", txtAd.Text);
            komut.Parameters.AddWithValue("@P2", txtYetkiliGorev.Text);
            komut.Parameters.AddWithValue("@P3", txtYetkili.Text);
            komut.Parameters.AddWithValue("@P4", MskTc.Text);
            komut.Parameters.AddWithValue("@P5", txtSektör.Text);
            komut.Parameters.AddWithValue("@P6", MskTel1.Text);
            komut.Parameters.AddWithValue("@P7", MskTel2.Text);
            komut.Parameters.AddWithValue("@P8", MskTel3.Text);
            komut.Parameters.AddWithValue("@P9", txtMail.Text);
            komut.Parameters.AddWithValue("@P10", MskFax.Text);
            komut.Parameters.AddWithValue("@P11", cmbil.Text);
            komut.Parameters.AddWithValue("@P12", cmbilce.Text);
            komut.Parameters.AddWithValue("@P13", txtvergid.Text);
            komut.Parameters.AddWithValue("@P14", rchadres.Text);
            komut.Parameters.AddWithValue("@P15", txtKod1.Text);
            komut.Parameters.AddWithValue("@P16", txtKod2.Text);
            komut.Parameters.AddWithValue("@P17", txtKod3.Text);
            komut.Parameters.AddWithValue("@P18", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma Bilgisi Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            firmalistesi();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete From TBL_FIRMALAR where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            firmalistesi();
            MessageBox.Show("Firma listeden silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }
    }
}
