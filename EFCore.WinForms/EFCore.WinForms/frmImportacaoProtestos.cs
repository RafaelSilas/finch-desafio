using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFCore.Dominio;
using EFCore.WinForms.BLL;

namespace WF_ModerUI
{
    public partial class frmImportacaoProtestos : Form
    {
        public frmImportacaoProtestos()
        {
            InitializeComponent();
        }

        private void btnSelecionarArquivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "Arquivos de Texto | *.txt"
            };
            DialogResult result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtCaminhoArquivo.Text = fileDialog.FileName;
                btnImportarArquivo.Enabled = true;
            }
        }

        private async void btnImportarArquivo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCaminhoArquivo.Text))
            {
                if (File.Exists(txtCaminhoArquivo.Text))
                {
                    pbImportacao.Maximum = File.ReadAllLines(txtCaminhoArquivo.Text).Count();
                    pbImportacao.Step = 1;
                    StreamReader streamArq = new StreamReader(txtCaminhoArquivo.Text);
                    int numeroLinha = 1;
                    string sLine = string.Empty;
                    string[] dados;

                    while (sLine != null)
                    {
                        sLine = streamArq.ReadLine();

                        if (sLine != null)
                        {
                            dados = sLine.Split(("\t").ToCharArray());

                            if (numeroLinha > 1)
                            {
                                // Bancos
                                Bancos banco = new Bancos
                                {
                                    Codigo = Convert.ToInt32(dados[0]),
                                    CodigoInterno = dados[1],
                                    Nome = dados[2]
                                };
                                await new BancoBLL().SalvarBanco(Program.UrlApi, banco);

                                BancoBLL listabanco = new BancoBLL();
                                await listabanco.GetBancosAsync(Program.UrlApi);
                                int codigoBanco = listabanco.listaBancos.Max(x => x.idBanco);

                                // UFs
                                 UFs uf = new UFs
                                {
                                    Descricao = dados[11]                  
                                };
                                await new UFBLL().SalvarUF(Program.UrlApi, uf);

                                UFBLL listauf = new UFBLL();
                                await listauf.GetUfsAsync(Program.UrlApi);
                                int codigoUf = listauf.listaUfs.Max(x => x.idUf);

                                // Cidades
                                Cidades cidade = new Cidades
                                {
                                    Descricao = dados[11]
                                    ,
                                    UF = codigoUf

                                };
                                await new CidadeBLL().SalvarCidade(Program.UrlApi, cidade);

                                CidadeBLL listacidade = new CidadeBLL();
                                await listacidade.GetCidadesAsync(Program.UrlApi);
                                int codigoCidade = listacidade.listaCidades.Max(x => x.idCidade);

                                // Devedores
                                Devedores devedor = new Devedores
                                {
                                    Nome = dados[5]
                                    ,
                                    CPF_CNPJ = dados[6]
                                    
                                };
                                await new DevedorBLL().SalvarDevedor(Program.UrlApi, devedor);

                                DevedorBLL listaDevedor = new DevedorBLL();
                                await listaDevedor.GetDevedoresAsync(Program.UrlApi);
                                int codigoDevedor = listaDevedor.listaDevedores.Max(x => x.idDevedor);

                                // DevedoresEnderecos
                                DevedoresEnderecos devedorendereco = new DevedoresEnderecos
                                {
                                    Devedor = codigoDevedor
                                    ,
                                    Cidade = codigoCidade
                                    ,
                                    Endereco = dados[7]
                                    ,
                                    Bairro = dados[8]
                                    ,
                                    CEP = dados[10]

                                };
                                await new DevedorEnderecoBLL().SalvarDevedorEndereco(Program.UrlApi, devedorendereco);

                                DevedorEnderecoBLL listadevedorendereco = new DevedorEnderecoBLL();
                                await listadevedorendereco.GetDevedoresEnderecosAsync(Program.UrlApi);
                                int codigoDevedorEndereco = listadevedorendereco.listaDevedoresEnderecos.Max(x => x.idDevedorEndereco);

                                // PracasPagamentos
                                PracasPagamentos pracapagamento = new PracasPagamentos
                                {
                                    Cidade = codigoCidade
                                    ,
                                    Descricao = dados[12]
                                };
                                await new PracaPagamentoBLL().SalvarPracaPagamento(Program.UrlApi, pracapagamento);

                                PracaPagamentoBLL listapracapagamento = new PracaPagamentoBLL();
                                await listapracapagamento.GetPracasPagamentosAsync(Program.UrlApi);
                                int codigoPracaPagamento = listapracapagamento.listaPracasPagamentos.Max(x => x.idPracaPagamento);

                                //Contratos
                                Contratos contrato = new Contratos
                                {
                                    PracaPagamento = codigoPracaPagamento,

                                    Banco = codigoBanco
                                   ,
                                    Devedor = codigoDevedor
                                   ,
                                    Numero = dados[3]
                                   ,
                                    QtdParcelas = string.IsNullOrEmpty(dados[21]) ? 0 : Convert.ToInt32(dados[21])
                                   ,
                                    ValorPrimeiraParcela = string.IsNullOrEmpty(dados[20]) ? 0 : Convert.ToDecimal(dados[20])
                                    ,
                                    Valor = string.IsNullOrEmpty(dados[14]) ? 0 : Convert.ToDecimal(dados[14])
                                };
                                await new ContratoBLL().SalvarContrato(Program.UrlApi, contrato);

                                ContratoBLL listacontrato = new ContratoBLL();
                                await listacontrato.GetContratosAsync(Program.UrlApi);
                                int codigoContrato = listacontrato.listaContratos.Max(x => x.idContrato);

                                // ContratosParcelas
                                ContratosParcelas contratoparcela = new ContratosParcelas
                                {
                                    Contrato = codigoContrato
                                    ,
                                    Parcela = Convert.ToInt32(dados[4])
                                };
                                await new ContratoParcelaBLL().SalvarContratoParcela(Program.UrlApi, contratoparcela);

                                ContratoParcelaBLL listacontratoparcela = new ContratoParcelaBLL();
                                await listacontratoparcela.GetContratosParcelasAsync(Program.UrlApi);
                                int codigoContratoParcela = listacontratoparcela.listaContratosParcelas.Max(x => x.idContratoParcela);

                                // Protestos
                                Protestos protesto = new Protestos
                                {
                                    Contrato = codigoContrato
                                    ,
                                    Valor = string.IsNullOrEmpty(dados[15]) ? 0 : Convert.ToDecimal(dados[15])
                                    ,
                                    TipoDocumento = dados[18]
                                    ,
                                    Operacao = dados[19]

                                };

                                if (!string.IsNullOrEmpty(dados[16]))
                                {
                                    protesto.DataEmissao = Convert.ToDateTime(dados[16]);
                                }
                                if (!string.IsNullOrEmpty(dados[17]))
                                {
                                    protesto.Vencimento = Convert.ToDateTime(dados[17]);
                                };
                    
                                await new ProtestoBLL().SalvarProtesto(Program.UrlApi, protesto);

                                ProtestoBLL listaprotesto = new ProtestoBLL();
                                await listaprotesto.GetProtestosAsync(Program.UrlApi);
                                int codigoprotesto = listaprotesto.listaProtestos.Max(x => x.idProtesto);
                            }
                        }
                        numeroLinha++;
                        pbImportacao.Value = numeroLinha-2;
                    }
                    streamArq.Close();          
                    MessageBox.Show("Importação realizada com sucesso!");
                }
                else
                {
                    MessageBox.Show("Arquivo não encontrado!");
                }
            }
        }
    }
}
