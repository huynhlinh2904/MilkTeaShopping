using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using MilkTeaShopping.Entities;
using MilkTeaShopping.Helper;

namespace MilkTeaShopping.Service.CloundinaryService
{
    public class CloundinaryService : ICloundinaryService
    {
        private readonly Cloudinary _cloundinaryService;
        private readonly MilkTeaShoppingContext milkTeaShoppingContext;
        public CloundinaryService(MilkTeaShoppingContext milkTeaShoppingContext, IOptions<CloundinarySettings> config)
        {
            var acc = new CloudinaryDotNet.Account(
            config.Value.CloundName,
            config.Value.ApiKey,
            config.Value.ApiSecret
            );
            _cloundinaryService = new Cloudinary(acc);
            this.milkTeaShoppingContext = milkTeaShoppingContext;
        }
    }
}
