﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using HandyControl.Data;
using HandyControl.Themes;
using HandyControl.Tools;
using System.Windows.Markup;
using System.ComponentModel;

namespace ThaLastOneAbsence
{
    /// <summary>
    /// Logique d'interaction pour Formateur.xaml
    /// </summary>
    public partial class Formateur : Window
    {

        public string date = DateTime.Now.ToString("dd-MM-yyyy");

        [DefaultProperty("Items")]
        [ContentProperty("Items")]
        [TemplatePart(Name = " ", Type = typeof(Panel))]

        public class HeaderedSimpleItemsControl : SimpleItemsControl
        {

        }
        public class SideMenu : HeaderedSimpleItemsControl
        {

        }
        public class SimpleItemsControl : Control
        {

        }



        public Formateur()
        {
            InitializeComponent();

        }


        Connect c = new Connect();

        public void ShowDT(string a)
        {
            c.connecter();
            c.cmd.CommandText = "SELECT StudentId,Fullname,Email  from Student  where FormateurId= " + a ;
            c.cmd.Connection = c.con;
            c.dr = c.cmd.ExecuteReader();
            c.dt.Load(c.dr);
            dg.ItemsSource = c.dt.DefaultView;
            c.dr.Close();

            /*  var name = c.dt.Rows[0][0].ToString();
              MessageBox.Show(name);*/

            /* if (c.dr.HasRows)
             {
                  c.dr.Read();
                 int StudentId = c.dr.GetInt32(0);
                 MessageBox.Show(StudentId.ToString());
                 // Call Close when done reading.
                 c.dr.Close();

             }*/



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string St_ID = "";
            string StudentName = "";
            ;
        }
        int id;
        /* private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
         {
             var row = dg.SelectedItem as DataRowView;
            var id= row.Row[0].ToString();
             var name = row.Row[1].ToString();
             var email = row.Row[2].ToString();
             var absent = row.Row[3].ToString();
             var present = row.Row[4].ToString();
             var late = row.Row[5].ToString();
            *//* var absentt= CheckBox.;*//*

             MessageBox.Show(id+ " " +name + " "+ email + " " +absent + " " + late + " " + present);

         }*/

        /*   public void Window_Loaded()
            {

                for (int i = 0; i < dg.Items.Count; i++)
                {
                    CheckBox mycheckbox = dg.Columns[4].GetCellContent(dg.Items[i]) as CheckBox;
                   if (mycheckbox.IsChecked == true)
                    {
                        MessageBox.Show("Checked");
                    }

                }
            }*/


        private void dg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void dg_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void Present_chk_Checked(object sender, RoutedEventArgs e)

        {

            var row = dg.SelectedItem as DataRowView;
            var id = row.Row[0].ToString();
            bool value = true;
            bool Unvalue = false;


            c.connecter();
            c.cmd.CommandText = $"INSERT INTO Absence (valAbsence,valPresence,valRetard,date,EtudiantId ) values ( '{Unvalue}','{value}','{Unvalue}','{date}','{id}') ";
            c.cmd.Connection = c.con;
            c.dr = c.cmd.ExecuteReader();
            c.dt.Load(c.dr);
            dg.ItemsSource = c.dt.DefaultView;
            c.dr.Close();



        }

        private void Present_chk_Unchecked(object sender, RoutedEventArgs e)
        {
            var row = dg.SelectedItem as DataRowView;
            var id = row.Row[0].ToString();

            c.connecter();
            c.cmd.CommandText = "DELETE FROM Absence WHERE EtudiantId = '" + id + "' AND date = '" + date + "'";
            c.cmd.Connection = c.con;
            c.dr = c.cmd.ExecuteReader();
            c.dt.Load(c.dr);
            dg.ItemsSource = c.dt.DefaultView;
            c.dr.Close();

        }

        private void late_chk_Checked(object sender, RoutedEventArgs e)
        {
            var row = dg.SelectedItem as DataRowView;
            var id = row.Row[0].ToString();
            bool value = true;
            bool Unvalue = false;


            c.connecter();
            c.cmd.CommandText = $"INSERT INTO Absence (valAbsence,valPresence,valRetard,date,EtudiantId ) values ( '{Unvalue}','{Unvalue}','{value}','{date}','{id}') ";
            c.cmd.Connection = c.con;
            c.dr = c.cmd.ExecuteReader();
            c.dt.Load(c.dr);
            dg.ItemsSource = c.dt.DefaultView;
            c.dr.Close();


        }

        private void late_chk_Unchecked(object sender, RoutedEventArgs e)
        {
            var row = dg.SelectedItem as DataRowView;
            var id = row.Row[0].ToString();

            c.connecter();
            c.cmd.CommandText = "DELETE FROM Absence WHERE EtudiantId = '" + id + "' AND date = '" + date + "'";
            c.cmd.Connection = c.con;
            c.dr = c.cmd.ExecuteReader();
            c.dt.Load(c.dr);
            dg.ItemsSource = c.dt.DefaultView;
            c.dr.Close();
        }

        private void abs_chk_Checked(object sender, RoutedEventArgs e)
        {
            var row = dg.SelectedItem as DataRowView;
            var id = row.Row[0].ToString();
            bool value = true;
            bool Unvalue = false;


            c.connecter();
            c.cmd.CommandText = $"INSERT INTO Absence (valAbsence,valPresence,valRetard,date,EtudiantId ) values ( '{value}','{Unvalue}','{Unvalue}','{date}','{id}') ";
            c.cmd.Connection = c.con;
            c.dr = c.cmd.ExecuteReader();
            c.dt.Load(c.dr);
            dg.ItemsSource = c.dt.DefaultView;
            c.dr.Close();



        }

        private void abs_chk_Unchecked(object sender, RoutedEventArgs e)
        {
            var row = dg.SelectedItem as DataRowView;
            var id = row.Row[0].ToString();

            c.connecter();
            c.cmd.CommandText = "DELETE FROM Absence WHERE EtudiantId = '" + id + "' AND date = '" + date + "'";
            c.cmd.Connection = c.con;
            c.dr = c.cmd.ExecuteReader();
            c.dt.Load(c.dr);
            dg.ItemsSource = c.dt.DefaultView;
            c.dr.Close();
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dg_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}