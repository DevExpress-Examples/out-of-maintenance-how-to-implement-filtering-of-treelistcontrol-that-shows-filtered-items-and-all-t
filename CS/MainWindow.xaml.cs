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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
            Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e) {
            CleanNodesList();
        }

        bool isFirst = true;
        List<TreeListNode> nodesList = new List<TreeListNode>();
        private void TreeListView_CustomNodeFilter(object sender, DevExpress.Xpf.Grid.TreeList.TreeListNodeFilterEventArgs e) {
            TreeListView view = sender as TreeListView;
            if(isFirst) {
                ExpressionEvaluator ee = new ExpressionEvaluator(TypeDescriptor.GetProperties(typeof(TestData)), view.DataControl.FilterCriteria);
                foreach(TreeListNode node in new TreeListNodeIterator(view.Nodes)) {
                    if(ee.Fit(node.Content))
                        nodesList.Add(node);
                }
                isFirst = false;
            }
            if(e.Node.HasChildren) {
                foreach(TreeListNode node in nodesList) {
                    if(node.IsDescendantOf(e.Node)) {
                        e.Visible = true;
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        private void treeList_FilterChanged(object sender, RoutedEventArgs e) {
            CleanNodesList();
        }
        
        void CleanNodesList() {
            isFirst = true;
            nodesList.Clear();
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
