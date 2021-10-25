using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FastFoodRestaurant.Migrations
{
    public partial class Migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Carrito",
                columns: table => new
                {
                    carrito_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cantidadP = table.Column<int>(type: "int", nullable: false),
                    usuario_FK = table.Column<int>(type: "int", nullable: false),
                    combo_FK = table.Column<int>(type: "int", nullable: false),
                    producto_Fk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Carrito", x => x.carrito_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_DetalleCombo",
                columns: table => new
                {
                    detalleCombo_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cantidadP = table.Column<int>(type: "int", nullable: false),
                    combo_FK = table.Column<int>(type: "int", nullable: false),
                    producto_Fk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_DetalleCombo", x => x.detalleCombo_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_DetalleOrden",
                columns: table => new
                {
                    detalleOden_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    totalFinal = table.Column<double>(type: "float", nullable: false),
                    orden_FK = table.Column<int>(type: "int", nullable: false),
                    combo_FK = table.Column<int>(type: "int", nullable: false),
                    producto_Fk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_DetalleOrden", x => x.detalleOden_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Documento",
                columns: table => new
                {
                    documento_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Documento", x => x.documento_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Domicilio",
                columns: table => new
                {
                    domicilio_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    referencia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Domicilio", x => x.domicilio_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Menu",
                columns: table => new
                {
                    menu_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreMenu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Menu", x => x.menu_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_MetodoPago",
                columns: table => new
                {
                    metodoPago_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreMetodo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_MetodoPago", x => x.metodoPago_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_RolUsuarios",
                columns: table => new
                {
                    rol_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreRol = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_RolUsuarios", x => x.rol_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Combo",
                columns: table => new
                {
                    menu_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codCombo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nombreCombo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    precioC = table.Column<double>(type: "float", nullable: false),
                    fechaCreacionC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    estadoCombo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    menu_Fk = table.Column<int>(type: "int", nullable: false),
                    tbl_Menumenu_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Combo", x => x.menu_id);
                    table.ForeignKey(
                        name: "FK_tbl_Combo_tbl_Menu_tbl_Menumenu_id",
                        column: x => x.tbl_Menumenu_id,
                        principalTable: "tbl_Menu",
                        principalColumn: "menu_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Producto",
                columns: table => new
                {
                    producto_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codProducto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nombreProducto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    precioP = table.Column<double>(type: "float", nullable: false),
                    fechaCreacionP = table.Column<DateTime>(type: "datetime2", nullable: false),
                    estadoProducto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    menu_Fk = table.Column<int>(type: "int", nullable: false),
                    tbl_Menumenu_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Producto", x => x.producto_id);
                    table.ForeignKey(
                        name: "FK_tbl_Producto_tbl_Menu_tbl_Menumenu_id",
                        column: x => x.tbl_Menumenu_id,
                        principalTable: "tbl_Menu",
                        principalColumn: "menu_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Orden",
                columns: table => new
                {
                    orden_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codOrden = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fechaOrden = table.Column<DateTime>(type: "datetime2", nullable: false),
                    estadoOrden = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_FK = table.Column<int>(type: "int", nullable: false),
                    metodoPago_FK = table.Column<int>(type: "int", nullable: false),
                    documento_Fk = table.Column<int>(type: "int", nullable: false),
                    tbl_Documentodocumento_id = table.Column<int>(type: "int", nullable: true),
                    tbl_MetodoPagometodoPago_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Orden", x => x.orden_id);
                    table.ForeignKey(
                        name: "FK_tbl_Orden_tbl_Documento_tbl_Documentodocumento_id",
                        column: x => x.tbl_Documentodocumento_id,
                        principalTable: "tbl_Documento",
                        principalColumn: "documento_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Orden_tbl_MetodoPago_tbl_MetodoPagometodoPago_id",
                        column: x => x.tbl_MetodoPagometodoPago_id,
                        principalTable: "tbl_MetodoPago",
                        principalColumn: "metodoPago_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_User",
                columns: table => new
                {
                    usuario_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellidoU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    correoU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contraU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    domicilio_Fk = table.Column<int>(type: "int", nullable: false),
                    rolUsuario_Fk = table.Column<int>(type: "int", nullable: false),
                    tbl_Domiciliodomicilio_id = table.Column<int>(type: "int", nullable: true),
                    tbl_RolUsuariorol_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_User", x => x.usuario_id);
                    table.ForeignKey(
                        name: "FK_tbl_User_tbl_Domicilio_tbl_Domiciliodomicilio_id",
                        column: x => x.tbl_Domiciliodomicilio_id,
                        principalTable: "tbl_Domicilio",
                        principalColumn: "domicilio_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_User_tbl_RolUsuarios_tbl_RolUsuariorol_id",
                        column: x => x.tbl_RolUsuariorol_id,
                        principalTable: "tbl_RolUsuarios",
                        principalColumn: "rol_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Combo_tbl_Menumenu_id",
                table: "tbl_Combo",
                column: "tbl_Menumenu_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Orden_tbl_Documentodocumento_id",
                table: "tbl_Orden",
                column: "tbl_Documentodocumento_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Orden_tbl_MetodoPagometodoPago_id",
                table: "tbl_Orden",
                column: "tbl_MetodoPagometodoPago_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Producto_tbl_Menumenu_id",
                table: "tbl_Producto",
                column: "tbl_Menumenu_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_User_tbl_Domiciliodomicilio_id",
                table: "tbl_User",
                column: "tbl_Domiciliodomicilio_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_User_tbl_RolUsuariorol_id",
                table: "tbl_User",
                column: "tbl_RolUsuariorol_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Carrito");

            migrationBuilder.DropTable(
                name: "tbl_Combo");

            migrationBuilder.DropTable(
                name: "tbl_DetalleCombo");

            migrationBuilder.DropTable(
                name: "tbl_DetalleOrden");

            migrationBuilder.DropTable(
                name: "tbl_Orden");

            migrationBuilder.DropTable(
                name: "tbl_Producto");

            migrationBuilder.DropTable(
                name: "tbl_User");

            migrationBuilder.DropTable(
                name: "tbl_Documento");

            migrationBuilder.DropTable(
                name: "tbl_MetodoPago");

            migrationBuilder.DropTable(
                name: "tbl_Menu");

            migrationBuilder.DropTable(
                name: "tbl_Domicilio");

            migrationBuilder.DropTable(
                name: "tbl_RolUsuarios");
        }
    }
}
