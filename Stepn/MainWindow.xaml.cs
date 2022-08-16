using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using LiveCharts;
using LiveCharts.Wpf;
using Newtonsoft.Json;

namespace Stepn
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            int fCount = Directory.GetFiles("TestData", "*.json", SearchOption.TopDirectoryOnly).Length;

            var personStats = new Dictionary<string, PersonStats>();
            for (int i = 1; i <= fCount; i++)
            {
                var stats = JsonConvert.DeserializeObject<Stats[]>(File.ReadAllText($"TestData/day{i}.json"));
                foreach (var item in stats)
                {
                    if (personStats.ContainsKey(item.User))
                    {
                        personStats[item.User].DayliStats.Add(new Dayli(item.Rank, item.Status, item.Steps));
                    }
                    else
                    {
                        personStats.Add(item.User, new PersonStats()
                        {
                            DayliStats = new List<Dayli>()
                            {
                                new Dayli(item.Rank, item.Status, item.Steps)
                            }
                        });
                    }
                }
            }
            foreach (var item in personStats)
            {
                DataGridXAML.Items.Add(item);
                //if(item.Value.averageStepsForAllPeriod < item.Value.bestResultForAllPeriod)
                //{
                //    DataGridXAML.RowStyle.Setters
            }

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Values = new ChartValues<int> { },
                    LineSmoothness = 1,
                    PointGeometrySize = 10

                },
            };
            DataContext = this;                  
        }
        
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
        

        private void DataGridXAML_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            DataGrid dg = (DataGrid)sender;
            dynamic rw = dg.SelectedItem ;
            SeriesCollection[0].Values.Clear();  // очистка графика
            
            for (int i = 0; i < rw.Value.DayliStats.Count; i++)
            {
                 SeriesCollection[0].Values.Add((int)rw.Value.DayliStats[i].Steps);
            }
            Labels = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11","12", "13", "14", "15",
                "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30" };
            YFormatter = value => value.ToString("N");
            
            AxisY.MinValue = rw.Value.worseResoultForAllPeriod;
            AxisY.MaxValue = rw.Value.bestResultForAllPeriod;
            DataContext = this;
        }

    }
}
