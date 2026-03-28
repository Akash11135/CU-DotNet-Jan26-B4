namespace Assessment_63_02.Services
{
    public interface IPricingServices
    {
        public double CalculatePrice(double price , string promocode , bool productPromoCheck);
    }
}
