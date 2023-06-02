using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PDC03_MODULE07.Model;
using PDC03_MODULE07.ViewModel;

namespace PDC03_MODULE07.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEmployee : ContentPage
    {
        EmployeeViewModel _viewModel;
        bool _isUpdate;
        int employeeID;

        public AddEmployee()
        {
            InitializeComponent();
            _viewModel = new EmployeeViewModel();
            _isUpdate = false;
        }

        public AddEmployee(EmployeeModel obj)
        {
            InitializeComponent();
            _viewModel = new EmployeeViewModel();
            if (obj != null)
            {
                employeeID = obj.Id;
                txtName.Text = obj.Name;
                txtEmail.Text = obj.Email;
                txtAddress.Text = obj.Address;
                _isUpdate = true;
            }
        }

        //CALL Save and Update

        private async void BtnSaveUpdate_Clicked(object sender, EventArgs e)
        {
            EmployeeModel obj = new EmployeeModel();
            obj.Name = txtName.Text;
            obj.Email = txtEmail.Text;
            obj.Address = txtAddress.Text;

            if(_isUpdate)
            {
                obj.Id = employeeID;
                await _viewModel.UpdateEmployee(obj);
            }
            else
            {
                _viewModel.InsertEmployee(obj);
            }

            await this.Navigation.PopAsync();
        }


        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}