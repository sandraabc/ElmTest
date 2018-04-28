namespace Entities.Interfaces
{
    interface IItem
    {
        Product Product { get; set; }
        int Quantity { get; set; }
        decimal TotalPrice { get; }

        void AddMoreQuantity();
        void DeleteQuantitys();
        
    }
}
