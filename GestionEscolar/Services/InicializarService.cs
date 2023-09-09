﻿using GestionEscolar.DTO;
using GestionEscolar.Exceptions;
using GestionEscolar.Repository;
using static GestionEscolar.DTO.InicializarRequest;

namespace GestionEscolar.Services
{
    public class InicializarService
    {

        //Inicializacion de datos
        public void InicializarDatos(InicializarRequest datos)
        {
            ComprobarPoderacionCompetencia(datos.listCompetencias);
            ComprobarPoderacionEspecifica(datos.listEspecificas);
            GetDatosOK(datos);
            //Aqui guradariamos los datos en caso de tener persistencia de datos
        }

        //Comprobar que la'actividad es correcta
        private void GetDatosOK(InicializarRequest datos)
        {
            //guardamos los datos en listas
            List<ActividadRequest> listActividades = datos.listActividades;
            List<CompetenciaRequest> listCompetencia = datos.listCompetencias;
            List<EspecificaRequest> listEspecifica = datos.listEspecificas;

            foreach (var actividad in listActividades)            
            {
                //comprobamos que el tipo especifico no este vacio i que exista
                if (actividad.especifica.Equals("") || listEspecifica.Find(especifica => especifica.nombre.Equals(actividad.especifica)) == null)
                    throw new EspecificacionNotFoundException("La actividad " + actividad.id + " no existe la especificación");

                //comprobamos que la competencia no este vacio i que exista
                if (actividad.competencia.Equals("") || listCompetencia.Find(competencia => competencia.nombre.Equals(actividad.competencia)) == null)
                    throw new CompetenciaNotFoundException("La actividad " + actividad.id + " no tiene competéncia");
            }
        }

        //Comprobamos que las ponderaciones de competencia sumen 100
        private void ComprobarPoderacionCompetencia(List<CompetenciaRequest> listCompetencias)
        {
            float ponderacio = 0;
            foreach (var competencia in listCompetencias)
            {
                ponderacio += competencia.ponderacion;
            }
            if (ponderacio != 100)
            {
                throw new PonderacionException("Las ponderaciones no suman 100");
            }
        }


        //Comprobamos que las ponderaciones de Especifica sumen 100
        private void ComprobarPoderacionEspecifica(List<EspecificaRequest> listEspecificas)
        {
            float ponderacio = 0;
            foreach (var especifica in listEspecificas)
            {
                ponderacio += especifica.ponderacion;
            }
            if(ponderacio != 100)
            {
                throw new PonderacionException("Las ponderaciones no suman 100");
            }
        }

    }
}