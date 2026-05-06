# 🏦 BankAccount

Sistema de gerenciamento de contas bancárias desenvolvido em C# com .NET 10, aplicando conceitos de Orientação a Objetos.

---

## 📋 Sobre o Projeto

O BankAccount é um sistema de console interativo que simula operações bancárias básicas. Desenvolvido como projeto do primeiro módulo do curso, aplica os princípios de POO como herança, abstração, encapsulamento e polimorfismo.

---

## ✅ Funcionalidades

- Criar conta corrente e conta poupança
- Listar todas as contas
- Buscar conta por número
- Depositar, sacar e transferir entre contas
- Atualizar dados da conta
- Deletar conta
- Senha por conta com hash SHA256
- Confirmação antes de operações importantes
- Suporte a dois idiomas: Português (PT-BR) e English (EN)
- Persistência de dados com SQLite
- Interface colorida no terminal

---

## 🏗️ Estrutura do Projeto

```
BankAccount/
├── Controllers/
│   └── AccountController.cs   # Implementa IAccountRepository
├── Models/
│   ├── Account.cs             # Classe abstrata base
│   ├── CheckingAccount.cs     # Conta Corrente (herda Account)
│   └── SavingsAccount.cs      # Conta Poupança (herda Account)
├── Repositories/
│   └── IAccountRepository.cs  # Interface com os métodos do sistema
├── Utils/
│   ├── Colors.cs              # Cores e leitura de senha
│   ├── DatabaseSqlite.cs      # Persistência com SQLite
│   └── Language.cs            # Suporte PT-BR e EN
└── Program.cs                 # Menu interativo principal
```

---

## 🚀 Como Executar

### Pré-requisitos
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- Visual Studio 2022 ou VS Code

### Passos

1. Clone o repositório:
```bash
git clone https://github.com/OSIELJ/BankAccount.git
```

2. Acesse a pasta do projeto:
```bash
cd BankAccount/BankAccount
```

3. Execute o projeto:
```bash
dotnet run
```

> O banco de dados `bankaccount.db` é criado automaticamente na primeira execução.

---

## 🖥️ Como Usar

Ao iniciar o sistema, um menu interativo será exibido:

```
╔════════════════════════════════╗
║   SISTEMA DE CONTA BANCÁRIA   ║
╚════════════════════════════════╝
  1 - Criar Conta Corrente
  2 - Criar Conta Poupança
  3 - Listar Todas as Contas
  4 - Buscar Conta
  5 - Depositar
  6 - Sacar
  7 - Transferir
  8 - Deletar Conta
  9 - Atualizar Conta
  L - Idioma / Language

  0 - Sair
```

### Criando uma conta
- Informe o número da agência (ex: `001`)
- Informe o nome do titular
- Informe o saldo inicial
- Para conta corrente, informe o limite
- Crie e confirme uma senha

### Operações financeiras
- Digite o número da conta
- Digite a senha da conta
- Informe o valor
- Confirme a operação

---

## 🔒 Segurança

As senhas são armazenadas com hash **SHA256** — nunca em texto puro. Mesmo abrindo o banco de dados diretamente, não é possível ver a senha original.

---

## 🛠️ Tecnologias

- C# / .NET 10
- SQLite via `Microsoft.Data.Sqlite`
- SHA256 para hash de senhas
- Git e GitHub para versionamento

---

## 📁 Banco de Dados

O arquivo `bankaccount.db` é gerado automaticamente em:

```
bin/Debug/net10.0/bankaccount.db
```

Para visualizar os dados, use o [DB Browser for SQLite](https://sqlitebrowser.org/).

---

## 👨‍💻 Autor

Desenvolvido por **Osiel Junior Martins Bicalho**