using PruebaTécnica.Models;
using System;
using System.Collections.Generic;
using System.Collections;
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
using System.Collections.ObjectModel;
using PruebaTécnica.Controllers;

namespace PruebaTécnica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Cliente> clients;
        Cliente cliente;

        public MainWindow()
        {
            InitializeComponent();
            llenarDG(ClienteController.SeeClients());
        }

        private void llenarDG(List<Cliente> clientes)
        {
            clients = new ObservableCollection<Cliente>();
            foreach (Cliente cliente in clientes)
            {
                clients.Add(cliente);
            }
            dgt_clients.ItemsSource = clients;
            names.Clear();
            last_names.Clear();
            dui.Clear();
            fecha_nacimiento.Text = "";
        }

        private void btn_addClient_Click(object sender, RoutedEventArgs e)
        {
            cliente = new Cliente();
            cliente.nombres = names.Text;
            cliente.apellidos = last_names.Text;
            cliente.dui = dui.Text;
            cliente.fecha_nacimiento = fecha_nacimiento.SelectedDate;
            ClienteController.InsertClient(cliente);
            llenarDG(ClienteController.SeeClients());
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            cliente = (dgt_clients.SelectedItem as Cliente);
            ClienteController.DeleteClient(cliente);
            llenarDG(ClienteController.SeeClients());
        }

        private void btn_actualizar_Click(object sender, RoutedEventArgs e)
        {
            cliente = (dgt_clients.SelectedItem as Cliente);
            names.Text = cliente.nombres;
            last_names.Text = cliente.apellidos;
            dui.Text = cliente.dui;
            fecha_nacimiento.SelectedDate = cliente.fecha_nacimiento;
            btn_addClient.Visibility = Visibility.Collapsed;
            btn_updateClient.Visibility = Visibility.Visible;
        }

        private void btn_updateClient_Click(object sender, RoutedEventArgs e)
        {
            cliente.nombres = names.Text;
            cliente.apellidos = last_names.Text;
            cliente.dui = dui.Text;
            cliente.fecha_nacimiento = fecha_nacimiento.SelectedDate;
            ClienteController.UpdateClient(cliente);

            btn_updateClient.Visibility = Visibility.Collapsed;
            btn_addClient.Visibility = Visibility.Visible;
            llenarDG(ClienteController.SeeClients());
        }
    }
}
