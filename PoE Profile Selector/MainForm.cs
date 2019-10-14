using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using PoE_Profile_Selector.Properties;
using System.Diagnostics;

namespace PoE_Profile_Selector
{
    public partial class MainForm : Form
    {
        private const string BaseName_config="production_Config.ini";
        private const string BaseName_user="production_login.credentials";
        private const string PoE_games_folder=@"My Games\Path of Exile";

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                string poe_mygames_folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), PoE_games_folder);
                bool poe_main_config_exist = false;
                DirectoryInfo poe_configs = new DirectoryInfo(poe_mygames_folder);
                foreach (FileInfo curr_file_info in poe_configs.GetFiles("*.ini", SearchOption.TopDirectoryOnly))
                {
                    if (curr_file_info.Name == BaseName_config) poe_main_config_exist = true;
                    if (curr_file_info.Name.Contains("production_Config_") && File.Exists(curr_file_info.FullName.Replace("ini", "credentials").Replace("_Config_","_login_")))
                    {
                        string curr_profile_name = curr_file_info.Name.Replace("production_Config_", "").Replace(".ini","");
                        cmbProfiles.Items.Add(curr_profile_name);
                    }
                }

                if (!poe_main_config_exist)
                {
                    MessageBox.Show("Path of Exile main config file not found! Save PoE setting in game and check again.", "Main config not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }

                if (Settings.Default.PoEexePath != null || Settings.Default.PoEexePath != "")
                {
                    txtPoEpath.Text = Settings.Default.PoEexePath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        private void cmbSelectFolder_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog select_file = new OpenFileDialog();
                select_file.CheckFileExists = true;
                select_file.Multiselect = false;
                select_file.Title = "Select PoE main *.exe file...";
                select_file.ValidateNames = true;
                select_file.Filter = "Exe files(*.exe)|*.exe";
                if (select_file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtPoEpath.Text = select_file.FileName;
                    Settings.Default.PoEexePath = txtPoEpath.Text;
                    Settings.Default.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while selecting file: " + ex.Message, "Selection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void cmbProfiles_TextChanged(object sender, EventArgs e)
        {
            if (cmbProfiles.Text.Length > 0)
            {
                if (cmbProfiles.Items.Contains(cmbProfiles.Text))
                {
                    //profile name already exist
                    btnCreateProfile.Enabled = false;
                    btnDelProfile.Enabled = true;
                }
                else
                {
                    //new profile name
                    btnCreateProfile.Enabled = true;
                    btnDelProfile.Enabled = false;
                }
            }
            else
            {
                //empty profile name
                btnCreateProfile.Enabled = false;
                btnDelProfile.Enabled = false;
            }
        }

        private void btnCreateProfile_Click(object sender, EventArgs e)
        {
            try
            {
                string new_profile_name=cmbProfiles.Text;
                string poe_mygames_folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), PoE_games_folder) + @"\";

                //copy main ini file as "production_Config_<profilename>.ini"
                File.Copy(poe_mygames_folder + BaseName_config, poe_mygames_folder + "production_Config_" + cmbProfiles.Text + ".ini", true);

                //copy user data file as "production_Login_<profilename>.credentials"
                File.Copy(poe_mygames_folder + BaseName_user, poe_mygames_folder + "production_login_" + cmbProfiles.Text + ".credentials", true);
                
                cmbProfiles.Items.Add(new_profile_name);
                cmbProfiles.SelectedItem = new_profile_name;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while creating profile: " + ex.Message, "Profile creation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void cmbProfiles_SelectedValueChanged(object sender, EventArgs e)
        {
            btnDelProfile.Enabled = (cmbProfiles.Items.Contains(cmbProfiles.Text)) ? true : false;
        }

        private void btnDelProfile_Click(object sender, EventArgs e)
        {
            try
            {
                string poe_mygames_folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), PoE_games_folder) + @"\";
                string curr_profile_name = cmbProfiles.Text;
                if (cmbProfiles.Items.Contains(cmbProfiles.Text))
                {
                    File.Delete(poe_mygames_folder + "production_Config_" + curr_profile_name + ".ini");
                    File.Delete(poe_mygames_folder + "production_login_" + curr_profile_name + ".credentials");
                    cmbProfiles.Items.Remove(curr_profile_name);
                    if (cmbProfiles.Items.Count > 0)
                    {
                        cmbProfiles.SelectedIndex = 0;
                    }
                    else
                    {
                        cmbProfiles.Text = "";
                        btnDelProfile.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting profile: " + ex.Message, "Profile deletion error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnRunPoE_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(txtPoEpath.Text))
                {
                    //check if any profile selected
                    if (cmbProfiles.SelectedIndex >= 0)
                    {
                        string poe_mygames_folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), PoE_games_folder) + @"\";

                        //some exist profile selected
                        //copy "production_Config_<profilename>.ini" to main ini file
                        File.Copy(poe_mygames_folder + "production_Config_" + cmbProfiles.Text + ".ini", poe_mygames_folder + BaseName_config, true);

                        //copy "production_Login_<profilename>.credentials"to user data file
                        File.Copy(poe_mygames_folder + "production_login_" + cmbProfiles.Text + ".credentials", poe_mygames_folder + BaseName_user, true);
                    }
                    
                    //run PoE exe file
                    Process PoE_exe = new Process();
                    PoE_exe.StartInfo.UseShellExecute = true;
                    PoE_exe.StartInfo.WorkingDirectory = (new FileInfo(txtPoEpath.Text)).DirectoryName;
                    PoE_exe.StartInfo.FileName = txtPoEpath.Text;
                    PoE_exe.Start();
                }
                else
                {
                    MessageBox.Show("PoE exe file not exist!", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while running PoE" + ex.Message, "Run error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
