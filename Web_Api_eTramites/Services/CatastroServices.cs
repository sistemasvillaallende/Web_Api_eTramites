using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web_Api_eTramites.Entities;

namespace Web_Api_eTramites.Services
{


    //public interface ICatastroServices
    //{
    //    public List<Entities.CATASTRO> read();
    //    public Entities.CATASTRO getByPk(int circunscripcion, int seccion, int manzana, int parcela, int p_h);
    //}
    public class CatastroServices : ICatastroServices
    {
        public List<Entities.CATASTRO> read()
        {
            try
            {
                return Entities.CATASTRO.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Entities.CATASTRO getByPk(int circunscripcion, int seccion, int manzana, int parcela, int p_h)
        {
            try
            {
                return Entities.CATASTRO.getByPk(circunscripcion, seccion, manzana, parcela, p_h);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
