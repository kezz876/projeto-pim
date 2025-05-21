using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PIM_3.Forms;
using PIM_3.model;

namespace PIM_3
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            List<Livros> livros = new();
            Admin admin = new Admin { Nome = "admin", Senha = "1234" };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm(admin, livros));
        }
    }
}
