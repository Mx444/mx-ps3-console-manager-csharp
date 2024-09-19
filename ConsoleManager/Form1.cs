using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using PS3Lib;
using System.IO;
using System.Threading;
using DevComponents;
using MetroFramework;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;

namespace ConsoleManager
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        
        public static CCAPI PS3 = new CCAPI();
        private Thread TargetInfo;
        private bool threadIsRunning = false;
        private bool currentGame = false;
        private uint[] procs;
        private Random Rand;
        public Form1()
        {
          
          
            Rand = new Random();
            TargetInfo = new Thread(new ThreadStart(InfoWorker));
            InitializeComponent();
          
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            
            string line;
            var file = new System.IO.StreamReader(@"IP.txt");
            while ((line = file.ReadLine()) != null)
            {
                listBoxControl1.Items.Add(line);

            }
      
        }
        
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            
           
               
        }
       
        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

       private void listBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }
        private void InfoWorker()
        {
            lblFW.Invoke((MethodInvoker)(() => { lblFW.Text = PS3.GetFirmwareVersion(); }));
            lblLV2.Invoke((MethodInvoker)(() => { lblLV2.Text = PS3.GetFirmwareType(); }));
            while (threadIsRunning)
            {
                string temp1 = PS3.GetTemperatureCELL();
                string temp2 = PS3.GetTemperatureRSX();
                lblCELL.Invoke((MethodInvoker)(() => { lblCELL.Text = temp1; }));
                lblRSX.Invoke((MethodInvoker)(() => { lblRSX.Text = temp2; }));
                PS3.ClearTargetInfo();
                Thread.Sleep(500);
            }
        }
        private void aaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PS3.SUCCESS(PS3.ConnectTarget(listBoxControl1.SelectedItem.ToString())))
            {
                if (!TargetInfo.IsAlive)
                {
                    threadIsRunning = true;
                    TargetInfo.Start();
                }
                label2.Text = "Active "+listBoxControl1.SelectedItem.ToString();
                PS3.RingBuzzer(CCAPI.BuzzerMode.Single);
                string Message = "Success!";
                DevExpress.XtraEditors.XtraMessageBox.Show(Message, "PS3 Connected !", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else
            {
                
                string Message = "Impossible to connect !";
                DevExpress.XtraEditors.XtraMessageBox.Show(Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
   

  

        }

        private void button2_Click(object sender, EventArgs e)
        {


            }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
 
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("https://docs.google.com/document/d/1SiK3wO1isbMltSFGOlC01tYFg487dUgmZ1lbvgy_C1k/edit");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBoxControl1.Items.Remove(listBoxControl1.SelectedItem.ToString());
            const string sPath = "IP.txt";

            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);
            foreach (var item in listBoxControl1.Items)
            {
                SaveFile.WriteLine(item);
            }
            SaveFile.Close();
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            PS3.SetConsoleID(textBox1.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            PS3.SetBootConsoleID(textBox1.Text);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            PS3.SetPSID(textBox2.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            PS3.SetBootConsoleID(textBox2.Text, CCAPI.IdType.PSID);
        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            const string sPath = "IP.txt";

            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);
            foreach (var item in listBoxControl1.Items)
            {
                SaveFile.WriteLine(item);
            }
            SaveFile.Close();
            threadIsRunning = false;
            TargetInfo.Abort();
            PS3.DisconnectTarget();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                 PS3.ShutDown(CCAPI.RebootFlags.ShutDown);
            else if (radioButton2.Checked)
                 PS3.ShutDown(CCAPI.RebootFlags.SoftReboot);
            else if (radioButton3.Checked)
                PS3.ShutDown(CCAPI.RebootFlags.HardReboot);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            CCAPI.LedColor Color = CCAPI.LedColor.Green;
            CCAPI.LedMode Mode = CCAPI.LedMode.On;

            if (radioOn.Checked)
                Mode = CCAPI.LedMode.On;
            else if (radioOff.Checked)
                Mode = CCAPI.LedMode.Off;
            else if (radioBlink.Checked)
                Mode = CCAPI.LedMode.Blink;

            if (radioGreen.Checked)
                Color = CCAPI.LedColor.Green;

            if (radioRed.Checked)
                Color = CCAPI.LedColor.Red;

            PS3.SetConsoleLed(Color, Mode);
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
                PS3.RingBuzzer(CCAPI.BuzzerMode.Single);
            else if (radioButton5.Checked)
                PS3.RingBuzzer(CCAPI.BuzzerMode.Double);
            else if (radioButton4.Checked)
                PS3.RingBuzzer(CCAPI.BuzzerMode.Continuous);
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            procs = new uint[64];
            PS3.GetProcessList(out procs);
            comboProcs.Items.Clear();
            for (int i = 0; i < procs.Length; i++)
            {
                string name = String.Empty;
                PS3.GetProcessName(procs[i], out name);
                comboProcs.Items.Add(name);
            }
            procs = null;
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            if (comboProcs.SelectedIndex >= 0 && BoxOffset.Text != "" && BoxValue.Text != "")
            {
                try
                {
                    uint processSelected = procs[comboProcs.SelectedIndex];
                    PS3.AttachProcess(processSelected);
                    uint offset = Convert.ToUInt32(BoxOffset.Text.Replace("0x", ""), 16);
                    uint value = Convert.ToUInt32(BoxValue.Text.Replace("0x", ""), 16);
                    PS3.Extension.WriteUInt32(offset, value);
                }
                catch (Exception exx)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(exx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else DevExpress.XtraEditors.XtraMessageBox.Show("Please select a process!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            PS3.Notify(comboBox1.SelectedIndex, BoxNotify.Text);
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            
           
            PS3.ResetBootConsoleID();
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            PS3.ResetBootConsoleID(CCAPI.IdType.PSID);
          
        }

        private void trackBarControl1_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
           
            if (this.trackBar1.Value == 1)
            {
                timer1.Interval = 10000;
            }
            if (this.trackBar1.Value == 2)
            {
                timer1.Interval = 50000;
            }
            if (this.trackBar1.Value == 3)
            {
                timer1.Interval = 1000000;
            }
            if (this.trackBar1.Value == 4)
            {
                timer1.Interval = 2000000;
            }
            if (this.trackBar1.Value == 5)
            {
                timer1.Interval = 3000000;
            }
        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            simpleButton13.Visible = false;
            simpleButton14.Visible = true;
            timer1.Start();
        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            simpleButton13.Visible = true;
            simpleButton14.Visible = false;
            timer1.Stop();
        }
        #region Generator
        private static class Gen
        {
            private static Random rand;

            static Gen()
            {
                Gen.rand = new Random();
            }
            public static string Part1()
            {
                return "00000001008";
            }
            public static char Part2()
            {
                char[] charArray = "58C".ToCharArray();
                int num = Gen.rand.Next((int)charArray.Length);
                return charArray[num];
            }

            public static string Part3()
            {
                return "000";
            }

            public static char Part4()
            {
                char[] charArray = "5B".ToCharArray();
                int num = Gen.rand.Next((int)charArray.Length);
                return charArray[num];
            }

            public static string Part5()
            {
                return "140";
            }
            public static char Part6()
            {
                char[] charArray = "24D60318537".ToCharArray();
                int num = Gen.rand.Next((int)charArray.Length);
                return charArray[num];
            }

            public static char Part7()
            {
                char[] charArray = "B863DE257C1".ToCharArray();
                int num = Gen.rand.Next((int)charArray.Length);
                return charArray[num];
            }

            public static char Part8()
            {
                char[] charArray = "3EA7FB596C".ToCharArray();
                int num = Gen.rand.Next((int)charArray.Length);
                return charArray[num];
            }

            public static char Part9()
            {
                char[] charArray = "D304A5C82E".ToCharArray();
                int num = Gen.rand.Next((int)charArray.Length);
                return charArray[num];
            }

            public static char Par1()
            {
                char[] charArray = "3B21CE7F".ToCharArray();
                int num = Gen.rand.Next((int)charArray.Length);
                return charArray[num];
            }

            public static char Par2()
            {
                char[] charArray = "86C4F90B12".ToCharArray();
                int num = Gen.rand.Next((int)charArray.Length);
                return charArray[num];
            }
            public static char Par3()
            {
                char[] charArray = "29CD153A67".ToCharArray();
                int num = Gen.rand.Next((int)charArray.Length);
                return charArray[num];
            }

            public static char Par4()
            {
                char[] charArray = "1A3EDB98".ToCharArray();
                int num = Gen.rand.Next((int)charArray.Length);
                return charArray[num];
            }

            public static char Par5()
            {
                char[] charArray = "480A2FB".ToCharArray();
                int num = Gen.rand.Next((int)charArray.Length);
                return charArray[num];
            }

            public static char Par6()
            {
                char[] charArray = "9F75A8BE64D".ToCharArray();
                int num = Gen.rand.Next((int)charArray.Length);
                return charArray[num];
            }

            public static char Par7()
            {
                char[] charArray = "897C1AFE".ToCharArray();
                int num = Gen.rand.Next((int)charArray.Length);
                return charArray[num];
            }

            public static char Par8()
            {
                char[] charArray = "A7FB49683C".ToCharArray();
                int num = Gen.rand.Next((int)charArray.Length);
                return charArray[num];
            }

            public static char Par9()
            {
                char[] charArray = "85362ACBFED".ToCharArray();
                int num = Gen.rand.Next((int)charArray.Length);
                return charArray[num];
            }
        }
        #endregion
        private void timer1_Tick(object sender, EventArgs e)
        {
            StringBuilder ConsoleID = new StringBuilder();
            ConsoleID.Append(Gen.Part1());
            ConsoleID.Append(Gen.Part2());
            ConsoleID.Append(Gen.Part3());
            ConsoleID.Append(Gen.Part4());
            ConsoleID.Append(Gen.Part5());
            ConsoleID.Append(Gen.Part6());
            ConsoleID.Append(Gen.Part7());
            ConsoleID.Append(Gen.Part8());
            ConsoleID.Append(Gen.Part9());
            ConsoleID.Append(Gen.Par1());
            ConsoleID.Append(Gen.Par2());
            ConsoleID.Append(Gen.Par3());
            ConsoleID.Append(Gen.Par4());
            ConsoleID.Append(Gen.Par5());
            ConsoleID.Append(Gen.Par6());
            ConsoleID.Append(Gen.Par7());
            ConsoleID.Append(Gen.Par8());
            ConsoleID.Append(Gen.Par9());
            label9.Text = ConsoleID.ToString();
            PS3.SetConsoleID(label9.Text);
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton15_Click(object sender, EventArgs e)
        {
            if (radioButton8.Checked)
                PS3.SetConsoleID("0000000100830009140F449A54F286C7");
            else if (radioButton7.Checked)
                PS3.SetConsoleID("00000001008400011001C2C271317F7F");
            else if (radioButton9.Checked)
                PS3.SetConsoleID("00000001008500091000480695854504");
            else if (radioButton14.Checked)
                PS3.SetConsoleID("00000001008600091000844D2ED12364");
            else if (radioButton16.Checked)
                PS3.SetConsoleID("000000010087000910008AEE910417B2");
            else if (radioButton18.Checked)
                PS3.SetConsoleID("00000001008800091000CBA13D2E6745");
            else if (radioButton20.Checked)
                PS3.SetConsoleID("00000001008200091000480695854504");
            else if (radioButton22.Checked)
                PS3.SetConsoleID("0000000100890009100082C039F62612");
            else if (radioButton23.Checked)
                PS3.SetConsoleID("0000000100AO00091000D2B6AF5D96AA");
            else if (radioButton17.Checked)
                PS3.SetConsoleID("000000010089000910004AEF1CEED245");
            else if (radioButton15.Checked)
                PS3.SetConsoleID("00000001008A0009100041C6F180A606");
            else if (radioButton13.Checked)
                PS3.SetConsoleID("00000001008B00091000DC45CF09640B");
            else if (RadioButton10.Checked)
                PS3.SetConsoleID("00000001008C00091000BF9AD83C74EF");
            else if (RadioButton11.Checked)
                PS3.SetConsoleID("00000001008E00091000C75F9EE4FC23");
            else if (RadioButton12.Checked)
                PS3.SetConsoleID("00000001008F00091000DDE17BB8C7F4");
            else if (radioButton19.Checked)
                PS3.SetConsoleID("000000010080000910003DF61348F706");
            else if (radioButton21.Checked)
                PS3.SetConsoleID("00000001008100091000DDFB6D5DABF5");
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton18_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton20_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton22_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton23_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton17_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadioButton10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadioButton11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadioButton12_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton19_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void radioButton21_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroTileItem1_Click(object sender, EventArgs e)
        {

        }

        private void radialMenu2_ItemClick(object sender, EventArgs e)
        {
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = (int)numericUpDown1.Value;
        }

        private void customColorBlender1_SelectedColorChanged(object sender, EventArgs e)
        {

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
          
        }

        private void listBoxControl1_MouseDown(object sender, MouseEventArgs e)
        {
            int index = listBoxControl1.IndexFromPoint(e.Location);
            listBoxControl1.SelectedIndex = index;
        }

        private void barListItem1_ListItemClick(object sender, DevExpress.XtraBars.ListItemClickEventArgs e)
        {

        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/444xMoDz");
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/DeltaMoDz?fref=ts");
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.consolehacking.net/index.php");
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/FrenchModdingTeam?fref=ts");
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listBoxControl1.Items.Add(Microsoft.VisualBasic.Interaction.InputBox("Enter your IP:", "Console IP", ""));
        }
         

        private void simpleButton16_Click(object sender, EventArgs e)
        {
       

       
    }

        private void button1_Click_2(object sender, EventArgs e)
        {
          
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
          

        }
    }
}