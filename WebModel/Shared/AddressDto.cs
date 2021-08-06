using Model.Tables.CodeBook;
using System;

namespace WebModel.Shared
{
    public class AddressDto : BaseDto
    {
        public Guid CountryId { get; set; } = Guid.Empty;
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public Guid AddressTypeId { get; set; } = Guid.Empty;
        private string _countryName = string.Empty;
        public string CountryName
        {
            get
            {
                if (_countryName == CodeBookValues.CODEBOOK_SELECT_VALUE)
                {
                    return "";
                }
                return _countryName;
            }
            set => _countryName = value;
        }

        public string FullAddress => string.Format("{0} {1} {2} {3}", Street, City, ZipCode, CountryName);
        public bool IsEmptyFullAddress => string.IsNullOrEmpty(FullAddress.Trim());
    }
}
