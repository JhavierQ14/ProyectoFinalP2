using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantOnline.Migrations
{
    public partial class Migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "tbl_RolUsuario",
                columns: table => new
                {
                    rolUser_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreRol = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_RolUsuario", x => x.rolUser_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Producto",
                columns: table => new
                {
                    producto_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codProducto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nombreProducto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    precioP = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    fechaCreacionP = table.Column<DateTime>(type: "datetime2", nullable: true),
                    estadoProducto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imageP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    menu_Fk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Producto", x => x.producto_id);
                    table.ForeignKey(
                        name: "FK_tbl_Producto_tbl_Menu_menu_Fk",
                        column: x => x.menu_Fk,
                        principalTable: "tbl_Menu",
                        principalColumn: "menu_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_User",
                columns: table => new
                {
                    usuario_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellidoU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefonoU = table.Column<int>(type: "int", nullable: true),
                    correoU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contraU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    encryptionU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rolUser_Fk = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_User", x => x.usuario_id);
                    table.ForeignKey(
                        name: "FK_tbl_User_tbl_RolUsuario_rolUser_Fk",
                        column: x => x.rolUser_Fk,
                        principalTable: "tbl_RolUsuario",
                        principalColumn: "rolUser_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Carrito",
                columns: table => new
                {
                    carrito_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cantidadP = table.Column<int>(type: "int", nullable: true),
                    totalP = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    usuario_Fk = table.Column<int>(type: "int", nullable: false),
                    producto_Fk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Carrito", x => x.carrito_id);
                    table.ForeignKey(
                        name: "FK_tbl_Carrito_tbl_Producto_producto_Fk",
                        column: x => x.producto_Fk,
                        principalTable: "tbl_Producto",
                        principalColumn: "producto_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Carrito_tbl_User_usuario_Fk",
                        column: x => x.usuario_Fk,
                        principalTable: "tbl_User",
                        principalColumn: "usuario_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Domicilio",
                columns: table => new
                {
                    domicilio_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    referencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usuario_Fk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Domicilio", x => x.domicilio_id);
                    table.ForeignKey(
                        name: "FK_tbl_Domicilio_tbl_User_usuario_Fk",
                        column: x => x.usuario_Fk,
                        principalTable: "tbl_User",
                        principalColumn: "usuario_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Orden",
                columns: table => new
                {
                    orden_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codOrden = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fechaOrden = table.Column<DateTime>(type: "datetime2", nullable: true),
                    estadoOrden = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_FK = table.Column<int>(type: "int", nullable: false),
                    metodoPago_FK = table.Column<int>(type: "int", nullable: false),
                    documento_Fk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Orden", x => x.orden_id);
                    table.ForeignKey(
                        name: "FK_tbl_Orden_tbl_Documento_documento_Fk",
                        column: x => x.documento_Fk,
                        principalTable: "tbl_Documento",
                        principalColumn: "documento_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Orden_tbl_MetodoPago_metodoPago_FK",
                        column: x => x.metodoPago_FK,
                        principalTable: "tbl_MetodoPago",
                        principalColumn: "metodoPago_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Orden_tbl_User_user_FK",
                        column: x => x.user_FK,
                        principalTable: "tbl_User",
                        principalColumn: "usuario_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_DetalleOrden",
                columns: table => new
                {
                    detalleOden_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cantidad = table.Column<int>(type: "int", nullable: true),
                    totalFinal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    orden_FK = table.Column<int>(type: "int", nullable: false),
                    producto_Fk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_DetalleOrden", x => x.detalleOden_id);
                    table.ForeignKey(
                        name: "FK_tbl_DetalleOrden_tbl_Orden_orden_FK",
                        column: x => x.orden_FK,
                        principalTable: "tbl_Orden",
                        principalColumn: "orden_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_DetalleOrden_tbl_Producto_producto_Fk",
                        column: x => x.producto_Fk,
                        principalTable: "tbl_Producto",
                        principalColumn: "producto_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Carrito_producto_Fk",
                table: "tbl_Carrito",
                column: "producto_Fk");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Carrito_usuario_Fk",
                table: "tbl_Carrito",
                column: "usuario_Fk");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DetalleOrden_orden_FK",
                table: "tbl_DetalleOrden",
                column: "orden_FK");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DetalleOrden_producto_Fk",
                table: "tbl_DetalleOrden",
                column: "producto_Fk");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Domicilio_usuario_Fk",
                table: "tbl_Domicilio",
                column: "usuario_Fk");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Orden_documento_Fk",
                table: "tbl_Orden",
                column: "documento_Fk");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Orden_metodoPago_FK",
                table: "tbl_Orden",
                column: "metodoPago_FK");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Orden_user_FK",
                table: "tbl_Orden",
                column: "user_FK");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Producto_menu_Fk",
                table: "tbl_Producto",
                column: "menu_Fk");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_User_rolUser_Fk",
                table: "tbl_User",
                column: "rolUser_Fk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Carrito");

            migrationBuilder.DropTable(
                name: "tbl_DetalleOrden");

            migrationBuilder.DropTable(
                name: "tbl_Domicilio");

            migrationBuilder.DropTable(
                name: "tbl_Orden");

            migrationBuilder.DropTable(
                name: "tbl_Producto");

            migrationBuilder.DropTable(
                name: "tbl_Documento");

            migrationBuilder.DropTable(
                name: "tbl_MetodoPago");

            migrationBuilder.DropTable(
                name: "tbl_User");

            migrationBuilder.DropTable(
                name: "tbl_Menu");

            migrationBuilder.DropTable(
                name: "tbl_RolUsuario");
        }
    }
}
