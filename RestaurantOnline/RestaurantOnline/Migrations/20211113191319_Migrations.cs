using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantOnline.Migrations
{
    public partial class Migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    estadoCombo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Combo", x => x.menu_id);
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
                    referencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usuario_Fk = table.Column<int>(type: "int", nullable: false)
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
                    rolUser_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreRol = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_RolUsuarios", x => x.rolUser_id);
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
                    Tbl_Menumenu_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Producto", x => x.producto_id);
                    table.ForeignKey(
                        name: "FK_tbl_Producto_tbl_Menu_Tbl_Menumenu_id",
                        column: x => x.Tbl_Menumenu_id,
                        principalTable: "tbl_Menu",
                        principalColumn: "menu_id",
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
                    telefonoU = table.Column<int>(type: "int", nullable: true),
                    correoU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contraU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    encryptionU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rolUser_Fk = table.Column<int>(type: "int", nullable: false),
                    Tbl_RolUsuariorolUser_id = table.Column<int>(type: "int", nullable: true),
                    tbl_Domiciliodomicilio_id = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_tbl_User_tbl_RolUsuarios_Tbl_RolUsuariorolUser_id",
                        column: x => x.Tbl_RolUsuariorolUser_id,
                        principalTable: "tbl_RolUsuarios",
                        principalColumn: "rolUser_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_DetalleCombo",
                columns: table => new
                {
                    detalleCombo_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cantidadP = table.Column<int>(type: "int", nullable: false),
                    producto_Fk = table.Column<int>(type: "int", nullable: false),
                    combo_FK = table.Column<int>(type: "int", nullable: false),
                    Tbl_Productoproducto_id = table.Column<int>(type: "int", nullable: true),
                    Tbl_Combomenu_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_DetalleCombo", x => x.detalleCombo_id);
                    table.ForeignKey(
                        name: "FK_tbl_DetalleCombo_tbl_Combo_Tbl_Combomenu_id",
                        column: x => x.Tbl_Combomenu_id,
                        principalTable: "tbl_Combo",
                        principalColumn: "menu_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_DetalleCombo_tbl_Producto_Tbl_Productoproducto_id",
                        column: x => x.Tbl_Productoproducto_id,
                        principalTable: "tbl_Producto",
                        principalColumn: "producto_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Carrito",
                columns: table => new
                {
                    carrito_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cantidadP = table.Column<int>(type: "int", nullable: false),
                    totalP = table.Column<double>(type: "float", nullable: false),
                    usuario_FK = table.Column<int>(type: "int", nullable: false),
                    combo_FK = table.Column<int>(type: "int", nullable: false),
                    producto_Fk = table.Column<int>(type: "int", nullable: false),
                    Tbl_Userusuario_id = table.Column<int>(type: "int", nullable: true),
                    Tbl_Combomenu_id = table.Column<int>(type: "int", nullable: true),
                    Tbl_Productoproducto_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Carrito", x => x.carrito_id);
                    table.ForeignKey(
                        name: "FK_tbl_Carrito_tbl_Combo_Tbl_Combomenu_id",
                        column: x => x.Tbl_Combomenu_id,
                        principalTable: "tbl_Combo",
                        principalColumn: "menu_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Carrito_tbl_Producto_Tbl_Productoproducto_id",
                        column: x => x.Tbl_Productoproducto_id,
                        principalTable: "tbl_Producto",
                        principalColumn: "producto_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Carrito_tbl_User_Tbl_Userusuario_id",
                        column: x => x.Tbl_Userusuario_id,
                        principalTable: "tbl_User",
                        principalColumn: "usuario_id",
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
                    Tbl_Userusuario_id = table.Column<int>(type: "int", nullable: true),
                    Tbl_MetodoPagometodoPago_id = table.Column<int>(type: "int", nullable: true),
                    Tbl_Documentodocumento_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Orden", x => x.orden_id);
                    table.ForeignKey(
                        name: "FK_tbl_Orden_tbl_Documento_Tbl_Documentodocumento_id",
                        column: x => x.Tbl_Documentodocumento_id,
                        principalTable: "tbl_Documento",
                        principalColumn: "documento_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Orden_tbl_MetodoPago_Tbl_MetodoPagometodoPago_id",
                        column: x => x.Tbl_MetodoPagometodoPago_id,
                        principalTable: "tbl_MetodoPago",
                        principalColumn: "metodoPago_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Orden_tbl_User_Tbl_Userusuario_id",
                        column: x => x.Tbl_Userusuario_id,
                        principalTable: "tbl_User",
                        principalColumn: "usuario_id",
                        onDelete: ReferentialAction.Restrict);
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
                    producto_Fk = table.Column<int>(type: "int", nullable: false),
                    Tbl_Ordenorden_id = table.Column<int>(type: "int", nullable: true),
                    Tbl_Combomenu_id = table.Column<int>(type: "int", nullable: true),
                    Tbl_Productoproducto_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_DetalleOrden", x => x.detalleOden_id);
                    table.ForeignKey(
                        name: "FK_tbl_DetalleOrden_tbl_Combo_Tbl_Combomenu_id",
                        column: x => x.Tbl_Combomenu_id,
                        principalTable: "tbl_Combo",
                        principalColumn: "menu_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_DetalleOrden_tbl_Orden_Tbl_Ordenorden_id",
                        column: x => x.Tbl_Ordenorden_id,
                        principalTable: "tbl_Orden",
                        principalColumn: "orden_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_DetalleOrden_tbl_Producto_Tbl_Productoproducto_id",
                        column: x => x.Tbl_Productoproducto_id,
                        principalTable: "tbl_Producto",
                        principalColumn: "producto_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Carrito_Tbl_Combomenu_id",
                table: "tbl_Carrito",
                column: "Tbl_Combomenu_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Carrito_Tbl_Productoproducto_id",
                table: "tbl_Carrito",
                column: "Tbl_Productoproducto_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Carrito_Tbl_Userusuario_id",
                table: "tbl_Carrito",
                column: "Tbl_Userusuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DetalleCombo_Tbl_Combomenu_id",
                table: "tbl_DetalleCombo",
                column: "Tbl_Combomenu_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DetalleCombo_Tbl_Productoproducto_id",
                table: "tbl_DetalleCombo",
                column: "Tbl_Productoproducto_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DetalleOrden_Tbl_Combomenu_id",
                table: "tbl_DetalleOrden",
                column: "Tbl_Combomenu_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DetalleOrden_Tbl_Ordenorden_id",
                table: "tbl_DetalleOrden",
                column: "Tbl_Ordenorden_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DetalleOrden_Tbl_Productoproducto_id",
                table: "tbl_DetalleOrden",
                column: "Tbl_Productoproducto_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Orden_Tbl_Documentodocumento_id",
                table: "tbl_Orden",
                column: "Tbl_Documentodocumento_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Orden_Tbl_MetodoPagometodoPago_id",
                table: "tbl_Orden",
                column: "Tbl_MetodoPagometodoPago_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Orden_Tbl_Userusuario_id",
                table: "tbl_Orden",
                column: "Tbl_Userusuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Producto_Tbl_Menumenu_id",
                table: "tbl_Producto",
                column: "Tbl_Menumenu_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_User_tbl_Domiciliodomicilio_id",
                table: "tbl_User",
                column: "tbl_Domiciliodomicilio_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_User_Tbl_RolUsuariorolUser_id",
                table: "tbl_User",
                column: "Tbl_RolUsuariorolUser_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Carrito");

            migrationBuilder.DropTable(
                name: "tbl_DetalleCombo");

            migrationBuilder.DropTable(
                name: "tbl_DetalleOrden");

            migrationBuilder.DropTable(
                name: "tbl_Combo");

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
                name: "tbl_Domicilio");

            migrationBuilder.DropTable(
                name: "tbl_RolUsuarios");
        }
    }
}
