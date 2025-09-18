# estacionamento-sampaio

Projeto do Bootcamp XP Inc — plataforma DIO.me  
Sistema de estacionamento para gerenciar veículos, cálculos de permanência, taxas, etc. :contentReference[oaicite:0]{index=0}

---

## 📑 Tabela de Conteúdos

- [Visão Geral](#visão-geral)  
- [Funcionalidades](#funcionalidades)  
- [Tecnologias Utilizadas](#tecnologias-utilizadas)  
- [Estrutura do Projeto](#estrutura-do-projeto)  
- [Pré-requisitos](#pré-requisitos)
- [Como Executar](#como-executar)  
- [Contato](#contato)  

---

## 📖 Visão Geral

Este é um sistema para estacionamento projetado para o Bootcamp XP Inc, através da DIO.me. Ele permite:

- cadastro de veículos  
- cálculo de tempo de permanência  
- cobrança baseada no tempo/período  
- validações como placa correta, etc.  

O projeto é uma prática para exercitar lógica de programação, manipulação de dados (listas ou coleções), controle de fluxo, e boas práticas de código.

---

## ⚙️ Funcionalidades

- Registrar entrada de veículo (placa, horário)  
- Registrar saída de veículo e calcular o valor a ser cobrado conforme o tempo de permanência  
- Validar formato de placa de veículo  
- Listar veículos atualmente estacionados  
- Verificar histórico de entradas/saídas (se implementado)  

---

## 🛠 Tecnologias Utilizadas

- **C#** 
- **Estrutura de projeto** .NET 9.0  
- **Ambiente de desenvolvimento:** VS Code   

---

## 📂 Estrutura do Projeto

Uma visão geral de como o projeto está organizado:

```bash
├── Data/ # Camada de acesso a dados / persistência
├── Models/ # Classes de modelo (ex.: Veículo, Estacionamento)
├── Services/ # Regras de negócio e lógica da aplicação
├── Utils/ # Funções utilitárias (ex.: validação de placa)
├── Program.cs # Ponto de entrada da aplicação
├── projetoEstacionamento.csproj # Arquivo de configuração do projeto .NET
└── projetoEstacionamento.sln # Arquivo de solução para Visual Studio
```

---

## 📋 Pré-requisitos

Para rodar localmente, você vai precisar:

- .NET SDK — versão X.X (especifique a que foi usada no projeto)  
- IDE/editor de código compatível com C#  
- Terminal / linha de comando com suporte a `dotnet`  

---

## 🚀 Como Executar

```bash
# Clonar o repositório
git clone https://github.com/victor-ss13/estacionamento-sampaio.git

# Entrar no diretório do projeto
cd estacionamento-sampaio/projetoEstacionamento   # ou onde estiver o .csproj

# Restaurar dependências
dotnet restore

# Compilar
dotnet build

# Executar
dotnet run
```

---

## 📬 Contato

- **Autor:** Victor Sampaio Silva
- **LinkedIn:** https://www.linkedin.com/in/victor-sampaio-silva-234893265/
