using System;
using System.Collections.Generic;
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

namespace WPFRegisterStudent
{
    
    public partial class MainWindow : Window
    {
        Course choice;
        private int totalCredit = 0;

        public MainWindow()
        {

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Course course1 = new Course("IT 145");
            Course course2 = new Course("IT 200");
            Course course3 = new Course("IT 201");
            Course course4 = new Course("IT 270");
            Course course5 = new Course("IT 315");
            Course course6 = new Course("IT 328");
            Course course7 = new Course("IT 330");


            this.comboBox.Items.Add(course1);
            this.comboBox.Items.Add(course2);
            this.comboBox.Items.Add(course3);
            this.comboBox.Items.Add(course4);
            this.comboBox.Items.Add(course5);
            this.comboBox.Items.Add(course6);
            this.comboBox.Items.Add(course7);


            this.textBox.Text = "";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //Placed the code in a try statement block
            try
            {
                choice = (Course)(this.comboBox.SelectedItem);
                //Message if student clicks button before selection
                if (null == choice)
                {
                    label3.Content = "Please make a selection";
                    return;
                }
                //Makes sure the student cant register for more than 9 credit hours
                if (totalCredit >= 9)
                {
                    label3.Content = "You can not register for more than 9 credit hours";
                    return;
                }
                //else statement contains the process of student registering, detecting repeated entries
                //and confirming the registration for the selected course
                else
                {
                    var isarepeat = false;
                    foreach (var item in this.listBox.Items)
                    {
                        var courseItem = item as Course;
                        if (null != courseItem)
                        {
                            if (courseItem.ToString() == choice.ToString())
                            {
                                isarepeat = true;
                            }
                        }
                    }
                    if (isarepeat)
                    {
                        label3.Content = "You are Already Registered for Course " + choice;
                    }
                    else
                    {
                        this.listBox.Items.Add(choice);
                        totalCredit = totalCredit + 3;
                        textBox.Text = totalCredit.ToString();
                        label3.Content = "Registration Confirmed for Course " + choice;
                    }
                }
            }
            //End of Try Block
            //Catches All Exceptions
            catch (Exception exception)
            {
                label3.Content = exception.Message;
            }

       
        }
    }
}
