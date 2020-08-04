using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;

namespace fixmygamemaine {


    public partial class Form1 : Form {

        string[] save_paths;

        MaineSave save_file;

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            save_paths = MaineSave.get_save_list();

            for (int i = 0; i < save_paths.Length; i++) {
                listBox1.Items.Add(Path.GetFileName(save_paths[i]));
            }   
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            string folder_path = save_paths[listBox1.SelectedIndex];

            if (save_file != null) {
                save_file.close();
            }

            listBox2.Items.Clear();

            save_file = new MaineSave();
            save_file.open(folder_path);

            pictureBox2.Image = save_file.screenshot;

            foreach(maine_actor_data actor in save_file.actors) {
                listBox2.Items.Add(actor.bp_name);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                maine_actor_data a_data = save_file.actors[listBox2.SelectedIndex];
                qx_text.Text = "QX: " + a_data.q_x.ToString();
                qy_text.Text = "QY: " + a_data.q_y.ToString();
                qz_text.Text = "QZ: " + a_data.q_z.ToString();
                qw_text.Text = "QW: " + a_data.q_w.ToString();
                x_text.Text = "X: " + a_data.x.ToString();
                y_text.Text = "Y: " + a_data.y.ToString();
                z_text.Text = "Z: " + a_data.z.ToString();
                hp_text.Text = "HP: " + a_data.hp.ToString();
            } catch {

            }
        }

        private void button1_Click(object sender, EventArgs e) {
            if (save_file != null) {
                save_file.kill_larva();
                MessageBox.Show("All those larva should be dead now.");
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Are you sure you want to kill all living things?", "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                save_file.kill_everything();
            } 
        }

        private void button3_Click(object sender, EventArgs e) {
            //save_file.move_everything_to(2503.91430664062f, 33674.51953125f, 3142.60375976562f);
        }
    }
}
