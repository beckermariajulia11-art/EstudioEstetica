using EsteticaStudio.Application.Services;
using EsteticaStudio.Infrastructure.Repositories;

// ── Repositórios em memória ───────────────────────────────────────────────────
var clienteRepo      = new ClienteRepository();
var profissionalRepo = new ProfissionalRepository();
var procedimentoRepo = new ProcedimentoRepository();
var pacoteRepo       = new PacoteSessaoRepository();
var sessaoRepo       = new SessaoRepository();

// ── Services ─────────────────────────────────────────────────────────────────
var clienteService      = new ClienteService(clienteRepo);
var profissionalService = new ProfissionalService(profissionalRepo);
var procedimentoService = new ProcedimentoService(procedimentoRepo);
var pacoteService       = new PacoteService(pacoteRepo, clienteRepo, procedimentoRepo);
var sessaoService       = new SessaoService(sessaoRepo, pacoteRepo, profissionalRepo);

bool executando = true;

while (executando)
{
    Console.Clear();
    Console.WriteLine("╔════════════════════════════════════════╗");
    Console.WriteLine("║      ESTÚDIO DE ESTÉTICA — MENU        ║");
    Console.WriteLine("╠════════════════════════════════════════╣");
    Console.WriteLine("║  CLIENTES                              ║");
    Console.WriteLine("║   1  Cadastrar cliente                 ║");
    Console.WriteLine("║   2  Listar clientes                   ║");
    Console.WriteLine("║   3  Editar cliente                    ║");
    Console.WriteLine("║   4  Remover cliente                   ║");
    Console.WriteLine("╠════════════════════════════════════════╣");
    Console.WriteLine("║  PROFISSIONAIS                         ║");
    Console.WriteLine("║   5  Cadastrar profissional            ║");
    Console.WriteLine("║   6  Listar profissionais              ║");
    Console.WriteLine("║   7  Editar profissional               ║");
    Console.WriteLine("║   8  Remover profissional              ║");
    Console.WriteLine("╠════════════════════════════════════════╣");
    Console.WriteLine("║  PROCEDIMENTOS                         ║");
    Console.WriteLine("║   9  Cadastrar procedimento            ║");
    Console.WriteLine("║  10  Listar procedimentos              ║");
    Console.WriteLine("║  11  Editar procedimento               ║");
    Console.WriteLine("║  12  Remover procedimento              ║");
    Console.WriteLine("╠════════════════════════════════════════╣");
    Console.WriteLine("║  PACOTES                               ║");
    Console.WriteLine("║  13  Vender pacote                     ║");
    Console.WriteLine("║  14  Listar pacotes                    ║");
    Console.WriteLine("║  15  Consultar saldo por cliente       ║");
    Console.WriteLine("║  16  Cancelar pacote                   ║");
    Console.WriteLine("╠════════════════════════════════════════╣");
    Console.WriteLine("║  SESSÕES                               ║");
    Console.WriteLine("║  17  Agendar sessão                    ║");
    Console.WriteLine("║  18  Listar sessões                    ║");
    Console.WriteLine("║  19  Registrar comparecimento          ║");
    Console.WriteLine("║  20  Remarcar sessão                   ║");
    Console.WriteLine("║  21  Cancelar sessão                   ║");
    Console.WriteLine("║  22  Consultar sessões por profissional║");
    Console.WriteLine("║  23  Consultar sessões por data        ║");
    Console.WriteLine("╠════════════════════════════════════════╣");
    Console.WriteLine("║   0  Sair                              ║");
    Console.WriteLine("╚════════════════════════════════════════╝");
    Console.Write("\nEscolha uma opção: ");

    var opcao = Console.ReadLine();
    Console.WriteLine();

    try
    {
        switch (opcao)
        {
            // ── CLIENTES ─────────────────────────────────────────────────────
            case "1":
                Console.Write("Nome: "); var nC = Console.ReadLine()!;
                Console.Write("Telefone: "); var tC = Console.ReadLine()!;
                Console.Write("E-mail: "); var eC = Console.ReadLine()!;
                clienteService.Cadastrar(nC, tC, eC);
                Ok("Cliente cadastrado!");
                break;

            case "2":
                var clientes = clienteService.Listar();
                if (!clientes.Any()) { Vazio("Nenhum cliente."); break; }
                Cabecalho($"{"ID",-38} {"Nome",-25} {"Telefone",-15} Email");
                foreach (var c in clientes)
                    Console.WriteLine($"{c.Id,-38} {c.Nome,-25} {c.Telefone,-15} {c.Email}");
                break;

            case "3":
                Console.Write("ID do cliente: "); var idEC = Guid.Parse(Console.ReadLine()!);
                Console.Write("Novo nome: "); var nnC = Console.ReadLine()!;
                Console.Write("Novo telefone: "); var ntC = Console.ReadLine()!;
                Console.Write("Novo e-mail: "); var neC = Console.ReadLine()!;
                clienteService.Atualizar(idEC, nnC, ntC, neC);
                Ok("Cliente atualizado!");
                break;

            case "4":
                Console.Write("ID do cliente: "); var idRC = Guid.Parse(Console.ReadLine()!);
                clienteService.Remover(idRC);
                Ok("Cliente removido!");
                break;

            // ── PROFISSIONAIS ────────────────────────────────────────────────
            case "5":
                Console.Write("Nome: "); var nP = Console.ReadLine()!;
                Console.Write("Especialidade: "); var eP = Console.ReadLine()!;
                profissionalService.Cadastrar(nP, eP);
                Ok("Profissional cadastrado!");
                break;

            case "6":
                var profs = profissionalService.Listar();
                if (!profs.Any()) { Vazio("Nenhum profissional."); break; }
                Cabecalho($"{"ID",-38} {"Nome",-25} Especialidade");
                foreach (var p in profs)
                    Console.WriteLine($"{p.Id,-38} {p.Nome,-25} {p.Especialidade}");
                break;

            case "7":
                Console.Write("ID do profissional: "); var idEP = Guid.Parse(Console.ReadLine()!);
                Console.Write("Novo nome: "); var nnP = Console.ReadLine()!;
                Console.Write("Nova especialidade: "); var neP = Console.ReadLine()!;
                profissionalService.Atualizar(idEP, nnP, neP);
                Ok("Profissional atualizado!");
                break;

            case "8":
                Console.Write("ID do profissional: "); var idRP = Guid.Parse(Console.ReadLine()!);
                profissionalService.Remover(idRP);
                Ok("Profissional removido!");
                break;

            // ── PROCEDIMENTOS ────────────────────────────────────────────────
            case "9":
                Console.Write("Nome: "); var nPr = Console.ReadLine()!;
                Console.Write("Duração (minutos): "); var dPr = int.Parse(Console.ReadLine()!);
                Console.Write("Descrição: "); var descPr = Console.ReadLine()!;
                procedimentoService.Cadastrar(nPr, dPr, descPr);
                Ok("Procedimento cadastrado!");
                break;

            case "10":
                var procs = procedimentoService.Listar();
                if (!procs.Any()) { Vazio("Nenhum procedimento."); break; }
                Cabecalho($"{"ID",-38} {"Nome",-25} {"Duração",-10} Descrição");
                foreach (var pr in procs)
                    Console.WriteLine($"{pr.Id,-38} {pr.Nome,-25} {pr.DuracaoMinutos + " min",-10} {pr.Descricao}");
                break;

            case "11":
                Console.Write("ID do procedimento: "); var idEPr = Guid.Parse(Console.ReadLine()!);
                Console.Write("Novo nome: "); var nnPr = Console.ReadLine()!;
                Console.Write("Nova duração (min): "); var ndPr = int.Parse(Console.ReadLine()!);
                Console.Write("Nova descrição: "); var ndescPr = Console.ReadLine()!;
                procedimentoService.Atualizar(idEPr, nnPr, ndPr, ndescPr);
                Ok("Procedimento atualizado!");
                break;

            case "12":
                Console.Write("ID do procedimento: "); var idRPr = Guid.Parse(Console.ReadLine()!);
                procedimentoService.Remover(idRPr);
                Ok("Procedimento removido!");
                break;

            // ── PACOTES ──────────────────────────────────────────────────────
            case "13":
                Console.WriteLine("--- Clientes ---");
                foreach (var c in clienteService.Listar())
                    Console.WriteLine($"  {c.Id}  {c.Nome}");
                Console.Write("ID do cliente: "); var idCliPac = Guid.Parse(Console.ReadLine()!);

                Console.WriteLine("--- Procedimentos ---");
                foreach (var pr in procedimentoService.Listar())
                    Console.WriteLine($"  {pr.Id}  {pr.Nome}");
                Console.Write("ID do procedimento: "); var idProcPac = Guid.Parse(Console.ReadLine()!);

                Console.Write("Quantidade de sessões: "); var qtd = int.Parse(Console.ReadLine()!);
                Console.Write("Valor total (R$): "); var valPac = decimal.Parse(Console.ReadLine()!);
                var pacote = pacoteService.VenderPacote(idCliPac, idProcPac, qtd, valPac);
                Ok($"Pacote vendido! ID: {pacote.Id}");
                break;

            case "14":
                var pacotes = pacoteService.Listar();
                if (!pacotes.Any()) { Vazio("Nenhum pacote."); break; }
                Cabecalho($"{"ID",-38} {"Cliente",-20} {"Procedimento",-20} {"Total",-6} {"Usadas",-7} {"Saldo",-6} Status");
                foreach (var pk in pacotes)
                    Console.WriteLine($"{pk.Id,-38} {pk.Cliente.Nome,-20} {pk.Procedimento.Nome,-20} {pk.QuantidadeContratada,-6} {pk.SessoesUtilizadas,-7} {pk.SessoesDisponiveis,-6} {pk.Status}");
                break;

            case "15":
                Console.WriteLine("--- Clientes ---");
                foreach (var c in clienteService.Listar())
                    Console.WriteLine($"  {c.Id}  {c.Nome}");
                Console.Write("ID do cliente: "); var idCliSaldo = Guid.Parse(Console.ReadLine()!);
                var saldo = pacoteService.ConsultarSaldoPorCliente(idCliSaldo);
                if (!saldo.Any()) { Vazio("Nenhum pacote para este cliente."); break; }
                Cabecalho($"{"Procedimento",-25} {"Contratadas",-12} {"Utilizadas",-11} {"Disponíveis",-12} Status");
                foreach (var pk in saldo)
                    Console.WriteLine($"{pk.Procedimento.Nome,-25} {pk.QuantidadeContratada,-12} {pk.SessoesUtilizadas,-11} {pk.SessoesDisponiveis,-12} {pk.Status}");
                break;

            case "16":
                Console.Write("ID do pacote: "); var idCanPac = Guid.Parse(Console.ReadLine()!);
                pacoteService.Cancelar(idCanPac);
                Ok("Pacote cancelado!");
                break;

            // ── SESSÕES ──────────────────────────────────────────────────────
            case "17":
                Console.WriteLine("--- Pacotes ativos ---");
                foreach (var pk in pacoteService.Listar().Where(p => p.Status == EsteticaStudio.Domain.Enums.StatusPacote.Ativo))
                    Console.WriteLine($"  {pk.Id}  {pk.Cliente.Nome} | {pk.Procedimento.Nome} | Saldo: {pk.SessoesDisponiveis}");
                Console.Write("ID do pacote: "); var idPacSes = Guid.Parse(Console.ReadLine()!);

                Console.WriteLine("--- Profissionais ---");
                foreach (var p in profissionalService.Listar())
                    Console.WriteLine($"  {p.Id}  {p.Nome} ({p.Especialidade})");
                Console.Write("ID do profissional: "); var idProfSes = Guid.Parse(Console.ReadLine()!);

                Console.Write("Data e hora (dd/MM/yyyy HH:mm): ");
                var dtSes = DateTime.ParseExact(Console.ReadLine()!, "dd/MM/yyyy HH:mm",
                    System.Globalization.CultureInfo.InvariantCulture);
                Console.Write("Observações (Enter para pular): "); var obsSes = Console.ReadLine() ?? "";

                var novaSessao = sessaoService.Agendar(idPacSes, idProfSes, dtSes, obsSes);
                Ok($"Sessão agendada! ID: {novaSessao.Id}");
                break;

            case "18":
                var sessoes = sessaoService.Listar();
                if (!sessoes.Any()) { Vazio("Nenhuma sessão."); break; }
                ImprimirSessoes(sessoes);
                break;

            case "19":
                Console.Write("ID da sessão: "); var idComp = Guid.Parse(Console.ReadLine()!);
                sessaoService.RegistrarComparecimento(idComp);
                Ok("Comparecimento registrado! Sessão consumida do pacote.");
                break;

            case "20":
                Console.Write("ID da sessão: "); var idRem = Guid.Parse(Console.ReadLine()!);
                Console.Write("Nova data e hora (dd/MM/yyyy HH:mm): ");
                var dtRem = DateTime.ParseExact(Console.ReadLine()!, "dd/MM/yyyy HH:mm",
                    System.Globalization.CultureInfo.InvariantCulture);
                sessaoService.Remarcar(idRem, dtRem);
                Ok("Sessão remarcada!");
                break;

            case "21":
                Console.Write("ID da sessão: "); var idCanSes = Guid.Parse(Console.ReadLine()!);
                sessaoService.Cancelar(idCanSes);
                Ok("Sessão cancelada!");
                break;

            case "22":
                Console.WriteLine("--- Profissionais ---");
                foreach (var p in profissionalService.Listar())
                    Console.WriteLine($"  {p.Id}  {p.Nome}");
                Console.Write("ID do profissional: "); var idProfFil = Guid.Parse(Console.ReadLine()!);
                var porProf = sessaoService.ConsultarPorProfissional(idProfFil);
                if (!porProf.Any()) { Vazio("Nenhuma sessão."); break; }
                ImprimirSessoes(porProf);
                break;

            case "23":
                Console.Write("Data (dd/MM/yyyy): ");
                var dataFil = DateTime.ParseExact(Console.ReadLine()!, "dd/MM/yyyy",
                    System.Globalization.CultureInfo.InvariantCulture);
                var porData = sessaoService.ConsultarPorData(dataFil);
                if (!porData.Any()) { Vazio("Nenhuma sessão nesta data."); break; }
                ImprimirSessoes(porData);
                break;

            case "0":
                executando = false;
                Console.WriteLine("Encerrando... Até logo!");
                break;

            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }
    catch (FormatException)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("✖ Formato inválido. Verifique os dados digitados.");
        Console.ResetColor();
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"✖ Erro: {ex.Message}");
        Console.ResetColor();
    }

    if (executando)
    {
        Console.WriteLine();
        Console.WriteLine("Pressione ENTER para continuar...");
        Console.ReadLine();
    }
}

// ── Helpers de exibição ───────────────────────────────────────────────────────
static void Ok(string msg)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"✔ {msg}");
    Console.ResetColor();
}

static void Vazio(string msg)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(msg);
    Console.ResetColor();
}

static void Cabecalho(string linha)
{
    Console.WriteLine(linha);
    Console.WriteLine(new string('-', 110));
}

static void ImprimirSessoes(List<EsteticaStudio.Domain.Entities.Sessao> lista)
{
    Console.WriteLine($"{"ID",-38} {"Cliente",-18} {"Profissional",-18} {"Procedimento",-18} {"Data/Hora",-18} Status");
    Console.WriteLine(new string('-', 130));
    foreach (var s in lista)
        Console.WriteLine($"{s.Id,-38} {s.Pacote.Cliente.Nome,-18} {s.Profissional.Nome,-18} {s.Pacote.Procedimento.Nome,-18} {s.DataHorario:dd/MM/yyyy HH:mm,-18} {s.Status}");
}
