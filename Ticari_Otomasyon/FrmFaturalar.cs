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
    public partial class FrmFaturalar : Form
    {
        public FrmFaturalar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void faturalistesi()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_FATURABILGI", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void FrmFaturalar_Load(object sender, EventArgs e)
        {
            faturalistesi();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            
            
                SqlCommand komut = new SqlCommand("insert into TBL_FATURABILGI (SERI,SIRANO,TARIH,SAAT,VERGIDAIRE,ALICI,TESLIMEDEN,TUTAR) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1",  txtSeri.Text);
                komut.Parameters.AddWithValue("@p2", txtSeriNo.Text);
                komut.Parameters.AddWithValue("@p3", MskTarih.Text);
                komut.Parameters.AddWithValue("@p4", MskSaat.Text);
                komut.Parameters.AddWithValue("@p5", txtVergiDairesi.Text);
                komut.Parameters.AddWithValue("@p6", txtAlıcı.Text);
                komut.Parameters.AddWithValue("@p7", txtTeslimEDen.Text);
                komut.Parameters.AddWithValue("@p8", txtTeslimAlan.Text);
               
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Fatura Sisteme Eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                faturalistesi();
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_FATURABILGI set SERI=@P1,SIRANO=@P2,TARIH=@P3,SAAT=@P4,VERGIDAIRE=@P5,ALICI=@P6,TESLIMEDEN=@P7,TUTAR=@P8 WHERE ID=@P9", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", txtSeri.Text);
            komut.Parameters.AddWithValue("@P2", txtSeriNo.Text);
            komut.Parameters.AddWithValue("@P3", MskTarih.Text);
            komut.Parameters.AddWithValue("@P4", MskSaat.Text);
            komut.Parameters.AddWithValue("@P5", txtVergiDairesi.Text);
            komut.Parameters.AddWithValue("@P6", txtAlıcı.Text);
            komut.Parameters.AddWithValue("@P7", txtTeslimEDen.Text);
            komut.Parameters.AddWithValue("@P8", txtTeslimAlan.Text);
            komut.Parameters.AddWithValue("@P9", txtid.Text);
            
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura Bilgisi Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            faturalistesi();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtid.Text = dr["ID"].ToString();
                txtSeri.Text = dr["SERI"].ToString();
                txtSeriNo.Text = dr["SIRANO"].ToString();
                MskTarih.Text = dr["TARIH"].ToString();
                MskSaat.Text = dr["SAAT"].ToString();
                txtVergiDairesi.Text = dr["VERGIDAIRE"].ToString();
                txtAlıcı.Text = dr["ALICI"].ToString();
                txtTeslimEDen.Text = dr["TESLIMEDEN"].ToString();
                txtTeslimAlan.Text = dr["TUTAR"].ToString();

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from TBL_FATURABILGI where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            faturalistesi();
        }
    }
}
