using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace nolja
{
    public class Nickname : INotifyPropertyChanged
    {
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        void Notify(string propName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        string name;
        string nick;

        public string Name
        {
            get { return this.name; }
            set { this.name = value;
                Notify("Name");
            }
        }
        public string Nick
        {
            get { return this.nick; }
            set
            {
                this.nick = value;
                Notify("Nick");
            }
        }

        public Nickname() : this("name", "nick") { }
        public Nickname(string na, string ni)
        {
            this.name = na;
            this.nick = ni;
        }
    }

    public class Nicknames : System.Collections.ObjectModel.ObservableCollection<Nickname> { }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Nicknames names;

        public MainWindow()
        {
            InitializeComponent();
            this.btnAdd.Click += btnAdd_Click;

            this.names = new Nicknames();

            sPanel.DataContext = this.names;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            this.names.Add(new Nickname());
        }
    }
}
