using Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Calendar : Form
    {
        Logging f = new Logging();
        public string chosenDate;
        public Calendar()
        {
            //f.Show();
            InitializeComponent();
        }
        
        //sets the cell to a match if match is there
        public void UpdateCalendar()
        {
            List<Match> matches = new List<Match>();
            List<Player> players = new List<Player>();
            List<Coach> coaches = new List<Coach>();


            using (var db = new DatabaseContext())
            {
                matches = db.Matches.ToList();
                players = db.Players.ToList();
                coaches = db.Coach.ToList();

                foreach (var court in db.Courts)
                {
                    if (court.Matches != null)
                    {
                        if (court.Matches.Count != 0)
                        {
                            matches.AddRange(court.Matches);
                        }
                    }
                }
            }

            //List<string> coachesColors = coaches.Select(x => x.CoachColor).ToList();
            //foreach (var newCoach in coachesColors)
            //{
            //    //coachColor = newCoach.ToString().Split('[', ']');
            //    coachColorString = coachColor[0];
            //}
            foreach (var ma in matches)
            {
                CellID c = GetCellByMatch(ma);
                //coachColor[] = co.CoachColor.Split(':');
                //{
                //        for (int i = 0; i < matches.Count(); i++)
                //        {
                //            if (co.CoachID == ma.PlayerList[i].playerId)
                //            {

                //co.player.playerId = ma.PlayerList.Any( // if statement is true, get RGB from coach
                if (ma.CoachInMatch != null)
                {
                    if (ma.CoachInMatch.player != null)
                    {
                        dataGridView1.Rows[c.Row].Cells[c.Column].Style.ForeColor = Color.White;
                        dataGridView1.Rows[c.Row].Cells[c.Column].DataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        dataGridView1.Rows[c.Row].Cells[c.Column].DataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
                        dataGridView1.Rows[c.Row].Cells[c.Column].DataGridView.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 9.25F, System.Drawing.FontStyle.Bold);
                        dataGridView1.Rows[c.Row].Cells[c.Column].Value = ma.CoachInMatch.player.Firstname + Environment.NewLine + ma.AdditionalInformation;
                        this.dataGridView1.Rows[c.Row].Cells[c.Column].Style.BackColor = Color.FromArgb(ma.CoachInMatch.CoachRed, ma.CoachInMatch.CoachGreen, ma.CoachInMatch.CoachBlue);
                    }

                }
                else if (ma.PlayerList != null)
                {
                    if (ma.PlayerList.Count == 2)
                    {
                        dataGridView1.Rows[c.Row].Cells[c.Column].Value = ma.PlayerList[0].Firstname + " " + ma.PlayerList[0].Lastname + Environment.NewLine + ma.PlayerList[1].Firstname + " " + ma.PlayerList[1].Lastname + Environment.NewLine + ma.AdditionalInformation; ;
                    }
                    if (ma.PlayerList.Count == 3)
                    {
                        dataGridView1.Rows[c.Row].Cells[c.Column].Value = ma.PlayerList[0].Firstname  + " " + ma.PlayerList[0].Lastname + Environment.NewLine + ma.PlayerList[1].Firstname + " " + ma.PlayerList[1].Lastname + Environment.NewLine + ma.PlayerList[2].Firstname + ma.PlayerList[2].Lastname + Environment.NewLine + ma.AdditionalInformation; ;
                    }
                    if (ma.PlayerList.Count == 4)
                    {
                        dataGridView1.Rows[c.Row].Cells[c.Column].Value = ma.PlayerList[0].Firstname + " " + ma.PlayerList[0].Lastname+ Environment.NewLine + ma.PlayerList[1].Firstname + " " + ma.PlayerList[1].Lastname + Environment.NewLine + ma.PlayerList[2].Firstname + " " + ma.PlayerList[2].Lastname + Environment.NewLine + ma.PlayerList[3].Firstname + " " + ma.PlayerList[3].Lastname + Environment.NewLine + ma.AdditionalInformation; 
                    }
                    this.dataGridView1.Rows[c.Row].Cells[c.Column].Style.ForeColor = Color.Black;
                    this.dataGridView1.Rows[c.Row].Cells[c.Column].Style.BackColor = Color.Black;

                }
            }
            //if (ma.PlayerList != null)
            //    if (ma.PlayerList.Any(x => x.playerId == co.player.playerId))
            //    {
            //        dataGridView1.Rows[c.Row].Cells[c.Column].Value = co.player.Firstname;
            //    }
            //    else
            //    {
            //        //MessageBox.Show("not found");
            //    }
            //


        }


        private CellID GetCellByMatch(Match m)
        {
            CellID cell = new CellID();



            switch (m.dayOfWeek)
            {
                case "Monday":
                    {
                        switch (m.Court.CourtNumber)
                        {
                            case 1:
                                {
                                    cell.Column = 1;
                                    break;
                                }
                            case 2:
                                {
                                    cell.Column = 2;
                                    break;
                                }
                            case 3:
                                {
                                    cell.Column = 3;
                                    break;
                                }
                            case 4:
                                {
                                    cell.Column = 4;
                                    break;
                                }
                        }
                        switch (m.TimeOfDay)
                        {
                            case 9:
                                {
                                    cell.Row = 0;
                                    break;
                                }
                            case 10:
                                {
                                    cell.Row = 1;
                                    break;
                                }
                            case 11:
                                {
                                    cell.Row = 2;
                                    break;
                                }
                            case 12:
                                {
                                    cell.Row = 3;
                                    break;
                                }
                            case 13:
                                {
                                    cell.Row = 4;
                                    break;
                                }
                            case 14:
                                {
                                    cell.Row = 5;
                                    break;
                                }
                            case 15:
                                {
                                    cell.Row = 6;
                                    break;
                                }
                            case 16:
                                {
                                    cell.Row = 7;
                                    break;
                                }
                            case 17:
                                {
                                    cell.Row = 8;
                                    break;
                                }
                            case 18:
                                {
                                    cell.Row = 9;
                                    break;
                                }
                            case 19:
                                {
                                    cell.Row = 10;
                                    break;
                                }
                            case 20:
                                {
                                    cell.Row = 11;
                                    break;
                                }
                            case 21:
                                {
                                    cell.Row = 12;
                                    break;
                                }
                        }
                        break;
                    }
                case "Tuesday":
                    {
                        switch (m.Court.CourtNumber)
                        {
                            case 1:
                                {
                                    cell.Column = 6;
                                    break;
                                }
                            case 2:
                                {
                                    cell.Column = 7;
                                    break;
                                }
                            case 3:
                                {
                                    cell.Column = 8;
                                    break;
                                }
                            case 4:
                                {
                                    cell.Column = 9;
                                    break;
                                }
                        }
                        switch (m.TimeOfDay)
                        {
                            case 9:
                                {
                                    cell.Row = 0;
                                    break;
                                }
                            case 10:
                                {
                                    cell.Row = 1;
                                    break;
                                }
                            case 11:
                                {
                                    cell.Row = 2;
                                    break;
                                }
                            case 12:
                                {
                                    cell.Row = 3;
                                    break;
                                }
                            case 13:
                                {
                                    cell.Row = 4;
                                    break;
                                }
                            case 14:
                                {
                                    cell.Row = 5;
                                    break;
                                }
                            case 15:
                                {
                                    cell.Row = 6;
                                    break;
                                }
                            case 16:
                                {
                                    cell.Row = 7;
                                    break;
                                }
                            case 17:
                                {
                                    cell.Row = 8;
                                    break;
                                }
                            case 18:
                                {
                                    cell.Row = 9;
                                    break;
                                }
                            case 19:
                                {
                                    cell.Row = 10;
                                    break;
                                }
                            case 20:
                                {
                                    cell.Row = 11;
                                    break;
                                }
                            case 21:
                                {
                                    cell.Row = 12;
                                    break;
                                }
                        }
                        break;
                    }
                case "Wednesday":
                    {
                        switch (m.Court.CourtNumber)
                        {
                            case 1:
                                {
                                    cell.Column = 11;
                                    break;
                                }
                            case 2:
                                {
                                    cell.Column = 12;
                                    break;
                                }
                            case 3:
                                {
                                    cell.Column = 13;
                                    break;
                                }
                            case 4:
                                {
                                    cell.Column = 14;
                                    break;
                                }
                        }
                        switch (m.TimeOfDay)
                        {
                            case 9:
                                {
                                    cell.Row = 0;
                                    break;
                                }
                            case 10:
                                {
                                    cell.Row = 1;
                                    break;
                                }
                            case 11:
                                {
                                    cell.Row = 2;
                                    break;
                                }
                            case 12:
                                {
                                    cell.Row = 3;
                                    break;
                                }
                            case 13:
                                {
                                    cell.Row = 4;
                                    break;
                                }
                            case 14:
                                {
                                    cell.Row = 5;
                                    break;
                                }
                            case 15:
                                {
                                    cell.Row = 6;
                                    break;
                                }
                            case 16:
                                {
                                    cell.Row = 7;
                                    break;
                                }
                            case 17:
                                {
                                    cell.Row = 8;
                                    break;
                                }
                            case 18:
                                {
                                    cell.Row = 9;
                                    break;
                                }
                            case 19:
                                {
                                    cell.Row = 10;
                                    break;
                                }
                            case 20:
                                {
                                    cell.Row = 11;
                                    break;
                                }
                            case 21:
                                {
                                    cell.Row = 12;
                                    break;
                                }
                        }
                        break;
                    }
                case "Thursday":
                    {
                        switch (m.Court.CourtNumber)
                        {
                            case 1:
                                {
                                    cell.Column = 16;
                                    break;
                                }
                            case 2:
                                {
                                    cell.Column = 17;
                                    break;
                                }
                            case 3:
                                {
                                    cell.Column = 18;
                                    break;
                                }
                            case 4:
                                {
                                    cell.Column = 19;
                                    break;
                                }
                        }
                        switch (m.TimeOfDay)
                        {
                            case 9:
                                {
                                    cell.Row = 0;
                                    break;
                                }
                            case 10:
                                {
                                    cell.Row = 1;
                                    break;
                                }
                            case 11:
                                {
                                    cell.Row = 2;
                                    break;
                                }
                            case 12:
                                {
                                    cell.Row = 3;
                                    break;
                                }
                            case 13:
                                {
                                    cell.Row = 4;
                                    break;
                                }
                            case 14:
                                {
                                    cell.Row = 5;
                                    break;
                                }
                            case 15:
                                {
                                    cell.Row = 6;
                                    break;
                                }
                            case 16:
                                {
                                    cell.Row = 7;
                                    break;
                                }
                            case 17:
                                {
                                    cell.Row = 8;
                                    break;
                                }
                            case 18:
                                {
                                    cell.Row = 9;
                                    break;
                                }
                            case 19:
                                {
                                    cell.Row = 10;
                                    break;
                                }
                            case 20:
                                {
                                    cell.Row = 11;
                                    break;
                                }
                            case 21:
                                {
                                    cell.Row = 12;
                                    break;
                                }
                        }
                        break;
                    }
                case "Friday":
                    {
                        switch (m.Court.CourtNumber)
                        {
                            case 1:
                                {
                                    cell.Column = 21;
                                    break;
                                }
                            case 2:
                                {
                                    cell.Column = 22;
                                    break;
                                }
                            case 3:
                                {
                                    cell.Column = 23;
                                    break;
                                }
                            case 4:
                                {
                                    cell.Column = 24;
                                    break;
                                }
                        }
                        switch (m.TimeOfDay)
                        {
                            case 9:
                                {
                                    cell.Row = 0;
                                    break;
                                }
                            case 10:
                                {
                                    cell.Row = 1;
                                    break;
                                }
                            case 11:
                                {
                                    cell.Row = 2;
                                    break;
                                }
                            case 12:
                                {
                                    cell.Row = 3;
                                    break;
                                }
                            case 13:
                                {
                                    cell.Row = 4;
                                    break;
                                }
                            case 14:
                                {
                                    cell.Row = 5;
                                    break;
                                }
                            case 15:
                                {
                                    cell.Row = 6;
                                    break;
                                }
                            case 16:
                                {
                                    cell.Row = 7;
                                    break;
                                }
                            case 17:
                                {
                                    cell.Row = 8;
                                    break;
                                }
                            case 18:
                                {
                                    cell.Row = 9;
                                    break;
                                }
                            case 19:
                                {
                                    cell.Row = 10;
                                    break;
                                }
                            case 20:
                                {
                                    cell.Row = 11;
                                    break;
                                }
                            case 21:
                                {
                                    cell.Row = 12;
                                    break;
                                }
                        }
                        break;
                    }
                case "Saturday":
                    {
                        switch (m.Court.CourtNumber)
                        {
                            case 1:
                                {
                                    cell.Column = 26;
                                    break;
                                }
                            case 2:
                                {
                                    cell.Column = 27;
                                    break;
                                }
                            case 3:
                                {
                                    cell.Column = 28;
                                    break;
                                }
                            case 4:
                                {
                                    cell.Column = 29;
                                    break;
                                }
                        }
                        switch (m.TimeOfDay)
                        {
                            case 9:
                                {
                                    cell.Row = 0;
                                    break;
                                }
                            case 10:
                                {
                                    cell.Row = 1;
                                    break;
                                }
                            case 11:
                                {
                                    cell.Row = 2;
                                    break;
                                }
                            case 12:
                                {
                                    cell.Row = 3;
                                    break;
                                }
                            case 13:
                                {
                                    cell.Row = 4;
                                    break;
                                }
                            case 14:
                                {
                                    cell.Row = 5;
                                    break;
                                }
                            case 15:
                                {
                                    cell.Row = 6;
                                    break;
                                }
                            case 16:
                                {
                                    cell.Row = 7;
                                    break;
                                }
                            case 17:
                                {
                                    cell.Row = 8;
                                    break;
                                }
                            case 18:
                                {
                                    cell.Row = 9;
                                    break;
                                }
                            case 19:
                                {
                                    cell.Row = 10;
                                    break;
                                }
                            case 20:
                                {
                                    cell.Row = 11;
                                    break;
                                }
                            case 21:
                                {
                                    cell.Row = 12;
                                    break;
                                }
                        }
                        break;
                    }
                case "Sunday":
                    {
                        switch (m.Court.CourtNumber)
                        {
                            case 1:
                                {
                                    cell.Column = 31;
                                    break;
                                }
                            case 2:
                                {
                                    cell.Column = 32;
                                    break;
                                }
                            case 3:
                                {
                                    cell.Column = 33;
                                    break;
                                }
                            case 4:
                                {
                                    cell.Column = 34;
                                    break;
                                }
                        }
                        switch (m.TimeOfDay)
                        {
                            case 9:
                                {
                                    cell.Row = 0;
                                    break;
                                }
                            case 10:
                                {
                                    cell.Row = 1;
                                    break;
                                }
                            case 11:
                                {
                                    cell.Row = 2;
                                    break;
                                }
                            case 12:
                                {
                                    cell.Row = 3;
                                    break;
                                }
                            case 13:
                                {
                                    cell.Row = 4;
                                    break;
                                }
                            case 14:
                                {
                                    cell.Row = 5;
                                    break;
                                }
                            case 15:
                                {
                                    cell.Row = 6;
                                    break;
                                }
                            case 16:
                                {
                                    cell.Row = 7;
                                    break;
                                }
                            case 17:
                                {
                                    cell.Row = 8;
                                    break;
                                }
                            case 18:
                                {
                                    cell.Row = 9;
                                    break;
                                }
                            case 19:
                                {
                                    cell.Row = 10;
                                    break;
                                }
                            case 20:
                                {
                                    cell.Row = 11;
                                    break;
                                }
                            case 21:
                                {
                                    cell.Row = 12;
                                    break;
                                }
                        }
                        break;

                    }
            }
            return cell;
        }
        class CellID
        {
            public int Row { get; set; }
            public int Column { get; set; }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.dataGridView1.Rows.Add("9am");
            this.dataGridView1.Rows.Add("10am");
            this.dataGridView1.Rows.Add("11am");
            this.dataGridView1.Rows.Add("12am");
            this.dataGridView1.Rows.Add("1pm");
            this.dataGridView1.Rows.Add("2pm");
            this.dataGridView1.Rows.Add("3pm");
            this.dataGridView1.Rows.Add("4pm");
            this.dataGridView1.Rows.Add("5pm");
            this.dataGridView1.Rows.Add("6pm");
            this.dataGridView1.Rows.Add("7pm");
            this.dataGridView1.Rows.Add("8pm");
            this.dataGridView1.Rows.Add("9pm");
        }


        //    return (DataGridViewCell)o;
        //}

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewTextBoxCell cell = (DataGridViewTextBoxCell)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

            cell.Value = "x";

        }

        private void colourCoordination()
        {
            for (int rows = 0; rows < dataGridView1.Rows.Count; rows++)
            {
                for (int col = 0; col < dataGridView1.Rows[rows].Cells.Count; col++)
                {
                    string value = dataGridView1.Rows[rows].Cells[col].Value.ToString();
                    switch (value)
                    {
                        case "Ed Allinson":
                            break;
                        case "Lewis Fisher":
                            break;
                        case "Faye Button":
                            break;
                        case "Phil Nicholson":
                            break;
                        case "Matt Boothby":
                            break;
                        case "Joe Allinson":
                            break;
                        case "Alex Davies":
                            break;
                        case "Morgan Vickers":
                            break;
                        case "Kathryn Morris":
                            break;
                        case "Ruth East":
                            break;
                        default:
                            //transparent/no colour
                            break;
                    }
                }
            }
        }

        private void UIUpdater_Tick(object sender, EventArgs e)
        {
            UpdateCalendar();
        }
    }
}
