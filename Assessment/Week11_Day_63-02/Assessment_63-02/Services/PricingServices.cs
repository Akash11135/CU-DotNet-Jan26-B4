namespace Assessment_63_02.Services
{
    public class PricingServices : IPricingServices
    {
         public double CalculatePrice(double price , string promocode, bool productPromoCheck)
        {
            double FinalCost = price;
            if (promocode.Equals("WINTER25"))
            {
                double descount = price * 0.15;
                FinalCost = price - descount;
               

            }
            else if (promocode.Equals("FREESHIP"))
            {
                if (productPromoCheck)
                {
                    double descount = price * 0.15;
                    FinalCost = price - descount-5;
                }
                else
                {
                    FinalCost = price - 5;
                }

            }
            
                return FinalCost;
        }   
    }
}
