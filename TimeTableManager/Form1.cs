using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TimeTableManager.TimeTableContext;

namespace TimeTableManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (var db = new TimeTableContext())
            {
                var add = textBox1.Text;
                if (add == "")
                    return;

                var task = new Task { Name = add };
                db.Tasks.Add(task);
                db.SaveChanges();
                this.tasksTableAdapter.Fill(this._TimeTable_mdfDataSet.Tasks);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_TimeTable_mdfDataSet.Tasks' table. You can move, or remove it, as needed.
            this.tasksTableAdapter.Fill(this._TimeTable_mdfDataSet.Tasks);
            // TODO: This line of code loads data into the '_TimeTable_mdfDataSet.Tasks' table. You can move, or remove it, as needed.
            this.tasksTableAdapter.Fill(this._TimeTable_mdfDataSet.Tasks);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var db = new TimeTableContext())
            {
                var add = dataGridView1.SelectedCells[0].Value.ToString();
                if (add == "")
                    return;

                var find = db.Tasks.FirstOrDefault(x => x.Name == add);
                if (find == null)
                    return;

                db.Tasks.Remove(find);
                db.SaveChanges();
                this.tasksTableAdapter.Fill(this._TimeTable_mdfDataSet.Tasks);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var db = new TimeTableContext())
            {
                var add = dataGridView1.SelectedCells[0].Value.ToString();
                if (add == "")
                    return;

                var find = db.Tasks.FirstOrDefault(x => x.Name == add);
                if (find == null)
                    return;

                var rename = textBox2.Text;
                if (rename == "")
                    return;

                find.Name = rename;                
                db.SaveChanges();

                this.tasksTableAdapter.Fill(this._TimeTable_mdfDataSet.Tasks);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var db = new TimeTableContext())
            {
                var add = dataGridView1.SelectedCells[0].Value.ToString();
                if (add == "")
                    return;

                var find = db.Tasks.FirstOrDefault(x => x.Name == add);
                if (find == null)
                    return;
                
                if (find.Level != null && find.Level < 4)
                    find.Level++;
                else
                    find.Level = 0;

                db.SaveChanges();

                this.tasksTableAdapter.Fill(this._TimeTable_mdfDataSet.Tasks);
            }
        }
    }
}
