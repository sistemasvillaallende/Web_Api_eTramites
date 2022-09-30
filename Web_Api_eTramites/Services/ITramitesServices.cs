namespace Web_Api_eTramites.Services
{
    public interface ITramitesServices
    {
        public int insert(Entities.TRAMITE obj);
        public void update(Entities.TRAMITE obj);
        public void delete(Entities.TRAMITE obj);
        public List<Entities.TRAMITE> read();
        public Entities.TRAMITE getByPk(int id);
        public List<Entities.TIPOS_TRAMITES> listartipos_tramites();
        public List<Entities.TIPOLOGIAS> listartipologias();
        public List<Entities.TRAMITE> getHistorial(int id);

    }
}
