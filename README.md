# 💆 Estúdio de Estética — Sistema de Gestão

Sistema desenvolvido para a disciplina de **Orientação a Objetos**, com o objetivo de gerenciar sessões de atendimento em um estúdio de estética.

---

## 📋 Descrição

O sistema permite o cadastro de clientes, profissionais, procedimentos, pacotes de sessões e agendamentos. As principais regras de negócio implementadas são:

- Venda de pacotes de sessões para clientes
- Agendamento de sessões vinculadas a um pacote
- Registro de comparecimento (consome uma sessão do pacote)
- Remarcação de sessões
- Cancelamento de sessões
- Consulta de saldo de sessões por cliente
- Impedimento de agendamento sem saldo disponível
- Impedimento de conflito de horário para o mesmo profissional
- Impedimento de uso de sessão em pacote encerrado ou cancelado
- Impedimento de cancelamento de sessão já realizada

---

## 🏗️ Arquitetura

O projeto segue a arquitetura em camadas:

```
EstudioEstetica/
└── src/
    ├── EsteticaStudio.Domain/          # Entidades, Enums e Interfaces
    │   ├── Common/                     # Classe base Entity
    │   ├── Entities/                   # Cliente, Profissional, Procedimento, PacoteSessao, Sessao
    │   ├── Enums/                      # StatusPacote, StatusSessao
    │   └── Interfaces/                 # Contratos dos repositórios
    │
    ├── EsteticaStudio.Infrastructure/  # Repositórios em memória (sem banco de dados)
    │   └── Repositories/
    │
    ├── EsteticaStudio.Application/     # Regras de negócio (Services)
    │   └── Services/
    │
    ├── EsteticaStudio.ConsoleApp/      # Aplicação de console com menu interativo
    │
    └── EsteticaStudio.Web/             # Interface web com Blazor (sidebar + páginas CRUD)
```

---

## ▶️ Como rodar

### Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio Code](https://code.visualstudio.com/) com a extensão **C# Dev Kit**

### Rodar o Console

No terminal, dentro da pasta raiz da solução:

```bash
cd src/EsteticaStudio.ConsoleApp
dotnet run
```

O menu interativo será exibido no terminal com todas as opções de cadastro e gestão.

### Rodar o Blazor (interface web)

```bash
cd src/EsteticaStudio.Web
dotnet run
```

Depois acesse no navegador: `https://localhost:5001`

---

## 🧩 Funcionalidades

| Módulo | Operações |
|---|---|
| Clientes | Cadastrar, listar, editar, remover |
| Profissionais | Cadastrar, listar, editar, remover |
| Procedimentos | Cadastrar, listar, editar, remover |
| Pacotes | Vender, listar, consultar saldo por cliente, cancelar |
| Sessões | Agendar, listar, registrar comparecimento, remarcar, cancelar |

---

## 🛠️ Tecnologias utilizadas

- C# / .NET 10
- Blazor Server (interface web)
- Armazenamento em memória (sem banco de dados)
- Arquitetura em camadas (Domain, Application, Infrastructure, Presentation)

---

## 👩‍🎓 Informações acadêmicas

- **Disciplina:** Orientação a Objetos  
- **Curso:** Ciência da Computação
- **Instituição:** UTFPR
- **Aluna:** Maria Julia Becker
