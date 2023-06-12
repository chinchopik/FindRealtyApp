using FindRealtyApp.Models;
using FindRealtyApp.Repositories;
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
using FindRealtyApp.Services;
using System.IO;

namespace FindRealtyApp.Views
{
    /// <summary>
    /// Логика взаимодействия для DealPage.xaml
    /// </summary>
    public partial class DealPage : Page
    {
        DealRepository dealRepository = new DealRepository();
        public DealPage()
        {
            InitializeComponent();
            DataGridView.ItemsSource = dealRepository.GetAllRealEstates();
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddDealWindow addDealWindow = new AddDealWindow();
            addDealWindow.ShowDialog();
            DataGridView.ItemsSource = dealRepository.GetAllRealEstates();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataGridView.ItemsSource = dealRepository.GetAllRealEstates().Where(p => p.Address.ToLower().Contains(SearchBar.Text.ToLower())
                    || p.Agent.ToLower().Contains(SearchBar.Text.ToLower())
                    || p.Client.ToLower().Contains(SearchBar.Text.ToLower())
                    || p.Price.ToString().ToLower().Contains(SearchBar.Text.ToLower())
                    || p.Date.ToString().ToLower().Contains(SearchBar.Text.ToLower())).ToList();
        }

        private void ButtonReceiptPDF_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridView.SelectedItem != null)
            {
                try
                {
                    string imagePath;
                    string pdfFileName;
                    using (MemoryStream ms =new MemoryStream())
                    {
                        ReceiptWindow receiptWindow = new ReceiptWindow(DataGridView.SelectedItem as Deal);
                        receiptWindow.Show();
                        imagePath = System.IO.Path.GetTempFileName() + ".png";       
                        PrintWindow.SaveAsPng(PrintWindow.GetImage(receiptWindow), imagePath);
                        receiptWindow.Close();
                        using (System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog())
                        {
                            saveFileDialog.Filter = "PDF files (.pdf)|.pdf";
                            saveFileDialog.Title = "Save PDF File";

                            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                pdfFileName = saveFileDialog.FileName;
                                MessageBox.Show("Документ успешно сохранен!", "Всплывающее окно", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                                
                            }
                            else
                            {
                                return;
                            }
                            saveFileDialog.Dispose();
                        }
                        ms.Close();
                    }
                    PrintWindow.createPdfFromImage(imagePath, pdfFileName);
                    System.IO.File.Delete(imagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            else MessageBox.Show("Выберите запись для печати","Всплывающее окно", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

        private void ButtonReceiptDOCX_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridView.SelectedItem != null)
            {
                try
                {
                    ReceiptWindow receipt = new ReceiptWindow(DataGridView.SelectedItem as Deal);
                    receipt.Show();

                    string imagePath = System.IO.Path.GetTempFileName() + ".png";
                    PrintWindow.SaveAsPng(PrintWindow.GetImage(receipt), imagePath);
                    receipt.Close();
                    PrintWindow.createDocxFromImage(imagePath);
                    System.IO.File.Delete(imagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            else MessageBox.Show("Выберите запись для печати", "Всплывающее окно", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }
    
    }
}
