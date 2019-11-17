using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using EFCore.Dominio;
using EFCore.WinForms.BLL;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;


namespace WF_ModerUI
{
    public partial class frmProtestos : Form
    {
        public frmProtestos()
        {
            InitializeComponent();
            CarregarDadosGrid();
            cmbPesquisa.SelectedIndex = -1;
            PreencherContratos();
            btSalvar.Enabled = false;
        }

        public List<Protestos> listaProtestos = null;
        public Protestos protesto = null;
        public bool resultado = false;
        public int IdProtesto = 0;
        List<String> listaProtesto = null;

        public async Task<List<Protestos>> GetProtestosAsync(string webApi)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(webApi + "GetListaProtestos");
                listaProtestos = JsonConvert.DeserializeObject<List<Protestos>>(response);
                return listaProtestos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Protestos> GetProtestoAsync(string webApi, int idProtesto)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(webApi + "GetProtesto/" + idProtesto);
                protesto = JsonConvert.DeserializeObject<Protestos>(response);
                var protestos = protesto;
                List<string> protestoList = new List<string>(protestos.ToString().Split(','));
                listaProtesto = protestoList;
                return protesto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Protestos> GetProtestoContratoAsync(string webApi, int idContrato)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(webApi + "GetProtestoContrato/" + idContrato);
                protesto = JsonConvert.DeserializeObject<Protestos>(response);
                return protesto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async void CarregarDadosGrid()
        {
            await GetProtestosAsync(Program.UrlApi);
            dgvDados.DataSource = listaProtestos;
        }


        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            FiltrarPesquisa();
        }

        private async void FiltrarPesquisa()
        {
            if ((cmbPesquisa.SelectedIndex == 0) && (txtPesquisa.Text != ""))
            {
                await GetProtestoAsync(Program.UrlApi, Convert.ToInt32(txtPesquisa.Text));
                dgvDados.DataSource = listaProtesto;
            }
            else if (cmbPesquisa.SelectedIndex == 1)
            {
                await GetProtestoContratoAsync(Program.UrlApi, Convert.ToInt32(txtPesquisa.Text));
                dgvDados.DataSource = listaProtestos;
            }
            else
            {
                CarregarDadosGrid();
            }
        }

        private void dgvDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IdProtesto = Convert.ToInt32(dgvDados.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtProtestoId.Text = dgvDados.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtValorProtestar.Text = dgvDados.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtDataVencimento.Text = dgvDados.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtDataEmissao.Text = dgvDados.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtOperacao.Text = dgvDados.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtTipoDocumento.Text = dgvDados.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
            catch
            {
            }
        }

        private void btIncluir_Click(object sender, EventArgs e)
        {
            LimparDados();
            btExcluir.Enabled = false;
            btAlterar.Enabled = false;
            btIncluir.Enabled = false;
            btSalvar.Enabled = true;
        }

        private void LimparDados()
        {
            txtProtestoId.Text = "";
            cmbContrato.SelectedIndex = -1;
            txtValorProtestar.Text = "";
            txtDataVencimento.Text = "";
            txtDataEmissao.Text = "";
            txtOperacao.Text = "";
            txtTipoDocumento.Text = "";
            dgvDados.DataSource = null;
        }
        private async void PreencherContratos()
        {
            cmbContrato.DataSource = null;
            cmbContrato.Items.Clear();

            ContratoBLL contrato = new ContratoBLL();
            await contrato.GetContratosAsync(Program.UrlApi);

            cmbContrato.DataSource = contrato.listaContratos;
            cmbContrato.ValueMember = "idContrato";
            cmbContrato.DisplayMember = "numero";
            cmbContrato.SelectedIndex = -1;
        }

        private async void btSalvar_Click(object sender, EventArgs e)
        {
            btSalvar.Enabled = true;
            btExcluir.Enabled = true;
            btIncluir.Enabled = true;
            btAlterar.Enabled = true;
            bool retorno = await AplicarAlteracoes();
        }

        private void txtValorProtestar_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtValorProtestar.Text))
            {
                if (!decimal.TryParse(txtValorProtestar.Text, out decimal codigo))
                {
                    MessageBox.Show("O Valor para Protestar deve conter apenas números e vírgula!");
                    txtValorProtestar.Clear();
                    txtValorProtestar.Focus();
                }
            }
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            btSalvar.Enabled = true;
            btExcluir.Enabled = false;
            btIncluir.Enabled = false;
            btAlterar.Enabled = false;
        }

        private async void btExcluir_Click(object sender, EventArgs e)
        {
            btSalvar.Enabled = false;
            btAlterar.Enabled = false;
            btIncluir.Enabled = false;

            DialogResult result = MessageBox.Show("Confirma a exclusão?", "Confirmação?", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
            {
                return;
            }

            int idProtesto = string.IsNullOrEmpty(txtProtestoId.Text) ? 0 : Convert.ToInt32(txtProtestoId.Text);

            ProtestoBLL protestoBLL = new ProtestoBLL();
            await protestoBLL.DeleteProtestoAsync(Program.UrlApi, idProtesto);

            if (protestoBLL.resultado)
            {
                MessageBox.Show("Dados excluídos com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show("Não foi possível excluir os dados, operação cancelada!", "Operação Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async Task<bool> AplicarAlteracoes()
        {
            try
            {
                Protestos protesto = new Protestos
                {
                    idProtesto = string.IsNullOrEmpty(txtProtestoId.Text) ? 0 : Convert.ToInt32(txtProtestoId.Text),
                    Contrato = cmbContrato.SelectedValue == null ? 0 : Convert.ToInt32(cmbContrato.SelectedValue),
                    Valor = string.IsNullOrEmpty(txtValorProtestar.Text) ? 0 : Convert.ToDecimal(txtValorProtestar.Text),
                    TipoDocumento = txtTipoDocumento.Text.Trim(),
                    Operacao = txtOperacao.Text.Trim()
                };

                if (!string.IsNullOrEmpty(txtDataEmissao.Text))
                {
                    protesto.DataEmissao = Convert.ToDateTime(txtDataEmissao.Text);
                }

                if (!string.IsNullOrEmpty(txtDataEmissao.Text))
                {
                    protesto.Vencimento = Convert.ToDateTime(txtDataEmissao.Text);
                }

                ProtestoBLL protestobll = new ProtestoBLL();
                await protestobll.SalvarProtesto(Program.UrlApi, protesto);

                if (protestobll.resultado)
                {
                    MessageBox.Show("Dados salvos com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                    return true;
                }
                else
                {
                    MessageBox.Show("Não foi possível salvar os dados, operação cancelada!", "Operação Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void txtDataVencimento_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDataVencimento.Text))
            {
                if (!DateTime.TryParse(txtDataVencimento.Text, out DateTime data))
                {
                    MessageBox.Show("A Data de Vencimento não foi preenchida corretamente!");
                    txtDataVencimento.Clear();
                    txtDataVencimento.Focus();
                }
            }
        }

        private void txtDataEmissao_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDataEmissao.Text))
            {
                if (!DateTime.TryParse(txtDataEmissao.Text, out DateTime data))
                    {
                        MessageBox.Show("A Data de Emissão não foi preenchida corretamente!");
                        txtDataEmissao.Clear();
                        txtDataEmissao.Focus();
                    }
                }        
        }

    }
 }


