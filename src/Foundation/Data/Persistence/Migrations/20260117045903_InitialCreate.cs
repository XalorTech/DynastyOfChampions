using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DynastyOfChampions.Foundation.Data.Persistence.Migrations
{
	/// <inheritdoc />
	public partial class InitialCreate : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Persons",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
					BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
					DeathDate = table.Column<DateTime>(type: "datetime2", nullable: true),
					BirthCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
					BirthRegion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
					BirthCountry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
					DeathCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
					DeathRegion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
					DeathCountry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
					ActiveNickname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
					DisplayName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Persons", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Sports",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
					Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
					Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Sports", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "PersonHistories",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
					GivenNames = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
					Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
					Suffix = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
					StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
					PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_PersonHistories", x => x.Id);
					table.ForeignKey(
						name: "FK_PersonHistories_Persons_PersonId",
						column: x => x.PersonId,
						principalTable: "Persons",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Leagues",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
					SportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Leagues", x => x.Id);
					table.ForeignKey(
						name: "FK_Leagues_Sports_SportId",
						column: x => x.SportId,
						principalTable: "Sports",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "PersonNicknames",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
					Nickname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
					PersonHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_PersonNicknames", x => x.Id);
					table.ForeignKey(
						name: "FK_PersonNicknames_PersonHistories_PersonHistoryId",
						column: x => x.PersonHistoryId,
						principalTable: "PersonHistories",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Coaches",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
					PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					LeagueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Coaches", x => x.Id);
					table.ForeignKey(
						name: "FK_Coaches_Leagues_LeagueId",
						column: x => x.LeagueId,
						principalTable: "Leagues",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Coaches_Persons_PersonId",
						column: x => x.PersonId,
						principalTable: "Persons",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "CoachTypes",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
					Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
					Abbreviation = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
					Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
					SortOrder = table.Column<int>(type: "int", nullable: false),
					LeagueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_CoachTypes", x => x.Id);
					table.ForeignKey(
						name: "FK_CoachTypes_Leagues_LeagueId",
						column: x => x.LeagueId,
						principalTable: "Leagues",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "LeagueHistories",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
					Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
					Abbreviation = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
					Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
					StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
					LeagueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_LeagueHistories", x => x.Id);
					table.ForeignKey(
						name: "FK_LeagueHistories_Leagues_LeagueId",
						column: x => x.LeagueId,
						principalTable: "Leagues",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "LeagueUnits",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
					LeagueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_LeagueUnits", x => x.Id);
					table.ForeignKey(
						name: "FK_LeagueUnits_Leagues_LeagueId",
						column: x => x.LeagueId,
						principalTable: "Leagues",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Players",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
					PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					LeagueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Players", x => x.Id);
					table.ForeignKey(
						name: "FK_Players_Leagues_LeagueId",
						column: x => x.LeagueId,
						principalTable: "Leagues",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Players_Persons_PersonId",
						column: x => x.PersonId,
						principalTable: "Persons",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Positions",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
					Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
					Abbreviation = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
					Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
					LeagueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Positions", x => x.Id);
					table.ForeignKey(
						name: "FK_Positions_Leagues_LeagueId",
						column: x => x.LeagueId,
						principalTable: "Leagues",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Positions_Positions_ParentId",
						column: x => x.ParentId,
						principalTable: "Positions",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "RoleTypes",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
					Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
					Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
					SortOrder = table.Column<int>(type: "int", nullable: false),
					SportId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
					LeagueId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_RoleTypes", x => x.Id);
					table.ForeignKey(
						name: "FK_RoleTypes_Leagues_LeagueId",
						column: x => x.LeagueId,
						principalTable: "Leagues",
						principalColumn: "Id");
					table.ForeignKey(
						name: "FK_RoleTypes_Sports_SportId",
						column: x => x.SportId,
						principalTable: "Sports",
						principalColumn: "Id");
				});

			migrationBuilder.CreateTable(
				name: "Seasons",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
					Year = table.Column<int>(type: "int", nullable: false),
					StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					LeagueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Seasons", x => x.Id);
					table.ForeignKey(
						name: "FK_Seasons_Leagues_LeagueId",
						column: x => x.LeagueId,
						principalTable: "Leagues",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Statuses",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
					Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
					Abbreviation = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
					Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
					SortOrder = table.Column<int>(type: "int", nullable: false),
					LeagueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Statuses", x => x.Id);
					table.ForeignKey(
						name: "FK_Statuses_Leagues_LeagueId",
						column: x => x.LeagueId,
						principalTable: "Leagues",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "LeagueUnitHistories",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
					Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
					DisplayLabel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
					Level = table.Column<int>(type: "int", nullable: false),
					ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
					StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
					LeagueUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_LeagueUnitHistories", x => x.Id);
					table.ForeignKey(
						name: "FK_LeagueUnitHistories_LeagueUnitHistories_ParentId",
						column: x => x.ParentId,
						principalTable: "LeagueUnitHistories",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_LeagueUnitHistories_LeagueUnits_LeagueUnitId",
						column: x => x.LeagueUnitId,
						principalTable: "LeagueUnits",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Teams",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
					LeagueUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Teams", x => x.Id);
					table.ForeignKey(
						name: "FK_Teams_LeagueUnits_LeagueUnitId",
						column: x => x.LeagueUnitId,
						principalTable: "LeagueUnits",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "CareerPhases",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
					StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
					EndReason = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
					PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					RoleTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					LeagueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					SportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_CareerPhases", x => x.Id);
					table.ForeignKey(
						name: "FK_CareerPhases_Leagues_LeagueId",
						column: x => x.LeagueId,
						principalTable: "Leagues",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_CareerPhases_Persons_PersonId",
						column: x => x.PersonId,
						principalTable: "Persons",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_CareerPhases_RoleTypes_RoleTypeId",
						column: x => x.RoleTypeId,
						principalTable: "RoleTypes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_CareerPhases_Sports_SportId",
						column: x => x.SportId,
						principalTable: "Sports",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Rosters",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
					RosterType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					SeasonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Rosters", x => x.Id);
					table.ForeignKey(
						name: "FK_Rosters_Seasons_SeasonId",
						column: x => x.SeasonId,
						principalTable: "Seasons",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Rosters_Teams_TeamId",
						column: x => x.TeamId,
						principalTable: "Teams",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "TeamHistories",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
					Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
					Abbreviation = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
					City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
					Region = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
					Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
					DisplayLocation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
					ShortLocation = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
					StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
					TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_TeamHistories", x => x.Id);
					table.ForeignKey(
						name: "FK_TeamHistories_Teams_TeamId",
						column: x => x.TeamId,
						principalTable: "Teams",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "RosterCoaches",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
					StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
					Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
					RosterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					CoachId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_RosterCoaches", x => x.Id);
					table.ForeignKey(
						name: "FK_RosterCoaches_Coaches_CoachId",
						column: x => x.CoachId,
						principalTable: "Coaches",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_RosterCoaches_Rosters_RosterId",
						column: x => x.RosterId,
						principalTable: "Rosters",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "RosterPlayers",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
					JerseyNumber = table.Column<int>(type: "int", nullable: true),
					StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
					Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
					RosterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_RosterPlayers", x => x.Id);
					table.ForeignKey(
						name: "FK_RosterPlayers_Players_PlayerId",
						column: x => x.PlayerId,
						principalTable: "Players",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_RosterPlayers_Rosters_RosterId",
						column: x => x.RosterId,
						principalTable: "Rosters",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_RosterPlayers_Statuses_StatusId",
						column: x => x.StatusId,
						principalTable: "Statuses",
						principalColumn: "Id",
						onDelete: ReferentialAction.SetNull);
				});

			migrationBuilder.CreateTable(
				name: "RosterCoachTypes",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
					RosterCoachId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					CoachTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_RosterCoachTypes", x => x.Id);
					table.ForeignKey(
						name: "FK_RosterCoachTypes_CoachTypes_CoachTypeId",
						column: x => x.CoachTypeId,
						principalTable: "CoachTypes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_RosterCoachTypes_RosterCoaches_RosterCoachId",
						column: x => x.RosterCoachId,
						principalTable: "RosterCoaches",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "RosterPlayerPositions",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
					RosterPlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_RosterPlayerPositions", x => x.Id);
					table.ForeignKey(
						name: "FK_RosterPlayerPositions_Positions_PositionId",
						column: x => x.PositionId,
						principalTable: "Positions",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_RosterPlayerPositions_RosterPlayers_RosterPlayerId",
						column: x => x.RosterPlayerId,
						principalTable: "RosterPlayers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_CareerPhases_LeagueId",
				table: "CareerPhases",
				column: "LeagueId");

			migrationBuilder.CreateIndex(
				name: "IX_CareerPhases_PersonId",
				table: "CareerPhases",
				column: "PersonId");

			migrationBuilder.CreateIndex(
				name: "IX_CareerPhases_RoleTypeId",
				table: "CareerPhases",
				column: "RoleTypeId");

			migrationBuilder.CreateIndex(
				name: "IX_CareerPhases_SportId",
				table: "CareerPhases",
				column: "SportId");

			migrationBuilder.CreateIndex(
				name: "IX_Coaches_LeagueId",
				table: "Coaches",
				column: "LeagueId");

			migrationBuilder.CreateIndex(
				name: "IX_Coaches_PersonId",
				table: "Coaches",
				column: "PersonId");

			migrationBuilder.CreateIndex(
				name: "IX_CoachTypes_LeagueId",
				table: "CoachTypes",
				column: "LeagueId");

			migrationBuilder.CreateIndex(
				name: "IX_LeagueHistories_LeagueId",
				table: "LeagueHistories",
				column: "LeagueId");

			migrationBuilder.CreateIndex(
				name: "IX_Leagues_SportId",
				table: "Leagues",
				column: "SportId");

			migrationBuilder.CreateIndex(
				name: "IX_LeagueUnitHistories_LeagueUnitId",
				table: "LeagueUnitHistories",
				column: "LeagueUnitId");

			migrationBuilder.CreateIndex(
				name: "IX_LeagueUnitHistories_ParentId",
				table: "LeagueUnitHistories",
				column: "ParentId");

			migrationBuilder.CreateIndex(
				name: "IX_LeagueUnits_LeagueId",
				table: "LeagueUnits",
				column: "LeagueId");

			migrationBuilder.CreateIndex(
				name: "IX_PersonHistories_PersonId",
				table: "PersonHistories",
				column: "PersonId");

			migrationBuilder.CreateIndex(
				name: "IX_PersonNicknames_PersonHistoryId",
				table: "PersonNicknames",
				column: "PersonHistoryId");

			migrationBuilder.CreateIndex(
				name: "IX_Players_LeagueId",
				table: "Players",
				column: "LeagueId");

			migrationBuilder.CreateIndex(
				name: "IX_Players_PersonId",
				table: "Players",
				column: "PersonId");

			migrationBuilder.CreateIndex(
				name: "IX_Positions_LeagueId",
				table: "Positions",
				column: "LeagueId");

			migrationBuilder.CreateIndex(
				name: "IX_Positions_ParentId",
				table: "Positions",
				column: "ParentId");

			migrationBuilder.CreateIndex(
				name: "IX_RoleTypes_LeagueId",
				table: "RoleTypes",
				column: "LeagueId");

			migrationBuilder.CreateIndex(
				name: "IX_RoleTypes_SportId",
				table: "RoleTypes",
				column: "SportId");

			migrationBuilder.CreateIndex(
				name: "IX_RosterCoaches_CoachId",
				table: "RosterCoaches",
				column: "CoachId");

			migrationBuilder.CreateIndex(
				name: "IX_RosterCoaches_RosterId",
				table: "RosterCoaches",
				column: "RosterId");

			migrationBuilder.CreateIndex(
				name: "IX_RosterCoachTypes_CoachTypeId",
				table: "RosterCoachTypes",
				column: "CoachTypeId");

			migrationBuilder.CreateIndex(
				name: "IX_RosterCoachTypes_RosterCoachId",
				table: "RosterCoachTypes",
				column: "RosterCoachId");

			migrationBuilder.CreateIndex(
				name: "IX_RosterPlayerPositions_PositionId",
				table: "RosterPlayerPositions",
				column: "PositionId");

			migrationBuilder.CreateIndex(
				name: "IX_RosterPlayerPositions_RosterPlayerId",
				table: "RosterPlayerPositions",
				column: "RosterPlayerId");

			migrationBuilder.CreateIndex(
				name: "IX_RosterPlayers_PlayerId",
				table: "RosterPlayers",
				column: "PlayerId");

			migrationBuilder.CreateIndex(
				name: "IX_RosterPlayers_RosterId",
				table: "RosterPlayers",
				column: "RosterId");

			migrationBuilder.CreateIndex(
				name: "IX_RosterPlayers_StatusId",
				table: "RosterPlayers",
				column: "StatusId");

			migrationBuilder.CreateIndex(
				name: "IX_Rosters_SeasonId",
				table: "Rosters",
				column: "SeasonId");

			migrationBuilder.CreateIndex(
				name: "IX_Rosters_TeamId",
				table: "Rosters",
				column: "TeamId");

			migrationBuilder.CreateIndex(
				name: "IX_Seasons_LeagueId",
				table: "Seasons",
				column: "LeagueId");

			migrationBuilder.CreateIndex(
				name: "IX_Statuses_LeagueId",
				table: "Statuses",
				column: "LeagueId");

			migrationBuilder.CreateIndex(
				name: "IX_TeamHistories_TeamId",
				table: "TeamHistories",
				column: "TeamId");

			migrationBuilder.CreateIndex(
				name: "IX_Teams_LeagueUnitId",
				table: "Teams",
				column: "LeagueUnitId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "CareerPhases");

			migrationBuilder.DropTable(
				name: "LeagueHistories");

			migrationBuilder.DropTable(
				name: "LeagueUnitHistories");

			migrationBuilder.DropTable(
				name: "PersonNicknames");

			migrationBuilder.DropTable(
				name: "RosterCoachTypes");

			migrationBuilder.DropTable(
				name: "RosterPlayerPositions");

			migrationBuilder.DropTable(
				name: "TeamHistories");

			migrationBuilder.DropTable(
				name: "RoleTypes");

			migrationBuilder.DropTable(
				name: "PersonHistories");

			migrationBuilder.DropTable(
				name: "CoachTypes");

			migrationBuilder.DropTable(
				name: "RosterCoaches");

			migrationBuilder.DropTable(
				name: "Positions");

			migrationBuilder.DropTable(
				name: "RosterPlayers");

			migrationBuilder.DropTable(
				name: "Coaches");

			migrationBuilder.DropTable(
				name: "Players");

			migrationBuilder.DropTable(
				name: "Rosters");

			migrationBuilder.DropTable(
				name: "Statuses");

			migrationBuilder.DropTable(
				name: "Persons");

			migrationBuilder.DropTable(
				name: "Seasons");

			migrationBuilder.DropTable(
				name: "Teams");

			migrationBuilder.DropTable(
				name: "LeagueUnits");

			migrationBuilder.DropTable(
				name: "Leagues");

			migrationBuilder.DropTable(
				name: "Sports");
		}
	}
}
