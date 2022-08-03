using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PS.AccessData.Migrations
{
    public partial class Migration_001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    PeliculaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Poster = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Sinopsis = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Trailer = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.PeliculaId);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    SalaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.SalaId);
                });

            migrationBuilder.CreateTable(
                name: "Funciones",
                columns: table => new
                {
                    FuncionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeliculaId = table.Column<int>(type: "int", nullable: false),
                    SalaId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Horario = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funciones", x => x.FuncionId);
                    table.ForeignKey(
                        name: "FK_Funciones_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "PeliculaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funciones_Salas_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Salas",
                        principalColumn: "SalaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuncionId = table.Column<int>(type: "int", nullable: false),
                    FuncionesFuncionId = table.Column<int>(type: "int", nullable: true),
                    Usuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => new { x.TicketId, x.FuncionId });
                    table.ForeignKey(
                        name: "FK_Tickets_Funciones_FuncionesFuncionId",
                        column: x => x.FuncionesFuncionId,
                        principalTable: "Funciones",
                        principalColumn: "FuncionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "PeliculaId", "Poster", "Sinopsis", "Titulo", "Trailer" },
                values: new object[,]
                {
                    { 1, "https://m.media-amazon.com/images/M/MV5BMjM2MDgxMDg0Nl5BMl5BanBnXkFtZTgwNTM2OTM5NDE@._V1_FMjpg_UX667_.jpg", "Un paleontólogo pragmático que visita un parque temático casi completo tiene la tarea de proteger a un par de niños después de que un corte de energía provoque que los dinosaurios clonados del parque se suelten.", "Jurassic Park", "https://www.youtube.com/embed/lc0UehYemQA" },
                    { 2, "https://m.media-amazon.com/images/M/MV5BMjNkMzc2N2QtNjVlNS00ZTk5LTg0MTgtODY2MDAwNTMwZjBjXkEyXkFqcGdeQXVyNDk3NzU2MTQ@._V1_FMjpg_UY720_.jpg", "En 1938, después de la desaparición de su padre el profesor Henry Jones Senior en su búsqueda del Santo Grial, Indiana Jones se enfrenta de nuevo a los Nazis para que evitar que obtengan sus poderes.", "Indiana Jones and the Last Crusade", "https://www.youtube.com/embed/sagmdpkWUqc" },
                    { 3, "https://m.media-amazon.com/images/M/MV5BZDVjN2FkYTQtNTBlOC00MjM5LTgzMWEtZWRlNGUyYmNiOTFiXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_FMjpg_UX467_.jpg", "Un niño rompe inadvertidamente tres reglas importantes sobre su nueva mascota y provoca una horda de monstruos malévolos y traviesos en una pequeña ciudad.", "Gremlins", "https://www.youtube.com/embed/XBEVwaJEgaA" },
                    { 4, "https://m.media-amazon.com/images/M/MV5BZmU0M2Y1OGUtZjIxNi00ZjBkLTg1MjgtOWIyNThiZWIwYjRiXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_FMjpg_UX1218_.jpg", "Marty McFly, un estudiante de secundaria de 17 años, es enviado accidentalmente treinta años atrás en un DeLorean que viaja en el tiempo inventado por su amigo íntimo, el científico disidente Doc Brown.", "Back to the Future", "https://www.youtube.com/embed/qvsgGtivCgs" },
                    { 5, "https://m.media-amazon.com/images/M/MV5BMTY3MjM1Mzc4N15BMl5BanBnXkFtZTgwODM0NzAxMDE@._V1_FMjpg_UX878_.jpg", "En el futuro, el sádico líder de una banda es encarcelado y se ofrece como voluntario para un experimento de reeducación, pero no sale según lo planeado.", "Clockwork Orange", "https://www.youtube.com/embed/T54uZPI4Z8A" },
                    { 6, "https://m.media-amazon.com/images/M/MV5BZWMxOTEzMjktYjE3NC00NmZjLThlNzYtMDE3MDlmNWVmZTZkXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_FMjpg_UX871_.jpg", "Los tomates, hartos de tantos años de acabar como sofrito o bloody mary, están cobrando vida y están asesinando a los humanos. Se sospecha que este hecho está provocado por un pesticida creado por un loco que quiere el control del mundo.", "Attack of the Killer Tomatoes!", "https://www.youtube.com/embed/txfdGlxEsG8" },
                    { 7, "https://m.media-amazon.com/images/M/MV5BZDdmNjBlYTctNWU0MC00ODQxLWEzNDQtZGY1NmRhYjNmNDczXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_FMjpg_UX1005_.jpg", "Un matrimonio recientemente fallecido le encarga a un extraño demonio que saque a una insoportable familia de su hogar.", "Beetlejuice", "https://www.youtube.com/embed/ickbVzajrk0" },
                    { 8, "https://m.media-amazon.com/images/M/MV5BMTY5MDMzODUyOF5BMl5BanBnXkFtZTcwMTQ3NTMyNA@@._V1_FMjpg_UX682_.jpg", "Un boxeador poco conocido tiene la gran oportunidad de enfrentarse al campeón de los pesos pesados en un combate en el que espera estar a la altura y hacerse un nombre.", "Rocky", "https://www.youtube.com/embed/7RYpJAUMo2M" },
                    { 9, "https://m.media-amazon.com/images/M/MV5BNzVlY2MwMjktM2E4OS00Y2Y3LWE3ZjctYzhkZGM3YzA1ZWM2XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_FMjpg_UY745_.jpg", "Luke Skywalker une sus fuerzas con un caballero jedi, un piloto fanfarrón, un wookiee y dos droides para salvar a la galaxia de la estación espacial del Imperio, a la vez que intenta rescatar a la princesa Leia del malvado Darth Vader.", "Star Wars", "https://www.youtube.com/embed/vZ734NWnAHA" },
                    { 10, "https://m.media-amazon.com/images/M/MV5BMmQ2MmU3NzktZjAxOC00ZDZhLTk4YzEtMDMyMzcxY2IwMDAyXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_FMjpg_UY720_.jpg", "Un buque espacial percibe una transmisión desconocida pidiendo ayuda. Al llegar al origen de la señal encuentran a uno de los tripulantes atacado por una misteriosa forma de vida. Pronto se dan cuenta de que su ciclo vital acaba de empezar.", "Alien", "https://www.youtube.com/embed/LjLamj-b0I8" }
                });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "SalaId", "Capacidad" },
                values: new object[,]
                {
                    { 1, 5 },
                    { 2, 15 },
                    { 3, 35 }
                });

            migrationBuilder.InsertData(
                table: "Funciones",
                columns: new[] { "FuncionId", "Fecha", "Horario", "PeliculaId", "SalaId" },
                values: new object[,]
                {
                    { 1, new DateTime(2008, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 10, 0, 0, 0), 1, 1 },
                    { 3, new DateTime(2021, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 10, 0, 0, 0), 1, 1 },
                    { 2, new DateTime(2021, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 10, 0, 0, 0), 1, 2 },
                    { 4, new DateTime(2021, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 22, 0, 0, 0), 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_PeliculaId",
                table: "Funciones",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_SalaId",
                table: "Funciones",
                column: "SalaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FuncionesFuncionId",
                table: "Tickets",
                column: "FuncionesFuncionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Funciones");

            migrationBuilder.DropTable(
                name: "Peliculas");

            migrationBuilder.DropTable(
                name: "Salas");
        }
    }
}
