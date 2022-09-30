namespace Web_Api_eTramites.Services
{
    public class TramitesServices : ITramitesServices
    {
        public void delete(Entities.TRAMITE obj)
        {
            try
            {
                Entities.TRAMITE.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Entities.TRAMITE getByPk(int id)
        {
            try
            {
                return Entities.TRAMITE.getByPk(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public  List<Entities.TRAMITE> getHistorial(int id)
        {
            try
            {
                return Entities.TRAMITE.getHistorial(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
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
        public int insert(Entities.TRAMITE obj)
        {
            try
            {
                return Entities.TRAMITE.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Entities.TRAMITE> read()
        {
            try
            {
                return Entities.TRAMITE.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Entities.TRAMITE obj)
        {
            try
            {
                Entities.TRAMITE.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Entities.TIPOS_TRAMITES> listartipos_tramites()
        {
            try
            {
                return Entities.TRAMITE.ObtenerTipoTramite();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Entities.TIPOLOGIAS> listartipologias()
        {
            try
            {
                return Entities.TRAMITE.ObtenerTipologia();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
