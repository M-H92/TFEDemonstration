namespace Shared.DataTransfertObject
{
    public class ParamsPaginationPrestationDTO
    {
        const int DEFAULT_PAGE_SIZE = 20;
        const int MAX_PAGE_SIZE = 50;

        const int DEFAULT_PAGE_NUMBER = 1;

        private int pageSize = DEFAULT_PAGE_SIZE;
        public int PageSize
        {
            get { return pageSize; }
            set
            {
                pageSize = value > MAX_PAGE_SIZE ? MAX_PAGE_SIZE : value;
            }
        }

        private int pageNumber = DEFAULT_PAGE_NUMBER;
        public int PageNumber
        {
            get { return pageNumber; }
            set { pageNumber = value; }
        }

        public string User { get; set; }

    }
}
