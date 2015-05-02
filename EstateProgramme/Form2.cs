using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstateProgramme
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }



        SqlConnection connect = new SqlConnection("server=.;database=Building;integrated security=sspi;");
        private void cmbBuildings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBuildings.Text == "Clover Building")
            {
                btnClover.BackColor = Color.Yellow;
                btnDaisy.BackColor = Color.SlateGray;
                btnRose.BackColor = Color.SlateGray;
                btnTulip.BackColor = Color.SlateGray;
            }
            if (cmbBuildings.Text == "Daisy Building")
            {
                btnClover.BackColor = Color.SlateGray;
                btnDaisy.BackColor = Color.Yellow;
                btnRose.BackColor = Color.SlateGray;
                btnTulip.BackColor = Color.SlateGray;
            }
            if (cmbBuildings.Text == "Rose Building")
            {
                btnClover.BackColor = Color.SlateGray;
                btnDaisy.BackColor = Color.SlateGray;
                btnRose.BackColor = Color.Yellow;
                btnTulip.BackColor = Color.SlateGray;
            }
            if (cmbBuildings.Text == "Tulip Building")
            {
                btnClover.BackColor = Color.SlateGray;
                btnDaisy.BackColor = Color.SlateGray;
                btnRose.BackColor = Color.SlateGray;
                btnTulip.BackColor = Color.Yellow;
            }
        }

        private void showData()
        {
            listView2.Items.Clear();
            connect.Open();

            SqlCommand command = new SqlCommand("select * from tblBuildingInformation", connect);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem row = new ListViewItem(reader["buildingId"].ToString());
                row.SubItems.Add(reader["buildings"].ToString());
                row.SubItems.Add(reader["saleRent"].ToString());
                row.SubItems.Add(reader["room"].ToString());
                row.SubItems.Add(reader["meter"].ToString());
                row.SubItems.Add(reader["cost"].ToString());
                row.SubItems.Add(reader["block"].ToString());
                row.SubItems.Add(reader["no"].ToString());
                row.SubItems.Add(reader["nameSurname"].ToString());
                row.SubItems.Add(reader["phone"].ToString());
                row.SubItems.Add(reader["notes"].ToString());

                listView2.Items.Add(row);
            }

            connect.Close();



        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            showData();
        }

        private void saveData()
        {
            connect.Open();
            string sql = "insert into tblBuildingInformation(buildingId,buildings,saleRent,room,meter,cost,block,no,nameSurname,phone,notes) values('"+txtBuildingId.Text+"','" + cmbBuildings.Text + "','" + cmbSaleRent.Text + "','" + cmbRooms.Text + "','" + txtMeter.Text + "','" + txtCost.Text + "','" + cmbBlock.Text + "','" + txtNo.Text + "','" + txtNameSurname.Text + "','" + txtPhone.Text + "','" + txtNotes.Text + "')";
            SqlCommand command = new SqlCommand(sql, connect);
            command.ExecuteNonQuery();
            connect.Close();


        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            saveData();
            showData();

            cmbBuildings.Text = "";
            cmbSaleRent.Text = "";
            cmbRooms.Text = "";
            txtMeter.Clear();
            txtCost.Clear();
            cmbBlock.Text = "";
            txtNo.Clear();
            txtNameSurname.Clear();
            txtPhone.Clear();
            txtNotes.Clear();
        }

        int id = 0;


        private void btnDelete_Click(object sender, EventArgs e)
        {
            connect.Open();
            string sql = "delete from tblBuildingInformation where buildingId=(" + id + ")";
            SqlCommand command = new SqlCommand(sql, connect);
            command.ExecuteNonQuery();
            connect.Close();
            showData();

        }

        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtBuildingId.Text = listView2.SelectedItems[0].SubItems[0].Text;
            id = int.Parse(txtBuildingId.Text);

            txtBuildingId.Enabled = true;
            cmbBuildings.Text = listView2.SelectedItems[0].SubItems[1].Text;

            cmbSaleRent.Text = listView2.SelectedItems[0].SubItems[2].Text;
            cmbRooms.Text = listView2.SelectedItems[0].SubItems[3].Text;
            txtMeter.Text = listView2.SelectedItems[0].SubItems[4].Text;
            txtCost.Text = listView2.SelectedItems[0].SubItems[5].Text;
            cmbBlock.Text = listView2.SelectedItems[0].SubItems[6].Text;
            txtNo.Text = listView2.SelectedItems[0].SubItems[7].Text;
            txtNameSurname.Text = listView2.SelectedItems[0].SubItems[8].Text;
            txtPhone.Text = listView2.SelectedItems[0].SubItems[9].Text;
            txtNotes.Text = listView2.SelectedItems[0].SubItems[10].Text;


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            connect.Open();

            SqlCommand command = new SqlCommand("update tblBuildingInformation set buildings='" + cmbBuildings.Text.ToString() + "',saleRent='" + cmbSaleRent.Text.ToString() + "',room='" + cmbRooms.Text.ToString() + "',meter='" + txtMeter.Text.ToString() + "',cost='" + txtCost.Text.ToString() + "',block='" + cmbBlock.Text.ToString() + "',no='" + txtNo.Text.ToString() + "',nameSurname='" + txtNameSurname.Text.ToString() + "',phone='" + txtPhone.Text.ToString() + "',notes='" + txtNotes.Text.ToString() + "' where buildingId=(" + id + ")", connect);
            command.ExecuteNonQuery();
            connect.Close();
            showData();

        }

      



    }
}
