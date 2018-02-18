﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCRS.Domain;

namespace GCRS.Data
{
    public static class AppDatabase
    {
        static ApplicationDbContext context = new ApplicationDbContext();

        #region READ
        public static List<Provincia> GetProvincias()
        {
            return context.Provincias.OrderBy(m => m.Nombre).ToList();
        }


        public static List<Municipio> GetMunicipios()
        {
            return context.Municipios.OrderBy(m => m.Nombre).ToList();
        }


        public static List<Reparto> GetRepartos()
        {
            return context.Repartos.OrderBy(m => m.Nombre).ToList();
        }


        public static List<Categoria> GetCategorias()
        {
            return context.Categorias.OrderBy(m => m.Nombre).ToList();
        }


        public static List<UnidadTiempoRenta> GetUnidadesTiempoRenta()
        {
            return context.UnidadesTiempoRenta.OrderBy(m => m.Nombre).ToList();
        }
        #endregion

        #region ADD
        public static void AddProvincia(Provincia p)
        {
            if (p != null)
            {
                context.Provincias.Add(p);
                context.SaveChanges();
            }
        }

        public static void AddMunicipio(Municipio p)
        {
            if (p != null)
            {
                context.Municipios.Add(p);
                context.SaveChanges();
            }
        }

        public static void AddReparto(Reparto p)
        {
            if (p != null)
            {
                context.Repartos.Add(p);
                context.SaveChanges();
            }
        }

        public static void AddCategoria(Categoria p)
        {
            if (p != null)
            {
                context.Categorias.Add(p);
                context.SaveChanges();
            }
        }

        public static void AddUnidadTiempoRenta(UnidadTiempoRenta p)
        {
            if (p != null)
            {
                context.UnidadesTiempoRenta.Add(p);
                context.SaveChanges();
            }
        }
        #endregion

        #region DELETE
        public static void RemoveProvincia(int id)
        {
            if (context.Provincias.Find(id) != null)
            {
                context.Provincias.Remove(context.Provincias.Find(id));
                context.SaveChanges();
            }
        }

        public static void RemoveMunicipio(int id)
        {
            if (context.Municipios.Find(id) != null)
            {
                context.Municipios.Remove(context.Municipios.Find(id));
                context.SaveChanges();
            }
        }

        public static void RemoveReparto(int id)
        {
            if (context.Repartos.Find(id) != null)
            {
                context.Repartos.Remove(context.Repartos.Find(id));
                context.SaveChanges();
            }
        }

        public static void RemoveCategoria(int id)
        {
            if (context.Categorias.Find(id) != null)
            {
                context.Categorias.Remove(context.Categorias.Find(id));
                context.SaveChanges();
            }
        }

        public static void RemoveUnidadTiempoRenta(int id)
        {
            if (context.UnidadesTiempoRenta.Find(id) != null)
            {
                context.UnidadesTiempoRenta.Remove(context.UnidadesTiempoRenta.Find(id));
                context.SaveChanges();
            }
        }
        #endregion
    }
}