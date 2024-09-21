namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

public class Province
{
        public Province(string provinceCode, string regionCode, string provinceDescription)
        {
                ProvinceCode = provinceCode;
                RegionCode = regionCode;
                ProvinceDescription = provinceDescription;
        }

        public string ProvinceCode { get; private set; }
        public string RegionCode { get; private set; }
        public string ProvinceDescription { get; private set; }
}