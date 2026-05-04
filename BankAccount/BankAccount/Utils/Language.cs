namespace BankAccount.Utils
{
    public enum AppLanguage { PTBR, EN }

    public static class Language
    {
        public static AppLanguage Current { get; private set; } = AppLanguage.PTBR;

        public static void Set(AppLanguage lang) => Current = lang;

        // Menu titles
        public static string MenuTitle => Current == AppLanguage.PTBR
            ? "   SISTEMA DE CONTA BANCÁRIA   "
            : "       BANK ACCOUNT SYSTEM      ";

        // Menu options
        public static string OptCreateChecking => Current == AppLanguage.PTBR
            ? "  1 - Criar Conta Corrente"
            : "  1 - Create Checking Account";
        public static string OptCreateSavings => Current == AppLanguage.PTBR
            ? "  2 - Criar Conta Poupança"
            : "  2 - Create Savings Account";
        public static string OptListAll => Current == AppLanguage.PTBR
            ? "  3 - Listar Todas as Contas"
            : "  3 - List All Accounts";
        public static string OptFind => Current == AppLanguage.PTBR
            ? "  4 - Buscar Conta"
            : "  4 - Find Account";
        public static string OptDeposit => Current == AppLanguage.PTBR
            ? "  5 - Depositar"
            : "  5 - Deposit";
        public static string OptWithdraw => Current == AppLanguage.PTBR
            ? "  6 - Sacar"
            : "  6 - Withdraw";
        public static string OptTransfer => Current == AppLanguage.PTBR
            ? "  7 - Transferir"
            : "  7 - Transfer";
        public static string OptDelete => Current == AppLanguage.PTBR
            ? "  8 - Deletar Conta"
            : "  8 - Delete Account";
        public static string OptUpdate => Current == AppLanguage.PTBR
            ? "  9 - Atualizar Conta"
            : "  9 - Update Account";
        public static string OptLanguage => Current == AppLanguage.PTBR
            ? "  L - Idioma / Language"
            : "  L - Language / Idioma";
        public static string OptExit => Current == AppLanguage.PTBR
            ? "  0 - Sair"
            : "  0 - Exit";
        public static string ChooseOption => Current == AppLanguage.PTBR
            ? "\n  Escolha uma opção: "
            : "\n  Choose an option: ";
        public static string PressAnyKey => Current == AppLanguage.PTBR
            ? "\nPressione qualquer tecla para continuar..."
            : "\nPress any key to continue...";

        // Operations
        public static string CreateChecking => Current == AppLanguage.PTBR
            ? "=== Criar Conta Corrente ==="
            : "=== Create Checking Account ===";
        public static string CreateSavings => Current == AppLanguage.PTBR
            ? "=== Criar Conta Poupança ==="
            : "=== Create Savings Account ===";
        public static string ListAll => Current == AppLanguage.PTBR
            ? "=== Todas as Contas ==="
            : "=== All Accounts ===";
        public static string FindAccount => Current == AppLanguage.PTBR
            ? "=== Buscar Conta ==="
            : "=== Find Account ===";
        public static string Deposit => Current == AppLanguage.PTBR
            ? "=== Depositar ==="
            : "=== Deposit ===";
        public static string Withdraw => Current == AppLanguage.PTBR
            ? "=== Sacar ==="
            : "=== Withdraw ===";
        public static string Transfer => Current == AppLanguage.PTBR
            ? "=== Transferir ==="
            : "=== Transfer ===";
        public static string DeleteAccount => Current == AppLanguage.PTBR
            ? "=== Deletar Conta ==="
            : "=== Delete Account ===";
        public static string UpdateAccount => Current == AppLanguage.PTBR
            ? "=== Atualizar Conta ==="
            : "=== Update Account ===";

        // Inputs
        public static string OwnerName => Current == AppLanguage.PTBR
            ? "Nome do titular: "
            : "Owner name: ";
        public static string InitialBalance => Current == AppLanguage.PTBR
            ? "Saldo inicial: "
            : "Initial balance: ";
        public static string LimitDefault => Current == AppLanguage.PTBR
            ? "Limite (padrão 1000): "
            : "Limit (default 1000): ";
        public static string AccountNumber => Current == AppLanguage.PTBR
            ? "Número da conta: "
            : "Account number: ";
        public static string Amount => Current == AppLanguage.PTBR
            ? "Valor: "
            : "Amount: ";
        public static string OriginAccount => Current == AppLanguage.PTBR
            ? "Número da conta origem: "
            : "Origin account number: ";
        public static string DestinyAccount => Current == AppLanguage.PTBR
            ? "Número da conta destino: "
            : "Destiny account number: ";
        public static string NewOwnerName => Current == AppLanguage.PTBR
            ? "\nNovo nome do titular (Enter para manter): "
            : "\nNew owner name (Enter to keep): ";

        // Success messages
        public static string AccountCreated => Current == AppLanguage.PTBR
            ? "Conta criada com sucesso! Número: "
            : "Account created successfully! Number: ";
        public static string AccountUpdated => Current == AppLanguage.PTBR
            ? "Conta atualizada com sucesso!"
            : "Account updated successfully!";
        public static string AccountDeleted => Current == AppLanguage.PTBR
            ? "Conta deletada com sucesso!"
            : "Account deleted successfully!";
        public static string DepositSuccess => Current == AppLanguage.PTBR
            ? "Depósito realizado com sucesso!"
            : "Deposit successful!";
        public static string WithdrawSuccess => Current == AppLanguage.PTBR
            ? "Saque realizado com sucesso!"
            : "Withdraw successful!";
        public static string TransferSuccess => Current == AppLanguage.PTBR
            ? "Transferência realizada com sucesso!"
            : "Transfer successful!";

        // Error messages
        public static string AccountNotFound => Current == AppLanguage.PTBR
            ? "Conta não encontrada."
            : "Account not found.";
        public static string InsufficientBalance => Current == AppLanguage.PTBR
            ? "Saldo insuficiente."
            : "Insufficient balance.";
        public static string InvalidAmount => Current == AppLanguage.PTBR
            ? "Valor inválido."
            : "Invalid amount.";
        public static string InvalidOption => Current == AppLanguage.PTBR
            ? "Opção inválida."
            : "Invalid option.";
        public static string Goodbye => Current == AppLanguage.PTBR
            ? "\nAté logo!"
            : "\nGoodbye!";
        public static string NoAccounts => Current == AppLanguage.PTBR
            ? "Nenhuma conta encontrada."
            : "No accounts found.";

        // Language selection
        public static string SelectLanguage => Current == AppLanguage.PTBR
            ? "=== Selecionar Idioma ==="
            : "=== Select Language ===";
        public static string LangPTBR => "  1 - Português (PT-BR)";
        public static string LangEN => "  2 - English (EN)";
        public static string LangChanged => Current == AppLanguage.PTBR
            ? "Idioma alterado para Português!"
            : "Language changed to English!";
    }
}