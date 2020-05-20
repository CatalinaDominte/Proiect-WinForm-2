using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form_Chart : Form
    {
        public Form_Chart()
        {
            InitializeComponent();
        }

        private void elementHost1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        Func<ChartPoint, string> label = chartpoint => string.Format("{0} ({1:P}", chartpoint.Y, chartpoint.Participation);
        private void button1_Click(object sender, EventArgs e)
        {
            using (DBWinFormEntities Db = new DBWinFormEntities())
            {
                SeriesCollection series = new SeriesCollection();
                foreach (var item in Db.Angajats)
                {
                    series.Add(new PieSeries() { Title = item.Name.ToString(), Values = new ChartValues<int> { item.Vanzari }, DataLabels = true, LabelPoint = label });
                    pieChart1.Series = series;
                }
            }
        }
        private void Chart_Load(object sender, EventArgs e)
        {
            pieChart1.LegendLocation = LegendLocation.Left;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
