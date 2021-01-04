namespace LojaVirtual.Validations
{
    public class Global
    {
        public class Mensagem
        {
            //Carrinho
            public const string SemEstoque = "Quantidade máxima disponível excedida.";
            public const string FalhaAdicionar = "Falha ao tentar adicionar item no carrinho.";
            public const string FalhaRemover = "Falha ao tentar remover item no carrinho.";
            public const string FalhaRetirar = "Falha ao tentar retirar item no carrinho.";

            //Geral
            public const string FalhaBanco = "Falha ao tentar acessar o Banco de Dados.";
            public const string FalhaAtualizacao = "Falha ao tentar atualizar registro.";
            public const string FalhaCadastro = "Falha ao tentar realizar cadastro.";
            public const string FalhaRedirecionamento = "Falha ao buscar página.";
            public const string SucessoOperacao = "Operação realizada com sucesso.";

            //Imagem
            public const string ArquivoNaoEncontrado = "Arquivo de imagem não encontrado.";
            public const string FalhaCarregarImagem = "Falha ao tentar carregar imagem.";
            public const string FalhaDescartarImagem = "Falha ao tentar descartar imagem.";
            public const string FalhaRemoverImagem = "Falha ao tentar remover imagem.";
            public const string FalhaSalvarImagem = "Falha ao tentar salvar imagem.";

            //Pagamento
            public const string FalhaCalculoParcelas = "Falha ao calcular parcelas de pagamento.";
            public const string FalhaPedido = "Falha durante confirmação de pedido. Transação de número ";
            public const string FalhaTransacao = "Falha, a transação não foi concluída.";

            //Pedido
            public const string FalhaRastrear = "Falha ao tentar rastrear produto.";

            //Usuário
            public const string FalhaEmail = "Email de usuário já em uso";
            public const string FalhaValidarUsuario = "Falha na validação de usuário";
        }

        public enum Pagamento : byte
        {
            Boleto,
            CartaoCredito
        }

        public enum Pedido : byte
        {
            Aguardando,
            Processando,
            Aprovado,
            Estornado,
            Recusado,
            Finalizado
        }

        public enum Perfil : byte
        {
            Administrador,
            Vendedor,
            Cliente
        }

        public enum Produto : byte
        {
            Aguardando,
            Aprovado,
            Enviado,
            Entregue,
            Cancelado
        }
    }
}