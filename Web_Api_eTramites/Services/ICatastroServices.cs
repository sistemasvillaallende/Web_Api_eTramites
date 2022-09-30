namespace Web_Api_eTramites.Services
{
    public interface ICatastroServices
    {
        public List<Entities.CATASTRO> read();


        public Entities.CATASTRO getByPk(int circunscripcion, int seccion, int manzana, int parcela, int p_h);
    }
}
