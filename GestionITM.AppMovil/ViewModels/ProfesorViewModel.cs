using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestionITM.AppMovil.Models;
using System.Threading.Tasks;

namespace GestionITM.AppMovil.ViewModels
{
    public partial class ProfesorViewModel : ObservableObject
    {
        public ObservableCollection<ProfesorModel> ListaProfesores { get; set; }
        [ObservableProperty]
        private string tituloPantalla = "Directorio de profesores ITM";

        [ObservableProperty]
        private bool estaCargando;

        public ProfesorViewModel()
        {
            ListaProfesores = new ObservableCollection<ProfesorModel>();
        }

        [RelayCommand]
        public async Task CargarProfesoresAsync()
        {
            if (EstaCargando) return;
            EstaCargando = true;

            try
            {
                await Task.Delay(2000);
                ListaProfesores.Clear();
                ListaProfesores.Add(new ProfesorModel { Id = 1, Nombre = "Daniel Villamizar", Especialidad = "Backend y Arquitectura" });
                ListaProfesores.Add(new ProfesorModel { Id = 2, Nombre = "Santiago Carvajal", Especialidad = "Filosofia" });
                ListaProfesores.Add(new ProfesorModel { Id = 3, Nombre = "Juan Calle", Especialidad = "Fisico" });

                TituloPantalla = $"Se cargaron {ListaProfesores.Count} Profesores";


            }
            finally
            {
                EstaCargando = false;
            }

        }


    }

}
