using CastraBus.Infra.Data.Context;
using CastraBus.Infra.Data.Entities.Concret;
using Microsoft.EntityFrameworkCore;

namespace CastraBus.Application.Services.Concret
{
    public static class DataServiceAsync 
    {
        /// <summary>
        /// Método para Inicializar todas as migrações e Inicializar o banco de dados
        /// </summary>
        /// <param name="context">Classe de Operação do Banco de Dados</param>
        public static void Initialize(ApplicationDbContext context)
        {
            var migrations = context.Database.GetPendingMigrations().ToList();

            if (migrations.Count() > 0)
            {
                context.Database.Migrate();
            }

            Task task = GenerateTipoEmpresa(context);
            task.Wait();

            task = GenerateTipoPessoa(context);
            task.Wait();

            task = GenerateEmpresa(context);
            task.Wait();

            task = GenerateModulos(context);
            task.Wait();

            task = GeneratePerfil(context);
            task.Wait();

            task = GeneratePermissoes(context);
            task.Wait();

            task = GenerateTipoSexo(context);
            task.Wait();

            task = GenerateTipoEspecie(context);
            task.Wait();

            task = GenerateUsuario(context);
            task.Wait();

            task = GeneratePessoa(context);
            task.Wait();

            task = GenerateCampanha(context);
            task.Wait();
        }

