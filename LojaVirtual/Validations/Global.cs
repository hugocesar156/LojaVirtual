namespace LojaVirtual.Validations
{
    public class Global
    {
        public class Mensagem
        {
            //Geral
            public const string FalhaBanco = "Falha ao tentar acessar o Banco de Dados.";
            public const string FalhaCadastro = "Falha ao tentar realizar cadastro.";

            //Usuário
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
            Extornado,
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
            Reservado,
            Autorizado,
            Enviado,
            Entregue,
            Cancelado
        }
    }
}