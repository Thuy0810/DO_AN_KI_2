﻿using System;
using System.Windows.Forms;

namespace DO_AN_KI_2
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            SignUP sign = new SignUP();
            sign.ShowDialog();
            if (sign.isLogin)
            {
                Application.Run(new Form1());
            }
        }
    }
}