        /// <summary>
        /// Método para inicializar tabela de Tipo Empresa
        /// </summary>
        /// <param name="context">Classe de Operação do Banco de Dados</param>
        /// <returns>Não possui retorno</returns>
        private static async Task GenerateTipoEmpresa(ApplicationDbContext context)
        {
            try
            {
                var tps = await context.Set<TipoEmpresaEntity>().ToListAsync();

                if (tps.Count() == 0)
                {
                    var list = new List<TipoEmpresaEntity>
                    {
                        new TipoEmpresaEntity() {
                            Nome = "Contratante"
                        },
                        new TipoEmpresaEntity() {
                            Nome = "Empresa"
                        }
                    };

                    foreach (var item in list)
                    {
                        context.Set<TipoEmpresaEntity>().Add(item);
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para inicializar tabela de Tipo Pessoa
        /// </summary>
        /// <param name="context">Classe de Operação do Banco de Dados</param>
        /// <returns>Não possui retorno</returns>
        private static async Task GenerateTipoPessoa(ApplicationDbContext context)
        {
            try
            {
                var tps = await context.Set<TipoPessoaEntity>().ToListAsync();

                if (tps.Count() == 0)
                {
                    var list = new List<TipoPessoaEntity>
                    {
                        new TipoPessoaEntity() {
                            Nome = "Tutor"
                        },
                        new TipoPessoaEntity() {
                            Nome = "Veterinario"
                        }
                    };

                    foreach (var item in list)
                    {
                        context.Set<TipoPessoaEntity>().Add(item);
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para inicializar tabela de Empresa
        /// </summary>
        /// <param name="context">Classe de Operação do Banco de Dados</param>
        /// <returns>Não possui retorno</returns>
        private static async Task GenerateEmpresa(ApplicationDbContext context)
        {
            try
            {
                var emps = await context.Set<EmpresaEntity>().ToListAsync();

                if (emps.Count() == 0)
                {
                    var list = new List<EmpresaEntity>
                    {
                        new EmpresaEntity() {
                            RazaoSocial = "SC Serviços e Comércio LTDA",
                            NomeFantasia = "CastraBus",
                            CNPJ = "12.803.572/0001-98",
                            Email = "gestaocontrato@castrabus.com.br",
                            Responsavel = "Raul Augusto Spineli da Silva",
                            TipoEmpresaId = 2
                        }
                    };

                    foreach (var item in list)
                    {
                        context.Set<EmpresaEntity>().Add(item);
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para inicializar tabela de Modulo
        /// </summary>
        /// <param name="context">Classe de Operação do Banco de Dados</param>
        /// <returns>Não possui retorno</returns>
        private static async Task GenerateModulos(ApplicationDbContext context)
        {
            try
            {
                var mdl = await context.Set<ModuloEntity>().ToListAsync();

                if (mdl.Count() == 0)
                {
                    var list = new List<ModuloEntity>
                    {
                        new ModuloEntity() { Nome = "Empresa" },
                        new ModuloEntity() { Nome = "Campanha" },
                        new ModuloEntity() { Nome = "Perfil" },
                        new ModuloEntity() { Nome = "Animal" },
                        new ModuloEntity() { Nome = "Agendamento" },
                        new ModuloEntity() { Nome = "Pessoa" },
                        new ModuloEntity() { Nome = "Usuario" },
                        new ModuloEntity() { Nome = "Contratante" },
                        new ModuloEntity() { Nome = "Veterinario" },
                        new ModuloEntity() { Nome = "Tutor" }
                    };

                    foreach (var item in list)
                    {
                        context.Set<ModuloEntity>().Add(item);
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para inicializar tabela de Perfil
        /// </summary>
        /// <param name="context">Classe de Operação do Banco de Dados</param>
        /// <returns>Não possui retorno</returns>
        private static async Task GeneratePerfil(ApplicationDbContext context)
        {
            try
            {
                var pfs = await context.Set<PerfilEntity>().ToListAsync();

                if (pfs.Count() == 0)
                {
                    var emp = await context.Set<EmpresaEntity>().FirstOrDefaultAsync();

                    if (!Equals(emp, null))
                    {
                        var list = new List<PerfilEntity>
                        {
                            new PerfilEntity() {
                                Nome = "Administrador",
                                Role = "ADM",
                                EmpresaId = emp.Id,
                                Empresa = emp
                            },
                            new PerfilEntity() {
                                Nome = "Usuario",
                                Role = "USER",
                                EmpresaId = emp.Id,
                                Empresa = emp
                            },
                            new PerfilEntity() {
                                Nome = "Veterinario",
                                Role = "VET",
                                EmpresaId = emp.Id,
                                Empresa = emp
                            },
                            new PerfilEntity() {
                                Nome = "Atendente",
                                Role = "ATD",
                                EmpresaId = emp.Id,
                                Empresa = emp
                            },
                            new PerfilEntity() {
                                Nome = "Protetor",
                                Role = "PRT",
                                EmpresaId = emp.Id,
                                Empresa = emp
                            }
                        };

                        foreach (var item in list)
                        {
                            context.Set<PerfilEntity>().Add(item);
                            await context.SaveChangesAsync();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para inicializar tabela de Permissoes
        /// </summary>
        /// <param name="context">Classe de Operação do Banco de Dados</param>
        /// <returns>Não possui retorno</returns>
        private static async Task GeneratePermissoes(ApplicationDbContext context)
        {
            try
            {
                var pfs = await context.Set<PermissaoEntity>().ToListAsync();

                if (pfs.Count() == 0)
                {
                    var prf = await context.Set<PerfilEntity>().FirstOrDefaultAsync();
                    var mdls = await context.Set<ModuloEntity>().ToListAsync();

                    if (!Equals(prf, null) && !Equals(mdls, null))
                    {
                        var list = new List<PermissaoEntity>();

                        foreach (var item in mdls)
                        {
                            var pr = new PermissaoEntity()
                            {
                                Modulo = item,
                                ModuloId = item.Id,
                                Editar = true,
                                Inserir = true,
                                Excluir = true,
                                Visualizar = true,
                                Perfil = prf,
                                PerfilId = prf.Id
                            };

                            list.Add(pr);
                        }

                        foreach (var item in list)
                        {
                            context.Set<PermissaoEntity>().Add(item);
                            await context.SaveChangesAsync();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para inicializar tabela de Pessoa
        /// </summary>
        /// <param name="context">Classe de Operação do Banco de Dados</param>
        /// <returns>Não possui retorno</returns>
        private static async Task GeneratePessoa(ApplicationDbContext context)
        {
            try
            {
                var pess = await context.Set<PessoaEntity>().ToListAsync();

                if (pess.Count == 0)
                {
                    var pf = await context.Set<PerfilEntity>().Where(c => c.Role == "ADM").FirstOrDefaultAsync();
                    var emp = await context.Set<EmpresaEntity>().FirstOrDefaultAsync();
                    var users = await context.Set<UsuarioEntity>().ToListAsync();
                    var tps = await context.Set<TipoSexoEntity>().Where(c => c.Nome == "Masculino").FirstOrDefaultAsync();
                    var tp = await context.Set<TipoPessoaEntity>().Where(c => c.Nome == "Tutor").FirstOrDefaultAsync();

                    if (!(Equals(pf, null) && Equals(emp, null) && users.Count == 0))
                    {
                        var list = new List<PessoaEntity>
                        {
                            new PessoaEntity() {
                                NomeCompleto = "Rubens Rudio",
                                DataNascimento = DateTime.Now.ToShortDateString(),
                                CPF = "000.000.000-00",
                                Identidade = "00.000.000-0",
                                Telefone = "(00)00000-0000",
                                Endereco = "Rua Teste",
                                bairroId = 0,
                                cidadeId = 0,
                                estadoId = 0,
                                CEP = "00000-000",
                                Email = "teste@teste.com.br",
                                Usuario = users.FirstOrDefault(c => c.Username == "rubens"),
                                UsuarioId = users.FirstOrDefault(c => c.Username == "rubens").Id,
                                SexoId = tps.Id,
                                Sexo = tps,
                                TipoPessoa = tp,
                                TipoPessoaId = tp.Id
                            },
                            new PessoaEntity() {
                                NomeCompleto = "William Palhares",
                                DataNascimento = DateTime.Now.ToShortDateString(),
                                CPF = "000.000.000-01",
                                Identidade = "00.000.000-1",
                                Telefone = "(00)00000-0001",
                                Endereco = "Rua Teste",
                                bairroId = 0,
                                cidadeId = 0,
                                estadoId = 0,
                                CEP = "00000-001",
                                Email = "teste@teste.com.br",
                                Usuario = users.FirstOrDefault(c => c.Username == "william"),
                                UsuarioId = users.FirstOrDefault(c => c.Username == "william").Id,
                                SexoId = tps.Id,
                                Sexo = tps,
                                TipoPessoa = tp,
                                TipoPessoaId = tp.Id
                            }
                        };

                        foreach (var item in list)
                        {
                            context.Set<PessoaEntity>().Add(item);
                            await context.SaveChangesAsync();
                        }

                        foreach (var user in users)
                        {
                            var p = await context.Set<PessoaEntity>().Where(c => c.UsuarioId == user.Id).FirstOrDefaultAsync();
                            user.Pessoa = p;
                            user.PessoaId = p.Id;

                            context.Set<UsuarioEntity>().Update(user);
                            await context.SaveChangesAsync();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para inicializar tabela de Tipo de Sexo
        /// </summary>
        /// <param name="context">Classe de Operação do Banco de Dados</param>
        /// <returns>Não possui retorno</returns>
        private static async Task GenerateTipoSexo(ApplicationDbContext context)
        {
            try
            {
                var tps = await context.Set<TipoSexoEntity>().ToListAsync();
                
                if (tps.Count() == 0)
                {
                    var list = new List<TipoSexoEntity>
                    {
                        new TipoSexoEntity() { Nome = "Feminino" },
                        new TipoSexoEntity() { Nome = "Masculino" }
                    };

                    foreach (var item in list)
                    {
                        context.Set<TipoSexoEntity>().Add(item);
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para inicializar tabela de Tipo de Espécie
        /// </summary>
        /// <param name="context">Classe de Operação do Banco de Dados</param>
        /// <returns>Não possui retorno</returns>
        private static async Task GenerateTipoEspecie(ApplicationDbContext context)
        {
            try
            {
                var tps = await context.Set<TipoEspecieEntity>().ToListAsync();

                if (tps.Count() == 0)
                {
                    var list = new List<TipoEspecieEntity>
                    {
                        new TipoEspecieEntity() { Nome = "Felino" },
                        new TipoEspecieEntity() { Nome = "Canino" },
                        new TipoEspecieEntity() { Nome = "Ambas" }
                    };

                    foreach (var item in list)
                    {
                        context.Set<TipoEspecieEntity>().Add(item);
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para inicializar tabela de Usuário
        /// </summary>
        /// <param name="context">Classe de Operação do Banco de Dados</param>
        /// <returns>Não possui retorno</returns>
        private static async Task GenerateUsuario(ApplicationDbContext context)
        {
            try
            {
                var users = await context.Set<UsuarioEntity>().ToListAsync();

                if (users.Count() == 0)
                {
                    var pf = await context.Set<PerfilEntity>().Where(c => c.Role == "ADM").FirstOrDefaultAsync();
                    var emp = await context.Set<EmpresaEntity>().FirstOrDefaultAsync();

                    if (!(Equals(pf, null) && Equals(emp, null)))
                    {
                        var list = new List<UsuarioEntity>
                        {
                            new UsuarioEntity() {
                                Username = "rubens",
                                Password = "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f",
                                Empresa = emp,
                                EmpresaId = emp.Id,
                                Perfil = pf,
                                PerfilId = pf.Id,
                                Email = "teste@gmail.com"
                            },
                            new UsuarioEntity() {
                                Username = "william",
                                Password = "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f",
                                Empresa = emp,
                                EmpresaId = emp.Id,
                                Perfil = pf,
                                PerfilId = pf.Id,
                                Email = "teste@gmail.com"
                            }
                        };

                        foreach (var item in list)
                        {
                            context.Set<UsuarioEntity>().Add(item);
                            await context.SaveChangesAsync();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para inicializar tabela de Campanha
        /// </summary>
        /// <param name="context">Classe de Operação do Banco de Dados</param>
        /// <returns>Não possui retorno</returns>
        private static async Task GenerateCampanha(ApplicationDbContext context)
        {
            try
            {
                var configuracaos = await context.Set<CampanhaEntity>().ToListAsync();

                if (configuracaos.Count() == 0)
                {
                    var emp = await context.Set<EmpresaEntity>().FirstOrDefaultAsync();

                    if (!Equals(emp, null))
                    {
                        CampanhaEntity campanha = new CampanhaEntity()
                        {
                            Id = 0,
                            estadoId = 33,
                            cidadeId = 3304557,
                            bairroId = 330455705,
                            dataInicio = "2024-08-05",
                            dataFim = "2024-08-09",
                            horaInicio = "08:00",
                            horaFim = "17:00",
                            horaInicioIntervalo = "12:00",
                            horaFimIntervalo = "13:00",
                            domingo = false,
                            segunda = true,
                            terca = true,
                            quarta = true,
                            quinta = true,
                            sexta = true,
                            sabado = false,
                            pontuacaoDia = 10,
                            IntervaloAtendimento = 15,
                            caninoManha = true,
                            caninoTarde = false,
                            felinoManha = false,
                            felinoTarde = true,
                            EmpresaId = emp.Id,
                            NomeCampanha = "Campanha Teste",
                            LocalCampanha = "teste"
                        };

                        context.Set<CampanhaEntity>().Add(campanha);
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
