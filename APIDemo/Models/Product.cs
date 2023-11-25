namespace APIDemo.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }


        public bool Active { get; set; }


        // Llaves foráneas
        public Category? Category { get; set; }
        public int? CategoryID { get; set; }

    }
}
