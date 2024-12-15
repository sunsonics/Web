namespace Web.Models
{
    public class orders
    {
        public int ID { get; set; }
        public int User_id { get; set; }
        public int Goods_id  { get; set; }
        public int Count { get; set; }
        public Users Users { get; set; }
        public goods goods { get; set; }
    }

}
