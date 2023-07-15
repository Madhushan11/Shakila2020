using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shakila2020.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Shakila2020
{
    public  partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public  ObservableCollection<User> users;
        [ObservableProperty]
        public User selectedUser=null;



        public void CloseMainWindow()
        {
            Application.Current.MainWindow.Close();
        }




        [RelayCommand]
        public void messeag()
        {

            MessageBox.Show(" GPA value must be between 0 and 4.", "Error");
        }

        [RelayCommand]
        public void AddUser()
        {
            var vm = new AddUserVM();
            vm.title = "ADD USER";
            AddUserWindow window = new AddUserWindow(vm);
            
            window.ShowDialog();

            if (vm.Student != null)
            {
                if (vm != null && vm.Student !=null && vm.Student.FirstName != null)
                {
                    users.Add(vm.Student);
                }
                else
                {
                    MessageBox.Show("First name cannot be empty.", "Error");
                }
            }

            else
            {
                MessageBox.Show("First name cannot be empty.", "Error");
            }
          
        }

        [RelayCommand]
        public void DeleteUser(object obj)
        {
            if(obj is User u)
            {
               
                users.Remove(u);
                MessageBox.Show("Deleted Student");

            }
            
            /*if (selectedUser != null)
            {
                string name = selectedUser.FirstName;
                users.Remove(selectedUser);
                MessageBox.Show($"{name} is Deleted successfuly.", "DELETED \a ");
                
            }
            else
            {
                MessageBox.Show("Plese Select Student before Delete.", "Error");


            }*/
        }
        [RelayCommand]
        public void EditUser()
        {
            if (selectedUser != null)
            {
                var vm = new AddUserVM(selectedUser);
                vm.title = "EDIT USER";
                var window = new AddUserWindow(vm);

                window.ShowDialog();


                int index = users.IndexOf(selectedUser);
                users.RemoveAt(index);
                users.Insert(index, vm.Student);



            }
            else
            {
                MessageBox.Show("Please Select the student", "Warning!");
            }
        }

        public  MainWindowVM()
        {
            users = new ObservableCollection<User>();
            BitmapImage image1 = new BitmapImage(new Uri("/Model/Images/1.png", UriKind.Relative));
            users.Add(new User(22, "Kavind", "Sadaru", "25/09/2000",image1,2.4));
            BitmapImage image2 = new BitmapImage(new Uri("/Model/Images/2.png", UriKind.Relative));
            users.Add(new User(22, "Shakila", "Madhushan", "14/04/2000",image2,1.4));
            BitmapImage image3 = new BitmapImage(new Uri("/Model/Images/3.png", UriKind.Relative));
            users.Add(new User(22, "Rashmika", "Heshan", "19/01/2000",image3,3.1));
            BitmapImage image4= new BitmapImage(new Uri("/Model/Images/4.png", UriKind.Relative));
            users.Add(new User(22, "Kushani", "Sauri", "11/05/2000", image4,1.9));

        }
    }
}
