using apisBlog.Models.ApisI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apisBlog.Models.ApisImpl
{
    public class EntradaImpl : EntradaI
    {

        public bool deleteEntrada(int Carnet)
        {
            using (var context = new XTecTutorDBEntities())
            {
                ENTRADA eNTRADA = context.ENTRADAs.Find(Carnet);
                if (eNTRADA != null)
                {
                    context.ENTRADAs.Remove(eNTRADA);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<ENTRADA> getAllEntradas()
        {
            using (var context = new XTecTutorDBEntities())
            {
                return context.ENTRADAs.ToList();
            }
        }

        public ENTRADA getEntrada(int IdEntrada)
        {
            using (var context = new XTecTutorDBEntities())
            {
                ENTRADA eNTRADA = context.ENTRADAs.Find(IdEntrada);
                if (eNTRADA != null)
                {
                    return eNTRADA;
                }
                else
                {
                    return null;
                }
            }
        }

        public void modEntrada(ENTRADA nueva)
        {
            using (var context = new XTecTutorDBEntities())
            {
                for (int i = 0; i < context.ENTRADAs.ToList().Count; i++) { 
                        if (context.ENTRADAs.ToList()[i].IdEntrada == nueva.IdEntrada)
                        {
                            context.ENTRADAs.ToList()[i].Titulo = nueva.Titulo;
                            context.ENTRADAs.ToList()[i].Abstract = nueva.Abstract;
                            context.ENTRADAs.ToList()[i].Body = nueva.Body;
                            if (nueva.Carrera != 0) {
                                context.ENTRADAs.ToList()[i].Carrera = nueva.Carrera;
                            }
                             if (nueva.Curso != "0")
                            {
                                context.ENTRADAs.ToList()[i].Curso = nueva.Curso;
                            }
                            if (nueva.Tema != 0)
                            {
                                context.ENTRADAs.ToList()[i].Tema = nueva.Tema;
                            }   
                        
                            context.ENTRADAs.ToList()[i].Visible = nueva.Visible;
                            context.ENTRADAs.ToList()[i].FechaMod = nueva.FechaMod;
                            context.SaveChanges();
                            return;
                        }
                }
            }
            
        }

        public bool setEntrada(ENTRADA entrada)
        {
            using (var context = new XTecTutorDBEntities())
            {
                bool result = context.ENTRADAs.Add(entrada) != null;
                context.SaveChanges();
                return result;
            }
        }
    }
}