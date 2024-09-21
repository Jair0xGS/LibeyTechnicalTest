namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

public class Province
{
        public Province(string provinceCode, string regionCode, string proviceDescription)
        {
                ProvinceCode = provinceCode;
                RegionCode = regionCode;
                ProviceDescription = proviceDescription;
        }

        public string ProvinceCode { get; private set; }
        public string RegionCode { get; private set; }
        public string ProviceDescription { get; private set; }
}