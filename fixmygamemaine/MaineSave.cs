using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace fixmygamemaine {
    public struct maine_actor_data {
        public int file_offset;
        public string bp_name;
        public float q_x;
        public float q_y;
        public float q_z;
        public float q_w;
        public int position_offset;
        public float x;
        public float y;
        public float z;
        public int hp_offset;
        public float hp;
    }
    public class MaineSave {

        public Image screenshot;
        public List<maine_actor_data> actors;

        private BinaryReader binary_reader;
        private BinaryWriter binary_writer;
        private FileStream file_stream;

        public static string[] get_save_list(string save_path) {
            string[] saves = Directory.GetDirectories(save_path);
            return saves;
        }

        public static string[] get_save_list() {
            string save_path = Environment.GetEnvironmentVariable("USERPROFILE") + "\\Saved Games\\Grounded\\";
            return get_save_list(save_path);
        }

        public void open(string folder_path) {
            string save_path = folder_path + "\\World.sav";
            string save_image = folder_path + "\\SaveGameScreenshot.png";

            if (File.Exists(save_image)) {
                screenshot = Image.FromFile(save_image);
            }

            if (File.Exists(save_path)) {
                actors = new List<maine_actor_data>();

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
                            maine_actor_data a_data = new maine_actor_data();

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

                            a_data.q_x = binary_reader.ReadSingle();
                            a_data.q_y = binary_reader.ReadSingle();
                            a_data.q_z = binary_reader.ReadSingle();
                            a_data.q_w = binary_reader.ReadSingle();

                            a_data.position_offset = (int)binary_reader.BaseStream.Position;

                            a_data.x = binary_reader.ReadSingle();
                            a_data.y = binary_reader.ReadSingle();
                            a_data.z = binary_reader.ReadSingle();

                            float dummy = binary_reader.ReadSingle();
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
                                        a_data.hp_offset = (int)binary_reader.BaseStream.Position;
                                        a_data.hp = binary_reader.ReadSingle();
                                    }

                                    binary_reader.BaseStream.Position = next_ap;
                                }
                            }

                            binary_reader.BaseStream.Position = next_actor_offset;

                            a_data.bp_name = actor_str;

                            actors.Add(a_data);
                        }

                        break;
                    }

                    binary_reader.BaseStream.Position = next_offset;
                }
            }
        }

        public void kill_larva() {
            foreach (maine_actor_data ad in actors) {
                if (ad.bp_name == "/Game/Blueprints/Creatures/Larva/Base/BP_Larva.BP_Larva_C") {
                    binary_writer.BaseStream.Position = ad.hp_offset;
                    binary_writer.Write((float)0.0f);
                }

                binary_writer.Flush();
            }
        }

        public void kill_everything() {
            foreach (maine_actor_data ad in actors) {
                if (ad.hp > 0 && !ad.bp_name.Contains("Burgle")) {
                    binary_writer.BaseStream.Position = ad.hp_offset;
                    binary_writer.Write((float)0.0f);
                }
            }

            binary_writer.Flush();
        }

        public void move_everything_to(float x, float y, float z) {
            foreach (maine_actor_data ad in actors) {
                //if (ad.bp_name.Contains("Creatures") && !ad.bp_name.Contains("Burgle")) {
                //    binary_writer.BaseStream.Position = ad.position_offset;
                //    binary_writer.Write(x);
                //    binary_writer.Write(y);
                //    binary_writer.Write(z);
                //}

                if (ad.bp_name.Contains("Harvested")) {
                    binary_writer.BaseStream.Position = ad.position_offset;
                    binary_writer.Write(x);
                    binary_writer.Write(y);
                    binary_writer.Write(z);
                }
            }

            binary_writer.Flush();
        }

        public void close() {
            if (binary_writer != null) {
                binary_reader.Close();
            }

            if (binary_writer != null) {
                binary_writer.Close();
            }

            if (file_stream != null) {
                file_stream.Close();
            }
        }
    }
}
