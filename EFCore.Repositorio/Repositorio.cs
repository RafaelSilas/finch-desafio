using EFCore.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repositorio
{
    public class Repositorio : IRepositorio
    {
        public ProtestoContext _context;

        public Repositorio(ProtestoContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Bancos[]> GetAllBancos()
        {
            return await _context.Bancos.ToArrayAsync();
        }

        public async Task<Bancos> GetBancoId(int id)
        {
            return await _context.Bancos.Where(banco => banco.idBanco == id).FirstOrDefaultAsync();
        }

        public async Task<Bancos> GetBancoNome(string Nome)
        {
            return await _context.Bancos.Where(banco => banco.Nome == Nome).FirstOrDefaultAsync();
        }

        public async Task<UFs[]> GetAllUfs()
        {
            return await _context.Ufs.ToArrayAsync();
        }

        public async Task<UFs> GetUfId(int id)
        {
            return await _context.Ufs.Where(uf => uf.idUf == id).FirstOrDefaultAsync();
        }

        public async Task<UFs> GetUfDescricao(string Descricao)
        {
            return await _context.Ufs.Where(uf => uf.Descricao == Descricao).FirstOrDefaultAsync();
        }

        public async Task<Cidades[]> GetAllCidades()
        {
            return await _context.Cidades.ToArrayAsync();
        }

        public async Task<Cidades> GetCidadeID(int id)
        {
            return await _context.Cidades.Where(cidade => cidade.idCidade == id).FirstOrDefaultAsync();
        }

        public async Task<Cidades> GetCidadeDescricao(string Descricao)
        {
            return await _context.Cidades.Where(cidade => cidade.Descricao == Descricao).FirstOrDefaultAsync();
        }

        public async Task<Contratos[]> GetAllContratos()
        {
            return await _context.Contratos.ToArrayAsync();
        }

        public async Task<Contratos> GetContratoId(int id)
        {
            return await _context.Contratos.Where(contrato => contrato.idContrato == id).FirstOrDefaultAsync();
        }

        public async Task<Contratos> GetContratoNumero(string Numero)
        {
            return await _context.Contratos.Where(contrato => contrato.Numero == Numero).FirstOrDefaultAsync();
        }

        public async Task<ContratosParcelas[]> GetAllContratosParcelas()
        {
            return await _context.ContratosParcelas.ToArrayAsync();
        }

        public async Task<ContratosParcelas> GetContratoParcelaId(int id)
        {
            return await _context.ContratosParcelas.Where(contratoparcela => contratoparcela.idContratoParcela == id).FirstOrDefaultAsync();
        }

        public async Task<Devedores[]> GetAllDevedores()
        {
            return await _context.Devedores.ToArrayAsync();
        }

        public async Task<Devedores> GetDevedorId(int id)
        {
            return await _context.Devedores.Where(devedor => devedor.idDevedor == id).FirstOrDefaultAsync();
        }

        public async Task<Devedores> GetDevedorCPF_CNPJ(string CPF_CNPJ)
        {
            return await _context.Devedores.Where(devedor => devedor.CPF_CNPJ == CPF_CNPJ).FirstOrDefaultAsync();
        }

        public async Task<DevedoresEnderecos[]> GetAllDevedoresEnderecos()
        {
            return await _context.DevedoresEnderecos.ToArrayAsync();
        }

        public async Task<DevedoresEnderecos> GetDevedoresEnderecosId(int id)
        {
            return await _context.DevedoresEnderecos.Where(devedoresenderecos => devedoresenderecos.idDevedorEndereco == id).FirstOrDefaultAsync();
        }

        public async Task<DevedoresEnderecos> GetDevedoresEnderecosCEP(string CEP)
        {
            return await _context.DevedoresEnderecos.Where(devedoresenderecos => devedoresenderecos.CEP == CEP).FirstOrDefaultAsync();
        }

        public async Task<Protestos[]> GetAllProtestos()
        {
            return await _context.Protestos.ToArrayAsync();
        }

        public async Task<Protestos> GetProtestoId(int id)
        {
            return await _context.Protestos.Where(protesto => protesto.idProtesto == id).FirstOrDefaultAsync();
        }

        public async Task<Protestos> GetProtestoContrato(int Contrato)
        {
            return await _context.Protestos.Where(protesto => protesto.Contrato == Contrato).FirstOrDefaultAsync();
        }

        public async Task<PracasPagamentos[]> GetAllPracasPagamentos()
        {
            return await _context.PracasPagamentos.ToArrayAsync();
        }

        public async Task<PracasPagamentos> GetPracasPagamentoId(int id)
        {
            return await _context.PracasPagamentos.Where(pracas => pracas.idPracaPagamento == id).FirstOrDefaultAsync();
        }

        public async Task<Usuarios[]> GetAllUsuarios()
        {
            return await _context.Usuarios.ToArrayAsync();
        }

        public async Task<Usuarios> GetUsuariosId(int id)
        {
            return await _context.Usuarios.Where(usuarios => usuarios.idUsuario == id).FirstOrDefaultAsync();
        }

        public async Task<Usuarios> GetUsuariosLogin(string Login)
        {
            return await _context.Usuarios.Where(usuario => usuario.login == Login).FirstOrDefaultAsync();
            
        }
        public async Task<Usuarios> LoginValido(string login, string senha)
        {
            return await _context.Usuarios.Where(e => e.login == login && e.Senha == senha).FirstOrDefaultAsync();
        }
    }
}
