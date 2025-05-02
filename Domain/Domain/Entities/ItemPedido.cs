namespace Domain.Entities
{
  public class ItemPedido
  {
    public int Id { get; set; }
    public int ProdudoId { get; set; }
    public int Quantidade { get; set; }
    public Produto Produto { get; set; }
    public decimal Total => Produto.Preco * Quantidade;

    public ItemPedido() { }
  }
}
