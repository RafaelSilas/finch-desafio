using EFCore.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repositorio
{
    public interface IRepositorio
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangeAsync();
        Task<Bancos[]> GetAllBancos();
        Task<Bancos> GetBancoId(int id);
        Task<Bancos> GetBancoNome(string Nome);

        Task<UFs[]> GetAllUfs();
        Task<UFs> GetUfId(int id);
        Task<UFs> GetUfDescricao(string Descricao);

        Task<Cidades[]> GetAllCidades();
        Task<Cidades> GetCidadeID(int id);
        Task<Cidades> GetCidadeDescricao(string Descricao);


        Task<Contratos[]> GetAllContratos();
        Task<Contratos> GetContratoId(int id);
        Task<Contratos> GetContratoNumero(string Numero);

        Task<ContratosParcelas[]> GetAllContratosParcelas();
        Task<ContratosParcelas> GetContratoParcelaId(int id);

        Task<Devedores[]> GetAllDevedores();
        Task<Devedores> GetDevedorId(int id);
        Task<Devedores> GetDevedorCPF_CNPJ(string CPF_CNPJ);

        Task<DevedoresEnderecos[]> GetAllDevedoresEnderecos();
        Task<DevedoresEnderecos> GetDevedoresEnderecosId(int id);
        Task<DevedoresEnderecos> GetDevedoresEnderecosCEP(string CEP);

        Task<Protestos[]> GetAllProtestos();
        Task<Protestos> GetProtestoId(int id);
        Task<Protestos> GetProtestoContrato(int Contrato);

        Task<PracasPagamentos[]> GetAllPracasPagamentos();
        Task<PracasPagamentos> GetPracasPagamentoId(int id);

        Task<Usuarios[]> GetAllUsuarios();
        Task<Usuarios> GetUsuariosId(int id);
        Task<Usuarios> GetUsuariosLogin(string Login);
        Task<Usuarios> LoginValido(string login, string senha);
    }
}
