namespace ProductDataAccessLayer
{
    public class Product
    {

        //The StudentID is made primaryKey and it is identity column.
        public int ProductId { get; set; }

        public string ProductTitle  {  get; set;}

        public string ProductStyle  {  get; set; }

        public string ProductColor  {  get; set; }

        public double ProductPrice  {  get; set; }

        public int ProductStock  { get; set; }

        public string ProductSku  {  get; set; }
        
    }
}
