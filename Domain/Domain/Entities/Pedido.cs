namespace Domain.Entities
{
  public class Pedido
  {
    public Pedido() { }

    public int Id { get; set; }
    public DateTime DataCriacao { get; set; }
    public List<ItemPedido> Itens { get; set; } = new();
    public decimal Total => Itens.Sum(i => i.Total);
  }
}
