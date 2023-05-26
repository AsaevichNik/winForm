using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryForApliedMathService;
using System.Reflection;
using Microsoft.VisualBasic.ApplicationServices;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        private Point moveStart;

        private static String filename;
        private String graph;
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.White;
            


            this.Load += WindowOfService_Load;
            this.MouseDown += WindowOfService_MouseDown;
            this.MouseMove += WindowOfService_MouseMove;
        }

        public static string getFilename()
        {
            return filename;
        }

        private void WindowOfService_Load(object sender, EventArgs e)
        {

        }

        private void WindowOfService_MouseDown(object sender, MouseEventArgs e)
        {
            // если нажата левая кнопка мыши
            if (e.Button == MouseButtons.Left)
            {
                moveStart = new Point(e.X, e.Y);
            }
        }

        private void WindowOfService_MouseMove(object sender, MouseEventArgs e)
        {
            // если нажата левая кнопка мыши
            if ((e.Button & MouseButtons.Left) != 0)
            {
                // получаем новую точку положения формы
                Point deltaPos = new Point(e.X - moveStart.X, e.Y - moveStart.Y);
                // устанавливаем положение формы
                this.Location = new Point(this.Location.X + deltaPos.X,
                  this.Location.Y + deltaPos.Y);
            }
        }



        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                String fileInfo = File.ReadAllText("C:\\Users\\Nikita\\source\\repos\\SippoLabs\\WinFormsApp2\\output.txt");
                MessageBox.Show(fileInfo);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.FileName);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(GraphAlgoritm.BellmanFord));
            thread.Start(filename);
            button4.Hide();
            Thread.Sleep(1000);
            thread.Join();
            button4.Show();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                LibraryForApliedMathService.GraphAlgoritm.BellmanFord(filename);
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo = new System.Diagnostics.ProcessStartInfo("notepad");
            process.Start();
            process.WaitForExit();
        }

        private void запуститьПрограммуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click_1(sender, e);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new Exception("Filename is dishonored");
            }
            try
            {
                graph = textBox2.Text;
                File.WriteAllText(filename, graph);
            }
            catch
            {
                Console.WriteLine("Wrong file path");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            filename = textBox4.Text;
            //C:\\Users\\Nikita\\source\\repos\\SippoLabs\\WinFormsApp2\\input.txt
        }
    }
}