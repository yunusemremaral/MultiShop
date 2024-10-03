using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productCollection;
        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); // veri tabanı baglantısı kur 
            var database = client.GetDatabase(_databaseSettings.DatabaseName);  // veritabanını getir
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);// tabloyu bulma 
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var values = _mapper.Map<Product>(createProductDto);// mapleme
            await _productCollection.InsertOneAsync(values); // ekleme
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductId == id); // direk id den sil 
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var values = await _productCollection.Find<Product>(x => x.ProductId == id).FirstOrDefaultAsync();// önce bul 
            return _mapper.Map<GetByIdProductDto>(values);// sonra getirirken maple

        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var values = _mapper.Map<Product>(updateProductDto); // maple 
            await _productCollection.FindOneAndReplaceAsync(x=>x.ProductId == updateProductDto.ProductId ,values); // verileri güncelle
        }
    }
}
