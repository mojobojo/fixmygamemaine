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

    public struct actor_data {
        public int file_offset;
        public string bp_name;
        public float yaw;
        public float pitch;
        public float roll;
        public float x;
        public float y;
        public float z;
        public int hp_position;
        public float hp;
    }
    public partial class Form1 : Form {

        Dictionary<int, string> paths;
        Dictionary<int, actor_data> actors;

        BinaryReader binary_reader;
        BinaryWriter binary_writer;
        FileStream file_stream;

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            string save_path = Environment.GetEnvironmentVariable("USERPROFILE") + "\\Saved Games\\Grounded\\";

            string[] saves = Directory.GetDirectories(save_path);


            paths = new Dictionary<int, string>();

            for (int i = 0; i < saves.Length; i++) {
                listBox1.Items.Add(Path.GetFileName(saves[i]));
                paths.Add(i, saves[i]);
            }   
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {

            string str;
            if (paths.TryGetValue(listBox1.SelectedIndex, out str)) {

                listBox2.Items.Clear();
                actors = new Dictionary<int, actor_data>();

                string save_path = str + "\\World.sav";
                string save_image = str + "\\SaveGameScreenshot.png";

                pictureBox2.Image = Image.FromFile(save_image);

                file_stream = new FileStream(save_path, FileMode.Open);
                binary_reader = new BinaryReader(file_stream);
                binary_writer = new BinaryWriter(file_stream);

                binary_reader.BaseStream.Position = 0x10;

                int item_count = binary_reader.ReadInt32();

                for (int i = 0; i < item_count; i++) {
                    int data_size = binary_reader.ReadInt32();
                    int next_offset = (int)binary_reader.BaseStream.Position + data_size - 4;

                    binary_reader.BaseStream.Position += 0x14;
                    int bp_size = binary_reader.ReadInt32();
                    string bp = Encoding.ASCII.GetString(binary_reader.ReadBytes(bp_size - 1));

                    if (bp == "/Game/Blueprints/Global/BP_SurvivalGameState.BP_SurvivalGameState_C") {

                        binary_reader.BaseStream.Position += 0x68;
                        int actor_count = binary_reader.ReadInt32();

                        for (int ac = 0; ac < actor_count; ac++) {
                            actor_data a_data = new actor_data();

                            a_data.file_offset = (int)binary_reader.BaseStream.Position;

                            int size = binary_reader.ReadInt32();
                            int next_actor_offset = (int)binary_reader.BaseStream.Position + size - 4;

                            binary_reader.BaseStream.Position += 0xC;

                            int actor_type_len = binary_reader.ReadInt32();
                            string actor_type_str = Encoding.ASCII.GetString(binary_reader.ReadBytes(actor_type_len - 1));

                            binary_reader.BaseStream.Position += 1;

                            int actor_str_size = binary_reader.ReadInt32();
                            string actor_str = Encoding.ASCII.GetString(binary_reader.ReadBytes(actor_str_size - 1));

                            binary_reader.BaseStream.Position += 1;

                            float dummy = binary_reader.ReadSingle();

                            a_data.yaw = binary_reader.ReadSingle();
                            a_data.pitch = binary_reader.ReadSingle();
                            a_data.roll = binary_reader.ReadSingle();

                            a_data.x = binary_reader.ReadSingle();
                            a_data.y = binary_reader.ReadSingle();
                            a_data.z = binary_reader.ReadSingle();

                            dummy = binary_reader.ReadSingle();
                            dummy = binary_reader.ReadSingle();
                            dummy = binary_reader.ReadSingle();
                            dummy = binary_reader.ReadSingle();
                            dummy = binary_reader.ReadSingle();
                            dummy = binary_reader.ReadSingle();
                            dummy = binary_reader.ReadSingle();

                            int some_int_0 = binary_reader.ReadInt32();
                            int some_int_1 = binary_reader.ReadInt32();

                            if (some_int_1 == 0) {
                                int actor_property_count = binary_reader.ReadInt32();

                                for (int apc = 0; apc < actor_property_count; apc++) {
                                    int ap_size = binary_reader.ReadInt32();
                                    int next_ap = (int)binary_reader.BaseStream.Position + ap_size - 4;

                                    binary_reader.BaseStream.Position += 0xC;
                                    int ap_str_size = binary_reader.ReadInt32();
                                    string ap_str = Encoding.ASCII.GetString(binary_reader.ReadBytes(ap_str_size - 1));

                                    if (ap_str == "/Script/Maine.HealthLODComponent") {
                                        binary_reader.BaseStream.Position += 1;
                                        a_data.hp_position = (int)binary_reader.BaseStream.Position;
                                        a_data.hp = binary_reader.ReadSingle();
                                    }

                                    binary_reader.BaseStream.Position = next_ap;
                                }
                            }

                            binary_reader.BaseStream.Position = next_actor_offset;

                            listBox2.Items.Add(actor_str);

                            a_data.bp_name = actor_str;

                            actors.Add(ac, a_data);
                        }

                        break;
                    }

                    binary_reader.BaseStream.Position = next_offset;
                }
            }

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                actor_data a_data;
                if (actors.TryGetValue(listBox2.SelectedIndex, out a_data)) {
                    yaw_text.Text = "Yaw: " + a_data.yaw.ToString();
                    pitch_text.Text = "Pitch: " + a_data.pitch.ToString();
                    roll_text.Text = "Roll: " + a_data.roll.ToString();
                    x_text.Text = "X: " + a_data.x.ToString();
                    y_text.Text = "Y: " + a_data.y.ToString();
                    z_text.Text = "Z: " + a_data.z.ToString();
                    hp_text.Text = "HP: " + a_data.hp.ToString();
                }
            } catch {

            }
        }

        private void button1_Click(object sender, EventArgs e) {
            foreach (int k in actors.Keys) {
                actor_data ad = actors[k];

                if (ad.bp_name == "/Game/Blueprints/Creatures/Larva/Base/BP_Larva.BP_Larva_C") {
                    binary_writer.BaseStream.Position = ad.hp_position;
                    binary_writer.Write((float)0.0f);
                }

                binary_writer.Flush();
            }
        }
    }
}
