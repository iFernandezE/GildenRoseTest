

namespace GildenRoseTest
{
    internal class Product
    {
        public string name { get; set; }
        public int sellIn { get; set; }
        public int quality { get; set; }
        public bool conjured { get; set; }

        public Product(string name, int sellIn, int quality,bool conjured)
        {
            this.name = name;
            this.sellIn = sellIn;
            this.quality = quality;
            this.conjured = conjured;
        }
        
        public void UpdateProductValues()
        {
            if (!isValidQualityValue(name,quality))
            {
                throw new Exception("Invalid Data");
            }
            if (name == "Sulfuras") UpdateLegendaryProductValues();
            else if (name == "Aged Brie") UpdateSpecialProductValues();
            else if (conjured) UpdateConjuredProductValues();
            else UpdateNormalProductValues();
        }

        private void UpdateNormalProductValues()
        {
            sellIn--;
            if (sellIn >= 0) quality --;
            else quality -= 2;
            if (quality < 0) quality = 0;
        }

        private void UpdateConjuredProductValues()
        {
            sellIn--;
            if (sellIn >= 0) quality -= 2;
            else quality -= 4;
            if(quality < 0) quality = 0;
        }

        private void UpdateSpecialProductValues()
        {
            if (sellIn <= 0) quality = 0;
            else if (sellIn <= 5) quality += 3;
            else if (sellIn <= 10) quality += 2;
            else quality += 1;
            if (quality >= 50) quality = 50;
        }

        private void UpdateLegendaryProductValues()
        {
            if (sellIn > 0) sellIn--;
        }

        private bool isValidQualityValue(string name, int quality){
            if (name != "Sulfuras" && quality <= 50 && quality >= 0) return true;
            else if(name == "Sulfuras" && quality == 80) return true;
            else return false;
        }

    }
}