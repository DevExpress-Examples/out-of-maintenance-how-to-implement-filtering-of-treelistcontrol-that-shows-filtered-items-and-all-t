using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Grid;
using System.Collections.ObjectModel;
using DevExpress.Data.Filtering.Helpers;
using System.ComponentModel;

namespace DXSample {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            List<TestData> list = new List<TestData>();
            for(int i = 0; i < 20; i++) {
                list.Add(new TestData(i) { ParentId = 2 });
            }
            list[4].ParentId = -1;
            list[5].ParentId = 4;
            list[6].ParentId = 4;
            list[7].ParentId = 4;
            treeList.ItemsSource = list;
        }
    }

    public class TestData {
        public int KeyId { get; set; }
        public int ParentId { get; set; }
        public int Number { get; set; }
        public string Text { get; set; }
        public bool Bool { get; set; }
        public TestData(int i) {
            Number = i;
            KeyId = i;
            Text = "Row" + i;
            Bool = i % 3 != 0;
        }
    }
}
