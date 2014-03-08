using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormSomeButtonOneCell
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            dataGridView1.CellClick += new DataGridViewCellEventHandler(grid_CellClick);
            dataGridView1.Paint += new PaintEventHandler(dataGridView1_Paint);
            dataGridView1.MouseMove += new MouseEventHandler(dataGridView1_MouseMove);

            BindData();
        }

        void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.DataGridView.HitTestInfo hit = this.dataGridView1.HitTest(e.X, e.Y);
            int x = hit.ColumnX;
            int y = hit.RowY;

            MousePointHelper.SetLocation(x, y, e.X, e.Y);

            if (MousePointHelper.GetOption > 0)
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            if (this.dataGridView1.Columns[e.ColumnIndex].HeaderText != "Options")
            {
                return;
            }

            switch (MousePointHelper.GetOption)
            {
                case 1:
                    MessageBox.Show("China", "Title");
                    break;
                case 2:
                    MessageBox.Show("Eims", "Title");
                    break;
                case 3:
                    MessageBox.Show("YANG", "Title");
                    break;
                case 4:
                    MessageBox.Show("JiuJiang", "Title");
                    break;
                case 5:
                    MessageBox.Show("China", "Title");
                    break;
            }
        }

        void BindData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Value", typeof(string)));
            dt.Columns.Add(new DataColumn("Options", typeof(string)));

            string optionCol = "China Eims  YANG  JiuJiang";

            DataRow dr = dt.NewRow();
            dr["Name"] = "Home";
            dr["Value"] = "jxjj";
            dr["Options"] = optionCol;
            dt.Rows.Add(dr);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dt.AcceptChanges();
            this.dataGridView1.DataSource = dt;

            DataGridViewCheckBoxColumn selected = new DataGridViewCheckBoxColumn();
            selected.HeaderText = " ";
            selected.Name = "Check";
            selected.Width = 35;
            dataGridView1.Columns.Add(selected);
            selected.Visible = true;

            DataGridViewTextBoxColumn c0 = new DataGridViewTextBoxColumn();
            c0.Name = "Id";
            c0.HeaderText = "Id";
            c0.DataPropertyName = "Id";
            c0.Width = 40;
            c0.ReadOnly = true;
            c0.Resizable = DataGridViewTriState.True;
            dataGridView1.Columns.Add(c0);

            DataGridViewTextBoxColumn c1 = new DataGridViewTextBoxColumn();
            c1.Name = "Name";
            c1.HeaderText = "Name";
            c1.DataPropertyName = "Name";
            c1.Width = 100;
            c1.ReadOnly = false;
            dataGridView1.Columns.Add(c1);

            DataGridViewTextBoxColumn c5 = new DataGridViewTextBoxColumn();
            c5.Name = "Value";
            c5.HeaderText = "Value";
            c5.DataPropertyName = "Value";
            c5.Width = 100;
            c5.ReadOnly = false;
            dataGridView1.Columns.Add(c5);

            DataGridViewTextBoxColumn c6 = new DataGridViewTextBoxColumn();
            c6.Name = "Options";
            c6.HeaderText = "Options";
            c6.DataPropertyName = "Options";
            c6.Width = 196;
            c6.CellTemplate.Selected = false;
            c6.ReadOnly = true;
            c6.CellTemplate.Style.ForeColor = ColorTranslator.FromHtml("#004E98");
            c6.Resizable = DataGridViewTriState.False;
            dataGridView1.Columns.Add(c6);
        }
    }

    public class MousePointHelper
    {
        private static int x = 0;
        private static int y = 0;

        private static int xblank, yblank, xcurrent, ycurrent;

        public static void SetLocation(int x_blank, int y_blank, int x_current, int y_current)
        {
            xblank = x_blank; yblank = y_blank; xcurrent = x_current; ycurrent = y_current;
        }

        //Current X Value
        private static int X
        {
            get
            {
                return xcurrent - xblank;
            }
        }

        //Current Y Value
        private static int Y
        {
            get
            {
                return ycurrent - yblank;
            }
        }


        /// <summary>
        /// GetCommand
        /// </summary>
        public static int GetOption
        {
            get
            {
                if (Y >= 21 && Y <= 31)
                {
                    if (X > 3 && X < 29 && Y < 36)
                    {
                        return 1;
                    }
                    else if (X > 40 && X < 64)
                    {
                        return 2;
                    }
                    else if (X > 74 && X < 98)
                    {
                        return 3;
                    }
                    else if (X > 110 && X < 158)
                    {
                        return 4;
                    }
                    else if (Y >= 21 && Y <= 31 && X >= 172 && X <= 194)
                    {
                        return 5;
                    }
                }

                return 0;
            }
        }
    }
}
