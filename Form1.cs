using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime;
using s4pi.Package;
using s4pi.Interfaces;
using Ookii.Dialogs;
using Xmods.DataLib;

namespace TS4SliderConverter
{
    public partial class Form1 : Form
    {
        static string PackageFilter = "Package files (*.package)|*.package|All files (*.*)|*.*";

        public Form1()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = "Ready";
            toolStripStatusLabel2.Text = "";
            toolStripStatusLabel3.Text = "";
        }

        internal string GetFilename(string title, string filter)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = filter;
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.Title = title;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog1.FileName;
            }
            else
            {
                return "";
            }
        }

        internal Package OpenPackage(string packagePath, bool readwrite)
        {
            try
            {
                Package package = (Package)Package.OpenPackage(0, packagePath, readwrite);
                return package;
            }
            catch
            {
                MessageBox.Show("Unable to read valid package data from " + packagePath);
                return null;
            }
        }

        internal string GetSaveFilename(string title, string filter, string defaultFilename)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = PackageFilter;
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.Title = title;
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "package";
            saveFileDialog1.OverwritePrompt = true;
            if (String.CompareOrdinal(defaultFilename, " ") > 0) saveFileDialog1.FileName = defaultFilename;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                return saveFileDialog1.FileName;
            }
            else
            {
                return "";
            }
        }

        internal bool WritePackage(string filename, Package pack)
        {
            try
            {
                pack.SaveAs(filename);
                pack.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not write file " + filename + ". Original error: " + ex.Message + Environment.NewLine + ex.StackTrace.ToString());
                return false;
            }
        }

        private void PackageSelect_button_Click(object sender, EventArgs e)
        {
            string packpath = GetFilename("Select slider package to convert", PackageFilter);
            Package pack = null;
            pack = OpenPackage(packpath, false);
            if (pack == null) return;

            toolStripStatusLabel1.Text = "";
            bool done = ProcessPackage(pack, Path.GetFileName(packpath));
            if (!done)
            {
                MessageBox.Show("No slider HotSpotControls found!");
                return;
            }

            string newpackname = Path.GetFileNameWithoutExtension(packpath) + (NoRename_checkBox.Checked ? "" : "_Fixed");
            string filename = GetSaveFilename("Save converted package", PackageFilter, newpackname);
            if (string.Compare(filename, " ") <= 0)
            {
                pack.Dispose();
                toolStripStatusLabel1.Text = "Ready";
                toolStripStatusLabel2.Text = "";
                toolStripStatusLabel3.Text = "";
                return;
            }

            toolStripStatusLabel1.Text = "Saving";
            toolStripStatusLabel2.Text = "";
            toolStripStatusLabel3.Text = "";
            statusStrip1.Refresh();
            while (!WritePackage(filename, pack))
            {
                DialogResult res = MessageBox.Show("Try again?", "Could not save package", MessageBoxButtons.RetryCancel);
                if (res == DialogResult.Cancel)
                {
                    break;
                }
            }
            toolStripStatusLabel1.Text = "Ready";
        }

        private bool ProcessPackage(Package pack, string packname)
        {
            Predicate<IResourceIndexEntry> predHOTC = r => r.ResourceType == (uint)ResourceTypes.HOTC;
            List<IResourceIndexEntry> iries = pack.FindAll(predHOTC);
            int tot = iries.Count;
            if (tot == 0) return false;

            int current = 1;
            // int savecount = 0;
            toolStripStatusLabel2.Text = packname + ": ";

            foreach (IResourceIndexEntry irie in iries)
            {
                toolStripStatusLabel3.Text = "HotSpotControl " + current.ToString() + " of " + tot.ToString();
                statusStrip1.Refresh();
                current++;

                using (Stream s = pack.GetResource(irie))
                {
                    try
                    {
                        HOTC hotc = new HOTC(new BinaryReader(s));
                        if (hotc.Version < HOTC.CurrentVersion) hotc.Version = HOTC.CurrentVersion;
                        Stream s1 = new MemoryStream();
                        hotc.Write(new BinaryWriter(s1));
                        s1.Position = 0;
                        pack.ReplaceResource(irie, new Resource(1, s1));
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            return true;
        }

        private void FolderSelect_button_Click(object sender, EventArgs e)
        {
            VistaFolderBrowserDialog folder = new VistaFolderBrowserDialog();
            folder.ShowNewFolderButton = false;
            folder.Description = "Select folder containing packages to be converted";
            folder.UseDescriptionForTitle = true;
            folder.ShowDialog();
            FolderName.Text = folder.SelectedPath;
        }

        private void OutputSelect_button_Click(object sender, EventArgs e)
        {
            VistaFolderBrowserDialog folder = new VistaFolderBrowserDialog();
            folder.ShowNewFolderButton = true;
            folder.Description = "Select folder for converted packages";
            folder.UseDescriptionForTitle = true;
            folder.ShowDialog();
            OutputName.Text = folder.SelectedPath;
        }

        private void FolderGo_button_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(FolderName.Text) || !Directory.Exists(OutputName.Text))
            {
                MessageBox.Show("You have not selected valid input and output folders!");
                return;
            }
            string[] paths = Directory.GetFiles(FolderName.Text, "*.package", Subfolders_checkBox.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
            Array.Sort(paths);
            int counter = 0;
            DialogResult res = DialogResult.Retry;
            bool applyAll = false;
            string errorPacks = "";
            int numFixed = 0, numNotFixed = 0;
            foreach (string packpath in paths)
            {
                counter++;
                toolStripStatusLabel1.Text = "Package " + counter.ToString() + " of " + paths.Length.ToString() + " : ";
                Package pack = null;
                pack = OpenPackage(packpath, false);
                if (pack == null) continue;
                bool wasFixed;
                try
                {
                    wasFixed = ProcessPackage(pack, Path.GetFileName(packpath));
                    if (wasFixed) numFixed++;
                    if (!wasFixed) numNotFixed++;
                }
                catch (Exception ep)
                {
                    errorPacks += packpath + " (" + ep.Message + ")" + Environment.NewLine;
                    wasFixed = false;
                }

                if (!wasFixed && NoCopy_checkBox.Checked) continue;
                string newpath = packpath.Replace(FolderName.Text, OutputName.Text);
                string newdir = Path.GetDirectoryName(newpath);
                string status = wasFixed ? "_Fixed" : "_NotFixed";
                if (!Directory.Exists(newdir)) Directory.CreateDirectory(newdir);
                string newpackname = newdir + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(packpath) +
                    (NoRename_checkBox.Checked ? ".package" : status + ".package");
                if (File.Exists(newpackname))
                {
                    if (!applyAll)
                    {
                        using (DupFileDialog dup = new DupFileDialog("A package already exists with the name: " + Environment.NewLine + newpackname))
                        {
                            res = dup.ShowDialog();
                            applyAll = dup.ApplyToAll;
                        }
                    }
                    if (res == DialogResult.OK)
                    {
                        // go on to save package
                    }
                    else if (res == DialogResult.Retry)         //get a non-duplicate file name
                    {
                        int append = 1;
                        newpackname = newdir + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(packpath) +
                                            (NoRename_checkBox.Checked ? "" : status) + append.ToString() + ".package";
                        while (File.Exists(newpackname))
                        {
                            append++;
                            newpackname = newdir + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(packpath) +
                                            (NoRename_checkBox.Checked ? "" : status) + append.ToString() + ".package";
                        }
                    }
                    else if (res == DialogResult.Ignore)        //discard new package
                    {
                        continue;
                    }
                    else if (res == DialogResult.Cancel)
                    {
                        toolStripStatusLabel1.Text = "Ready";
                        toolStripStatusLabel2.Text = "";
                        toolStripStatusLabel3.Text = "";
                        return;
                    }
                }
                pack.SaveAs(newpackname);
                pack.Dispose();
            }
            if (errorPacks.Length > 0)
            {
                MessageBox.Show("The following package(s) were not successfully converted." + Environment.NewLine + Environment.NewLine +
                    errorPacks + Environment.NewLine + "Please convert them individually to get detailed error messages.");
            }
            MessageBox.Show("Done!");
            toolStripStatusLabel1.Text = "Ready";
            toolStripStatusLabel2.Text = "";
            toolStripStatusLabel3.Text = "";
        }

        internal class Resource : AResource
        {
            internal Resource(int APIversion, Stream s) : base(APIversion, s) { }

            public override int RecommendedApiVersion
            {
                get { return 1; }
            }

            protected override Stream UnParse()
            {
                return this.stream;
            }
        }

        public enum ResourceTypes : uint
        {
            LRLE = 0x2BC04EDFU,
            RLE2 = 0x3453CF95U,
            RLES = 0xBA856C78,
            DDS = 0x00B2D882,
            SKIN = 0xB6C8B6A0,
            CASP = 0x034AEECB,
            HOTC = 0x8B18FF6E
        }
    }
}
