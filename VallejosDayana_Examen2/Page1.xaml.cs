using System;
using System.IO;
using Microsoft.Maui.Controls;

namespace VallejosDayana_Examen2;

public partial class Page1 : ContentPage
{
    public string LastRecarga { get; set; }

    public Page1()
    {
        InitializeComponent();

        BindingContext = this;

        LoadLastRecarga();
    }

   
    private void OnRecargaClicked(object sender, EventArgs e)
    {
        string name = nameEntry.Text;
        string phone = phoneEntry.Text;

        
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phone))
        {
            DisplayAlert("Error", "Por favor ingrese todos los datos.", "OK");
            return;
        }

       
        string fileName = name.Replace(" ", "") + ".txt";  
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName);

       
        string recargaInfo = $"Nombre: {name}\nTeléfono: {phone}\nFecha: {DateTime.Now}";

        
        File.WriteAllText(filePath, recargaInfo); //Guardar la recarga en el archivo

       
        LastRecarga = recargaInfo;

        
        OnPropertyChanged(nameof(LastRecarga));

        
        DisplayAlert("Éxito", "La recarga fue realizada exitosamente.", "OK");

        LoadLastRecarga();
    }

    // Método para ultima recarga
    private void LoadLastRecarga()
    {
        string fileName = "DayanaVallejos.txt"; 
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName);

        
        if (File.Exists(filePath))
        {
            LastRecarga = File.ReadAllText(filePath);
            OnPropertyChanged(nameof(LastRecarga));
        }
        else
        {
            LastRecarga = "No se ha realizado ninguna recarga aún.";
        }
    }
}