namespace Web_Api_eTramites.Services
{
    public class TiposTramitesServices : ITiposTramitesServices
    {
        //public void delete(Entities.TRAMITE obj)
        //{
        //    try
        //    {
        //        Entities.TRAMITE.delete(obj);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public Entities.TRAMITE getByPk(int nro_bad)
        //{
        //    try
        //    {
        //        return Entities.TRAMITE.getByPk(nro_bad);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public Entities.TRAMITE getByPk2(int nro_bad)
        //{
        //    try
        //    {
        //        return Entities.TRAMITE.getByPk2(nro_bad);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public int insert(Entities.TRAMITE obj)
        //{
        //    try
        //    {
        //        return Entities.TRAMITE.insert(obj);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public List<Entities.TIPOS_TRAMITES> read()
        {
            try
            {
                return Entities.TIPOS_TRAMITES.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Entities.TIPOS_TRAMITES getByPk(int id)
        {
            try
            {
                return Entities.TIPOS_TRAMITES.getByPk(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public void update(Entities.TRAMITE obj)
        //{
        //    try
        //    {
        //        Entities.TRAMITE.update(obj);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}
