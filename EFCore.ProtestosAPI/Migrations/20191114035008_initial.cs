using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.ProtestosAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bancos",
                columns: table => new
                {
                    idBanco = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Codigo = table.Column<int>(nullable: false),
                    CodigoInterno = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bancos", x => x.idBanco);
                });

            migrationBuilder.CreateTable(
                name: "Devedores",
                columns: table => new
                {
                    idDevedor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    CPF_CNPJ = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devedores", x => x.idDevedor);
                });

            migrationBuilder.CreateTable(
                name: "UFs",
                columns: table => new
                {
                    idUf = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UFs", x => x.idUf);
                });

            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    idCidade = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true),
                    UFidUf = table.Column<int>(nullable: true),
                    idUF = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.idCidade);
                    table.ForeignKey(
                        name: "FK_Cidades_UFs_UFidUf",
                        column: x => x.UFidUf,
                        principalTable: "UFs",
                        principalColumn: "idUf",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PracasPagamentos",
                columns: table => new
                {
                    idPracaPagamento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CidadeidCidade = table.Column<int>(nullable: true),
                    idCidade = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracasPagamentos", x => x.idPracaPagamento);
                    table.ForeignKey(
                        name: "FK_PracasPagamentos_Cidades_CidadeidCidade",
                        column: x => x.CidadeidCidade,
                        principalTable: "Cidades",
                        principalColumn: "idCidade",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_UFidUf",
                table: "Cidades",
                column: "UFidUf");

            migrationBuilder.CreateIndex(
                name: "IX_PracasPagamentos_CidadeidCidade",
                table: "PracasPagamentos",
                column: "CidadeidCidade");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bancos");

            migrationBuilder.DropTable(
                name: "Devedores");

            migrationBuilder.DropTable(
                name: "PracasPagamentos");

            migrationBuilder.DropTable(
                name: "Cidades");

            migrationBuilder.DropTable(
                name: "UFs");
        }
    }
}
