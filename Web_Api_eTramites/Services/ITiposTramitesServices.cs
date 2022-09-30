namespace Web_Api_eTramites.Services
{
    public interface ITiposTramitesServices
    {
        public List<Entities.TIPOS_TRAMITES> read();
        public Entities.TIPOS_TRAMITES getByPk(int id);
    }
}
