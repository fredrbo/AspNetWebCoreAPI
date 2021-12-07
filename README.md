# Curso AspNetWebCoreAPI
Curso oferecido pelo [Professor Vinícius de Andrade](https://github.com/vsandrade), na plataforma [Udemy](https://www.udemy.com/course/criando-web-api-com-aspnet-core-31-ef-core-31/)

## 💻 Projeto

Desenvolver uma plataforma web para listagem e visualização de alunos e professores, para a construção deste projeto foi usado o framework Angular.

<p align="center">
<img src="http://img.shields.io/static/v1?label=STATUS&message=EM%20DESENVOLVIMENTO&color=GREEN&style=for-the-badge"/>
</p>

<p align="center">
    <img width="500" src="https://github.com/fredrbo/AspNetWebCoreAPI/blob/master/SmartSchoolApp/src/assets/readme/Alunos.gif">
</p>
<ul>
    <li> No menu de alunos é possivel já possivel realizar todo proceddo CRUD</li>
    <li> Desativar e ativar matricula</li>
    <li> Paginação já aplicada</li>
</ul>
<p align="center">
    <img width="500" src="https://github.com/fredrbo/AspNetWebCoreAPI/blob/master/SmartSchoolApp/src/assets/readme/Professores.gif">
</p>

<ul>
    <li>No menu de professores é possivel consultá-los</li>
    <li>Verificar suas disciplibas e seus alunos cadastrados na mesma</li>
</ul>
    
O curso acaba com essas funções apenas, mas ainda deve ser implementadas as seguintes funções
- [ ] Login
- [ ] Processo de CRUD dos professores
- [ ] DashBoard

## 🚀 Tecnologias usadas

- .Net Core 5.0 
- Angular CLI 12.2 
- EF Core 5.0
- SwaggerUI
- MySQL

## Como instalar

- Baixe ou clone este repositório usando `git clone https://github.com/fredrbo/AspNetWebCoreAPI.git`;
- Dentro do diretório, instale as dependências usando `npm install`.

## Como executar

Execute `ng serve` na pasta SmartSchoolApp para executar a versão de desenvolvimento. Depois acesse `http://localhost:4200/`.

Para executar o servidor da API, em um outro terminal na pasta SmartSchool.WebAPI, execute `dotnet watch run`. A API poderá ser acessada via `http://localhost:5001/`.
## Como compilar/construir

Execute `ng build` para buildar o projeto. 

