$(document).ready(function () {
  // Submissão do formulário (adicionar ou editar)
  $('#formAdicionarProduto').on('submit', function (e) {
    e.preventDefault();

    const formData = new FormData(this);
    const id = $('#id').val();
    const url = id ? '/Produto/Editar' : '/Produto/Adicionar';

    $.ajax({
      url: url,
      method: 'POST',
      data: formData,
      processData: false,
      contentType: false,
      success: function (resposta) {
        if (resposta.sucesso) {
          alert(id ? 'Produto editado com sucesso!' : 'Produto adicionado com sucesso!');
          $('#modalAdicionarProduto').modal('hide');
          $('#formAdicionarProduto')[0].reset();
          $('#id').val('');
          $('#modalAdicionarProdutoLabel').text('Adicionar Produto');
          location.reload();
        } else {
          alert(resposta.mensagem || 'Erro ao salvar.');
        }
      },
      error: function () {
        alert('Erro ao enviar a requisição.');
      }
    });
  });

  // Clicar em "editar"
  $('.btn-editar').on('click', function () {
    const id = $(this).data('id');
    const nome = $(this).data('nome');
    const descricao = $(this).data('descricao');
    const preco = $(this).data('preco');

    $('#id').val(id);
    $('#nome').val(nome);
    $('#descricao').val(descricao);
    $('#preco').val(preco.toString().replace(',', '.'));

    $('#modalAdicionarProdutoLabel').text('Editar Produto');
    $('#modalAdicionarProduto').modal('show');
  });

  // Clicar em "deletar"
  $('.btn-deletar').on('click', function () {
    const id = $(this).data('id');

    if (confirm('Tem certeza que deseja excluir este produto?')) {
      $.ajax({
        url: '/Produto/Deletar',
        method: 'POST',
        data: { id },
        success: function (resposta) {
          if (resposta.sucesso) {
            alert('Produto deletado com sucesso!');
            location.reload();
          } else {
            alert(resposta.mensagem || 'Erro ao deletar.');
          }
        },
        error: function () {
          alert('Erro ao enviar a requisição de exclusão.');
        }
      });
    }
  });
});
