using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //List<Court> c = new List<Court>();
            //using (var db = new DatabaseContext())
            //{
            //    //db.Courts.Add(new Court(){});


            //    db.SaveChanges();
            //    //c = db.Courts.Where(x => x.CourtId >= 3).ToList();
            //    //Make function to add database entries elsewhere... In Add_Customer class? Add_Coach?
            //}



                Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
        }
    }
}
