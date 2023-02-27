# livraria-minsait

Instruções para executrar o projeto:

#### Observações/pré-requisitos:
* Possuir Node instalado - versão utilizada: 16.19.1;
* Possuir Angular instalado - versão utilizada: 12.2.0;
* Possuir SDK .NET Core instalado - versão utilizada: 5.0.408;
* Possuir Banco de Dados PostgreSQL instalado (usuário/senha utilizado: postgres/123456) - versão utilizada: 14.7-1.

<br>

### Backend (usando Visual Studio 2022)

Abrir solution "Livraria.sln" presente em "Back/src"

Acessar menu de contexto clicando com botão direito do mouse no item da solução pelo "Gerenciador de Soluções" e clicar na opção "Restaurar Pacotes NuGet"

Aguardar baixar os pacotes dos projetos

Inicializar banco de dados PostgreSQL

Alterar "ConnectionString" ("User Id" e "Password"), acessando o arquivo "appsettings.json" no projeto "Livraria.API", com o usuário e senha do banco de dados

Abrir "Console do Gerenciador de Pacotes"

Executar comando "Update-Database" (para atualizar o banco de dados de acordo com as migrations do projeto)

Iniciar projeto (Ctrl + F5 ou botão "Play" na guia superior)

<br>

### Frontend
Via linha de comando, entrar na pasta "Frontend", executar o comando para instalar as dependências do projeto:\
_npm i_

Após instalar as dependências, executar o start:\
_ng s_

Ao final, o projeto deverá estar disponível na URL:\
http://localhost:4200