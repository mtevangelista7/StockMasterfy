namespace StockMasterFy.Services
{
    public interface ICryptoService
    {
        public string Encrypt(object data);
        public T Decrypt<T>(string encryptedData);
    }
}
