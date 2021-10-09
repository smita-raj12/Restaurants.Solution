namespace Restaurants.Models
{
  public class Review
  {
    public int ReviewId { get; set; }
    public string Name { get; set; }
    public string Description  { get; set; }
    public int Stars  { get; set; }
    public int RestaurantId { get; set; }
    public virtual Restaurant Restaurant { get; set; }
  }
}