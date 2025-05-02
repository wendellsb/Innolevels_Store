$(document).ready(function () {
  $(".btn-deletar-pedido").on("click", function () {
    const id = $(this).data("pedido-id");

    if (!id || id === 0) {
      console.error("ID inválido para exclusão:", id);
      return;
    }

    if (confirm("Tem certeza que deseja deletar este pedido?")) {
      $.ajax({
        url: '/Pedido/Deletar',
        type: 'POST',
        data: { id: id },
        success: function (res) {
          if (res.sucesso) {
            alert("Pedido deletado com sucesso!");
            location.reload();
          } else {
            alert("Erro ao deletar pedido: " + res.mensagem);
          }
        },
        error: function (xhr, status, error) {
          console.error("Erro na requisição:", error);
          alert("Erro ao deletar pedido.");
        }
      });
    }
  });
});
