using DevTracker.Core.Enums;
using DevTracker.Core.ValueObjects;

namespace DevTracker.Core.Entities
{
    public class ShippingOrder : EntityBase
    {
        public ShippingOrder(string description, decimal weightInKg, ValueObjects.DeliveryAddress deliveryAddress)
        {
            TrackingCode = GenerateTrackingCode();
            Description = description;
            PostedAt = DateTime.Now;
            WeightInKg = weightInKg;
            DeliveryAddress = deliveryAddress;
            Status = ShippingOrderStatus.Started;
            Services = new List<ShippingOrderService>();
        }

        public string TrackingCode { get; set; }
        public string Description { get; set; }
        public DateTime PostedAt { get; set; }
        public decimal WeightInKg { get; set; }
        public ValueObjects.DeliveryAddress DeliveryAddress { get; set; }
        public ShippingOrderStatus Status { get; set; }
        public decimal TotalPrice { get; set; }
        public List<ShippingOrderService> Services { get; set; }

        public void SetupServices(List<ShippingService> services)
        {
            foreach (var service in services)
            {
                var servicePrice = service.FixedPrice + (service.PricePerKg * WeightInKg);
                TotalPrice += servicePrice; 
                Services.Add(new ShippingOrderService(service.Title, servicePrice));
            }
        }
        private string GenerateTrackingCode()
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                const string numbers = "0123456789";

                var code = new char[10];
                var random = new Random();

                for (var i = 0; i < 5; i++)
                {
                    code[i] = chars[random.Next(chars.Length)];
                }

                for (var i = 5; i < 10; i++)
                {
                    code[i] = numbers[random.Next(numbers.Length)];
                }

                return new String(code);
            }
        
    }
}
